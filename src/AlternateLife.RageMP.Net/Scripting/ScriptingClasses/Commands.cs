using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Attributes;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses
{
    internal class Commands : ICommands
    {
        private readonly Plugin _plugin;
        private readonly ILogger _logger;

        private readonly ConcurrentDictionary<string, CommandInformation> _commands = new ConcurrentDictionary<string, CommandInformation>();

        internal Commands(Plugin plugin)
        {
            _plugin = plugin;
            _logger = _plugin.Logger;
        }

        public void RegisterCommandHandler(ICommandHandler handler)
        {
            Contract.NotNull(handler, nameof(handler));

            foreach (var commandMethod in handler.GetType().GetMethods().Where(x => x.GetCustomAttributes(typeof(CommandAttribute), true).Any()))
            {
                var attribute = commandMethod.GetCustomAttribute<CommandAttribute>();

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

                CommandDelegate commandDelegate;
                try
                {
                    commandDelegate = (CommandDelegate) Delegate.CreateDelegate(typeof(CommandDelegate), handler, commandMethod);
                }
                catch (ArgumentException)
                {
                    _logger.Warn($"Command {attribute.Name}: Signature is invalid, method should implement {typeof(CommandDelegate)}!");

                    continue;
                }

                var commandInfo = new CommandInformation(handler, attribute, commandDelegate);

                _commands.TryAdd(attribute.Name, commandInfo);

                _logger.Debug($"Commandmethod found: {commandMethod.Name}");
            }
        }

        public void RemoveCommandHandler(ICommandHandler handler)
        {
            Contract.NotNull(handler, nameof(handler));


        }
    }
}
