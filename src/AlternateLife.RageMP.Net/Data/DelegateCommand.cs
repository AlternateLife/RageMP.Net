using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Data
{
    internal class DelegateCommand : CommandInformation
    {
        public CommandDelegate CommandDelegate { get; }

        public DelegateCommand(string name, CommandDelegate commandDelegate, ICommandHandler handler = default(ICommandHandler)) : base(name, handler)
        {
            CommandDelegate = commandDelegate;
        }
    }
}
