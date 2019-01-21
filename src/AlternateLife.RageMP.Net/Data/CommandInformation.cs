using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Data
{
    internal abstract class CommandInformation
    {
        public string Name { get; }

        public ICommandHandler CommandHandler { get; }
        
        protected CommandInformation(string name, ICommandHandler handler)
        {
            Name = name;
            CommandHandler = handler;
        }
    }
}