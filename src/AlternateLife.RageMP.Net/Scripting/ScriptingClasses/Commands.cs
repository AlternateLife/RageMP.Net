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

        public bool Register(string name, CommandDelegate callback)
        {
            Contract.NotEmpty(name, nameof(name));
            Contract.NotNull(callback, nameof(callback));

            var commandInfo = new CommandInformation(name, callback);

            return _commands.TryAdd(name, commandInfo);
        }

        public void Remove(CommandDelegate callback)
        {
            Contract.NotNull(callback, nameof(callback));

            RemoveCommands(x => x.CommandHandler == null && x.Callback == callback);
        }

        public void Remove(string name)
        {
            Contract.NotEmpty(name, nameof(name));

            RemoveCommands(x => x.Name == name);
        }

        public void RegisterHandler(ICommandHandler handler)
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

                var commandInfo = new CommandInformation(attribute.Name, commandDelegate, handler);

                if (_commands.TryAdd(attribute.Name, commandInfo) == false)
                {
                    _logger.Warn($"Command {attribute.Name}: Could not register command of method \"{commandMethod.Name}\" in \"{commandMethod.DeclaringType}\", maybe command-name is already in use!");
                }
            }
        }

        public void RemoveHandler(ICommandHandler handler)
        {
            Contract.NotNull(handler, nameof(handler));

            RemoveCommands(x => x.CommandHandler == handler);
        }

        private void RemoveCommands(Func<CommandInformation, bool> predicate)
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

        public async void ExecuteCommand(IPlayer player, string commandText)
        {
            if (string.IsNullOrWhiteSpace(commandText))
            {
                return;
            }

            var parts = commandText.Trim().Split(' ');

            var commandName = parts[0];

            if (_commands.TryGetValue(commandName, out var commandInformation) == false)
            {
                await player.OutputChatBoxAsync($"Command \"{commandName}\" not found.");

                return;
            }

            try
            {
                await commandInformation.Callback(player, parts.Skip(1).Where(x => string.IsNullOrWhiteSpace(x) == false).ToArray());
            }
            catch (Exception e)
            {
                _logger.Error($"An error occured when player {player.Name} executed command: {commandName}: ", e);
            }
        }
    }
}
