using AlternateLife.RageMP.Net.Elements.Pools;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting.ScriptingClasses;
using Microsoft.Extensions.DependencyInjection;

namespace AlternateLife.RageMP.Net
{
    internal class MainModule
    {
        public void ConfigureServices(Plugin plugin, IServiceCollection services)
        {
            services.AddSingleton<IPlayerPool>(p => plugin.PlayerPool);
            services.AddSingleton<IVehiclePool>(p => plugin.VehiclePool);
            services.AddSingleton<IBlipPool>(p => plugin.BlipPool);
            services.AddSingleton<ICheckpointPool>(p => plugin.CheckpointPool);
            services.AddSingleton<IColshapePool>(p => plugin.ColshapePool);
            services.AddSingleton<IMarkerPool>(p => plugin.MarkerPool);
            services.AddSingleton<IObjectPool>(p => plugin.ObjectPool);
            services.AddSingleton<ITextLabelPool>(p => plugin.TextLabelPool);
            services.AddSingleton<IConfig>(p => plugin.Config);
            services.AddSingleton<IWorld>(p => plugin.World);
            services.AddSingleton<ILogger>(p => plugin.Logger);
            services.AddSingleton<IEventScripting>(p => plugin.EventScripting);
            services.AddSingleton<ICommands>(x => plugin.Commands);
        }
    }
}
