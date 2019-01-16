using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Data
{
    internal class Command
    {
        public string Name { get; }
        public MethodInfo MethodInfo { get; }
        public ICommandHandler Handler { get; }

        public Command(string name, MethodInfo methodInfo, ICommandHandler handler)
        {
            Name = name;
            MethodInfo = methodInfo;
            Handler = handler;
        }

        public async Task Invoke(object[] args)
        {
            await (Task)MethodInfo.Invoke(Handler, args);
        }

        public string GetParameterList()
        {
            return MethodInfo.GetParameters().Skip(1).Aggregate("", (s, p) => s + p.ParameterType.Name + " ").Trim();
        }
    }
}