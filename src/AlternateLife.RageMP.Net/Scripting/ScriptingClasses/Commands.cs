using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Attributes;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Extensions;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting.ScriptingClasses.TypeParsers;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses
{
    internal class Commands : ICommands
    {
        private readonly Plugin _plugin;
        private readonly ILogger _logger;

        public event EventHandler<CommandErrorEventArgs> CommandError;

        private readonly Dictionary<string, CommandInformation> _commands = new Dictionary<string, CommandInformation>();
        
        public Commands(Plugin plugin)
        {
            _plugin = plugin;
            _logger = _plugin.Logger;
        }
        
        public bool DoesCommandExist(string name)
        {
            Contract.NotEmpty(name, nameof(name));

            return _commands.ContainsKey(name);
        }
        
        public IReadOnlyCollection<string> GetRegisteredCommands()
        {
            return _commands.Keys;
        }

        public void RemoveHandler(ICommandHandler handler)
        {
            Contract.NotNull(handler, nameof(handler));

            var command = _commands.Values.FirstOrDefault(c => c.CommandHandler == handler);
            
            if (command == null)
            {
                return;
            }

            _commands.Remove(command.Name);
        }
        
        public void Remove(string name)
        {
            Contract.NotEmpty(name, nameof(name));

            _commands.Remove(name);
        }
        
        public void RegisterHandler(ICommandHandler handler)
        {
            Contract.NotNull(handler, nameof(handler));

            var commandMethods = handler.GetType().GetMethods()
                .Where(m => m.GetCustomAttributes(typeof(CommandAttribute), true).Length > 0);

            foreach (var commandMethod in commandMethods)
            {
                var attribute = commandMethod.GetCustomAttribute<CommandAttribute>();
                
                if (string.IsNullOrEmpty(attribute.Name))
                {
                    _logger.Warn($"Skipping method {commandMethod.Name} because of invalid command name.");
                    continue;
                }

                if (_commands.ContainsKey(attribute.Name))
                {
                    _logger.Warn($"Command {attribute.Name}: Name is already in use!");
                    continue;
                }
                
                if (commandMethod.ReturnType != typeof(Task))
                {
                    _logger.Warn($"Command {attribute.Name}: Return type {commandMethod.ReturnType} is invalid, {typeof(Task)} expected!");
                    continue;
                }

                if (commandMethod.IsStatic)
                {
                    _logger.Warn($"Command {attribute.Name}: Static methods are not allowed!");
                    continue;
                }
                
                _commands.Add(attribute.Name, new CommandInformation(attribute.Name, handler, commandMethod));
            }
        }
        
        private static bool IsParams(ICustomAttributeProvider param)
        {
            return param.GetCustomAttributes(typeof (ParamArrayAttribute), false).Length > 0;
        }
        
        private readonly Dictionary<Type, ITypeParser> _typeParsingSwitch = new Dictionary<Type, ITypeParser>
        {
            {typeof(int),     new PrimitiveParser<int>(int.TryParse)},
            {typeof(float),   new PrimitiveParser<float>(float.TryParse)},
            {typeof(double),  new PrimitiveParser<double>(double.TryParse)},
            {typeof(uint),    new PrimitiveParser<uint>(uint.TryParse)},
            {typeof(long),    new PrimitiveParser<long>(long.TryParse)},
            {typeof(char),    new PrimitiveParser<char>(char.TryParse)},
            {typeof(bool),    new PrimitiveParser<bool>(bool.TryParse)},
            {typeof(byte),    new PrimitiveParser<byte>(byte.TryParse)},
            {typeof(sbyte),   new PrimitiveParser<sbyte>(sbyte.TryParse)},
            {typeof(short),   new PrimitiveParser<short>(short.TryParse)},
            {typeof(decimal), new PrimitiveParser<decimal>(decimal.TryParse)},
            {typeof(ushort),  new PrimitiveParser<ushort>(ushort.TryParse)},
            {typeof(ulong),   new PrimitiveParser<ulong>(ulong.TryParse)},
            {typeof(string),  new StringParser()},
            {typeof(Enum),    new EnumParser()}
        };

        private IEnumerable<object> ProcessArguments(IReadOnlyList<string> args, IReadOnlyList<ParameterInfo> expectedParameters)
        {
            if (args.Count < expectedParameters.Count)
            {
                return null;
            }
            var parsedArgs = new List<object>();
            for (int i = 0; i < args.Count; i++)
            {
                var expectedType = expectedParameters[i].ParameterType;
                var targetType = expectedType;
                if (expectedType.BaseType == typeof(Enum))
                {
                    expectedType = typeof(Enum);
                }
                bool isParams = IsParams(expectedParameters[i]);

                if (i == expectedParameters.Count - 1 && isParams)
                {
                    var paramList = new List<object>();
                    for (; i < args.Count; i++)
                    {
                        paramList.Add(args[i]);
                    }

                    parsedArgs.Add(paramList.ToArray());
                    break;
                }

                if (i == expectedParameters.Count - 1 && !isParams && args.Count > expectedParameters.Count)
                {
                    return null;
                }
                
                if (!_typeParsingSwitch.ContainsKey(expectedType))
                {
                    return null;
                }
                
                if (!_typeParsingSwitch[expectedType].TryParse(args[i], targetType, out var parsedPara))
                {
                    return null;
                }
                parsedArgs.Add(parsedPara);
            }

            return parsedArgs;
        }

        public async Task ExecuteCommand(IPlayer player, string text)
        {
            string[] commandMessage = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (commandMessage.Length == 0)
            {
                return;
            }
            string commandname = commandMessage[0];

            if (_commands.TryGetValue(commandname, out var command) == false)
            {
                OnCommandError(new CommandErrorEventArgs(player, Enums.CommandError.CommandNotFound, $"Command {commandname} not found"));
                return;
            }

            string[] commandArgs = commandMessage.Skip(1).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            var parsedArgs = ProcessArguments(commandArgs, command.MethodInfo.GetParameters().Skip(1).ToArray());
            if (parsedArgs == null)
            {
                OnCommandError(new CommandErrorEventArgs(player, Enums.CommandError.TypeParsingFailed,
                    "Type conversion failed. Command parameters are: " + command.GetParameterList()));
                return;
            }
            
            try
            {
                await command.Invoke(invokingArguments);
            }
            catch (Exception e)
            {
                _logger.Error($"An error occured when player {player.Name} executed command: {command.Name}: ", e);
            }
        }

        protected virtual void OnCommandError(CommandErrorEventArgs e)
        {
            CommandError?.Invoke(this, e);
        }
    }
}
