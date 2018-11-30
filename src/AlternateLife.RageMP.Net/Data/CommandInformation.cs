using AlternateLife.RageMP.Net.Attributes;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Data
{
    internal class CommandInformation
    {
        public ICommandHandler CommandHandler { get; }
        public CommandDelegate Callback { get; }
        public CommandAttribute Attribute { get; }

        public CommandInformation(ICommandHandler commandHandler, CommandAttribute attribute, CommandDelegate callback)
        {
            CommandHandler = commandHandler;
            Callback = callback;
            Attribute = attribute;
        }
    }
}
