using AlternateLife.RageMP.Net.Scripting;
using Microsoft.Extensions.DependencyInjection;

namespace AlternateLife.RageMP.Net.Example
{
    public class ExampleModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IResource, ExampleResource>();
        }
    }
}
