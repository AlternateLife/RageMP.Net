using System;
using System.Collections.Generic;
using System.IO;
using RageMP.Net.Entities;
using RageMP.Net.Enums;
using RageMP.Net.Helpers;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;
using RageMP.Net.Scripting;
using RageMP.Net.Scripting.ScriptingClasses;

namespace RageMP.Net
{
    internal class Plugin
    {
        private readonly string _basePath = $"dotnet{Path.DirectorySeparatorChar}";
        private ResourceLoader _resourceLoader;

        internal IntPtr NativeMultiplayer { get; }

        internal PlayerPool PlayerPool { get; }
        internal VehiclePool VehiclePool { get; }
        internal Logger Logger { get; }

        internal Dictionary<EntityType, IInternalPool> EntityPoolMapping { get; }

        public Plugin(IntPtr multiplayer)
        {
            NativeMultiplayer = multiplayer;
            Logger = new Logger(this);

            MP.Setup(this);

            PlayerPool = new PlayerPool(Rage.Multiplayer.Multiplayer_GetPlayerPool(NativeMultiplayer));
            VehiclePool = new VehiclePool(Rage.Multiplayer.Multiplayer_GetVehiclePool(NativeMultiplayer));

            EntityPoolMapping = new Dictionary<EntityType, IInternalPool>
            {
                { EntityType.Player, PlayerPool },
                { EntityType.Vehicle, VehiclePool }
            };

            Start();
        }

        private void Start()
        {
            MP.Logger.Info($"Starting Rage.NET Version {typeof(Plugin).Assembly.GetName().Version}...");

            _resourceLoader = new ResourceLoader(this);
            _resourceLoader.Start();

            MP.Logger.Info("Rage.NET startup finished");
        }

        internal IEntity BuildEntity(EntityType type, IntPtr entityPointer)
        {
            switch (type)
            {
                case EntityType.Player:
                    return new Player(entityPointer);

                case EntityType.Vehicle:
                    return new Vehicle(entityPointer);

                default:
                    return null;
            }
        }

        internal string GetBasePath(string path)
        {
            return Path.Combine(Environment.CurrentDirectory, Path.Combine(_basePath, path));
        }
    }
}
