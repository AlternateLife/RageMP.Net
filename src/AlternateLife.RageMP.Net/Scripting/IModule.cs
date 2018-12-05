using Microsoft.Extensions.DependencyInjection;

namespace AlternateLife.RageMP.Net.Scripting
{
    public interface IModule
    {
        void ConfigureServices(IServiceCollection services);
    }
}
