using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Data
{
    internal class CommandInformation
    {
        public ICommandHandler CommandHandler { get; }

        public MethodInfo MethodInfo { get; }
        
        public string Name { get; }

        public CommandInformation(string name, ICommandHandler commandHandler, MethodInfo methodInfo)
        {
            CommandHandler = commandHandler;
            Name = name;
            MethodInfo = methodInfo;
        }
        
        public async Task Invoke(object[] args)
        {
            await (Task)MethodInfo.Invoke(CommandHandler, args);
        }

        public string GetParameterList()
        {
            return MethodInfo.GetParameters().Skip(1).Aggregate("", (s, p) => s + p.ParameterType.Name + " ").Trim();
        }
    }
}