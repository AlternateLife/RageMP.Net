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
            services.AddSingleton<IPlayerPool, PlayerPool>(p => plugin.PlayerPool);
            services.AddSingleton<IVehiclePool, VehiclePool>(p => plugin.VehiclePool);
            services.AddSingleton<IBlipPool, BlipPool>(p => plugin.BlipPool);
            services.AddSingleton<ICheckpointPool, CheckpointPool>(p => plugin.CheckpointPool);
            services.AddSingleton<IColshapePool, ColshapePool>(p => plugin.ColshapePool);
            services.AddSingleton<IMarkerPool, MarkerPool>(p => plugin.MarkerPool);
            services.AddSingleton<IObjectPool, ObjectPool>(p => plugin.ObjectPool);
            services.AddSingleton<ITextLabelPool, TextLabelPool>(p => plugin.TextLabelPool);
            services.AddSingleton<IConfig, Config>(p => plugin.Config);
            services.AddSingleton<IWorld, World>(p => plugin.World);
            services.AddSingleton<ILogger, Logger>(p => plugin.Logger);
            services.AddSingleton<IEventScripting, EventScripting>(p => plugin.EventScripting);
            services.AddSingleton<ICommands>(x => plugin.Commands);
        }
    }
}
