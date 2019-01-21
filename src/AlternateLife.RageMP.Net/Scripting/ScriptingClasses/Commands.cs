using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Attributes;
using AlternateLife.RageMP.Net.Data;
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

        private readonly ConcurrentDictionary<string, CommandInformation> _commands = new ConcurrentDictionary<string, CommandInformation>();
        
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
            return _commands.Keys.ToList();
        }

        public void RemoveHandler(ICommandHandler handler)
        {
            Contract.NotNull(handler, nameof(handler));

            RemoveCommands(c => (c as ReflectionCommand)?.CommandHandler == handler);
        }
        
        public bool Register(string name, CommandDelegate callback)
        {
            Contract.NotEmpty(name, nameof(name));
            Contract.NotNull(callback, nameof(callback));

            var commandInfo = new DelegateCommand(name, callback);

            return _commands.TryAdd(name, commandInfo);
        }

        public void Remove(CommandDelegate callback)
        {
            Contract.NotNull(callback, nameof(callback));

            RemoveCommands(c => (c as DelegateCommand)?.CommandDelegate == callback);
        }

        private void RemoveCommands(Predicate<CommandInformation> predicate)
        {
            foreach (var command in _commands.Reverse())
            {
                if (predicate(command.Value) == false)
                {
                    continue;
                }

                _commands.TryRemove(command.Key, out _);
            }
        }

        public void Remove(string name)
        {
            Contract.NotEmpty(name, nameof(name));

            _commands.TryRemove(name, out _);
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

                CommandInformation command;
                if (HasCommandDelegateSignature(commandMethod))
                {
                    command = new DelegateCommand(attribute.Name, (CommandDelegate) Delegate.CreateDelegate(typeof(CommandDelegate), handler, commandMethod), handler);
                }
                else
                {
                    command = new ReflectionCommand(attribute.Name, handler, commandMethod);
                }

                if (_commands.TryAdd(attribute.Name, command) == false)
                {
                    _logger.Warn($"Command {attribute.Name}: Could not register command of method \"{commandMethod.Name}\" in \"{commandMethod.DeclaringType}\", maybe command-name is already in use!");
                }
            }
        }

        private static bool HasCommandDelegateSignature(MethodBase methodInfo)
        {
            var parameterTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToList();
            var commandDelegateParameter = typeof(CommandDelegate).GetMethod("Invoke").GetParameters().Select(p => p.ParameterType).ToList();
            if (parameterTypes.Count != commandDelegateParameter.Count)
            {
                return false;
            }

            return parameterTypes.Where((t, i) => t != commandDelegateParameter[i]).Any() == false;
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

        private bool ProcessArguments(IReadOnlyList<string> args, IReadOnlyList<ParameterInfo> expectedParameters, IList<object> invokingParameters)
        {
            if (args.Count < expectedParameters.Count)
            {
                return false;
            }
            
            var parsedArguments = new List<object>();
            for (int i = 0; i < args.Count; i++)
            {
                var expectedType = expectedParameters[i].ParameterType;
                var targetType = expectedType;
                if (expectedType.IsEnum)
                {
                    expectedType = typeof(Enum);
                }
                bool isParams = IsParams(expectedParameters[i]);

                if (i == expectedParameters.Count - 1 && isParams)
                {
                    var parameterList = new List<object>();
                    for (; i < args.Count; i++)
                    {
                        parameterList.Add(args[i]);
                    }

                    parsedArguments.Add(parameterList.ToArray());
                    break;
                }

                if (i == expectedParameters.Count - 1 && isParams == false && args.Count > expectedParameters.Count)
                {
                    return false;
                }
                
                if(_typeParsingSwitch.TryGetValue(expectedType, out var parser) == false ||
                   parser.TryParse(args[i], targetType, out var parsedParameter) == false)
                {
                    return false;
                }
                parsedArguments.Add(parsedParameter);
            }

            for (int i = 0; i < parsedArguments.Count; i++)
            {
                invokingParameters[i + 1] = parsedArguments[i];
            }

            return true;
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

            string[] commandArguments = commandMessage.Skip(1).Where(s => string.IsNullOrWhiteSpace(s) == false).ToArray();

            switch (command)
            {
                case ReflectionCommand reflectionCommand:
                    await ExecuteReflectionCommand(player, reflectionCommand, commandArguments);
                    break;
                case DelegateCommand delegateCommand:
                    await ExecuteDelegateCommand(player, delegateCommand, commandArguments);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async Task ExecuteReflectionCommand(IPlayer player, ReflectionCommand reflectionCommand, string[] arguments)
        {
            object[] invokingArguments = new object[reflectionCommand.MethodInfo.GetParameters().Length];
            invokingArguments[0] = player;

            if (ProcessArguments(arguments, reflectionCommand.MethodInfo.GetParameters().Skip(1).ToArray(), invokingArguments) == false)
            {
                OnCommandError(new CommandErrorEventArgs(player, Enums.CommandError.TypeParsingFailed,
                    "Type conversion failed. Command parameters are: " + reflectionCommand.GetParameterList()));
                return;
            }

            try
            {
                await reflectionCommand.Invoke(invokingArguments);
            }
            catch (Exception e)
            {
                _logger.Error($"An error occured when player {player.Name} executed command: {reflectionCommand.Name}: ", e);
            }
        }

        private async Task ExecuteDelegateCommand(IPlayer player, DelegateCommand delegateCommand, string[] arguments)
        {
            try
            {
                await delegateCommand.CommandDelegate(player, arguments);
            }
            catch (Exception e)
            {
                _logger.Error($"An error occured when player {player.Name} executed command: {delegateCommand.Name}: ", e);
            }
        }

        protected virtual void OnCommandError(CommandErrorEventArgs e)
        {
            CommandError?.Invoke(this, e);
        }
    }
}
