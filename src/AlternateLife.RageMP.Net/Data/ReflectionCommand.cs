using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Data
{
    internal class ReflectionCommand : CommandInformation
    {
        public MethodInfo MethodInfo { get; }

        public ReflectionCommand(string name, ICommandHandler commandHandler, MethodInfo methodInfo) : base(name, commandHandler)
        {
            MethodInfo = methodInfo;
        }

        public async Task Invoke(object[] args)
        {
            await (Task)MethodInfo.Invoke(CommandHandler, args);
        }

        public string GetParameterList()
        {
            var result = new StringBuilder();

            foreach (var parameterInfo in MethodInfo.GetParameters().Skip(1))
            {
                if (parameterInfo.HasDefaultValue)
                {
                    result.Append($"<{parameterInfo.Name}> ");
                }
                else
                {
                    result.Append($"[{parameterInfo.Name}] ");
                }
            }

            return result.ToString();
        }

    }
}
