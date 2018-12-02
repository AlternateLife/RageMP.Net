using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Data
{
    internal class CommandInformation
    {
        public ICommandHandler CommandHandler { get; }

        public string Name { get; }
        public CommandDelegate Callback { get; }

        public CommandInformation(string name, CommandDelegate callback, ICommandHandler commandHandler = default(ICommandHandler))
        {
            CommandHandler = commandHandler;
            Name = name;
            Callback = callback;
        }
    }
}
