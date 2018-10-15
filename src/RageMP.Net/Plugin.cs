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
using Object = RageMP.Net.Entities.Object;

namespace RageMP.Net
{
    internal class Plugin
    {
        private readonly string _basePath = $"dotnet{Path.DirectorySeparatorChar}";
        private ResourceLoader _resourceLoader;

        internal IntPtr NativeMultiplayer { get; }

        internal PlayerPool PlayerPool { get; }
        internal VehiclePool VehiclePool { get; }
        internal BlipPool BlipPool { get; }
        internal CheckpointPool CheckpointPool { get; }
        internal ColshapePool ColshapePool { get; }
        internal MarkerPool MarkerPool { get; }
        internal ObjectPool ObjectPool { get; }
        internal TextLabelPool TextLabelPool { get; }
        internal Config Config { get; }

        internal Logger Logger { get; }

        internal Dictionary<EntityType, IInternalPool> EntityPoolMapping { get; }

        internal Plugin(IntPtr multiplayer)
        {
            NativeMultiplayer = multiplayer;
            Logger = new Logger(this);

            MP.Setup(this);

            PlayerPool = new PlayerPool(Rage.Multiplayer.Multiplayer_GetPlayerPool(NativeMultiplayer), this);
            VehiclePool = new VehiclePool(Rage.Multiplayer.Multiplayer_GetVehiclePool(NativeMultiplayer), this);
            BlipPool = new BlipPool(Rage.Multiplayer.Multiplayer_GetBlipPool(NativeMultiplayer), this);
            CheckpointPool = new CheckpointPool(Rage.Multiplayer.Multiplayer_GetCheckpointPool(NativeMultiplayer), this);
            ColshapePool = new ColshapePool(Rage.Multiplayer.Multiplayer_GetColshapePool(NativeMultiplayer), this);
            MarkerPool = new MarkerPool(Rage.Multiplayer.Multiplayer_GetMarkerPool(NativeMultiplayer), this);
            ObjectPool = new ObjectPool(Rage.Multiplayer.Multiplayer_GetObjectPool(NativeMultiplayer), this);
            TextLabelPool = new TextLabelPool(Rage.Multiplayer.Multiplayer_GetLabelPool(NativeMultiplayer), this);
            Config = new Config(Rage.Multiplayer.Multiplayer_GetConfig(NativeMultiplayer), this);

            EntityPoolMapping = new Dictionary<EntityType, IInternalPool>
            {
                { EntityType.Player, PlayerPool },
                { EntityType.Vehicle, VehiclePool },
                { EntityType.Blip, BlipPool },
                { EntityType.Checkpoint, CheckpointPool },
                { EntityType.Colshape, ColshapePool },
                { EntityType.Marker, MarkerPool },
                { EntityType.Object, ObjectPool },
                { EntityType.TextLabel, TextLabelPool }
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

        internal string GetBasePath(string path)
        {
            return Path.Combine(Environment.CurrentDirectory, Path.Combine(_basePath, path));
        }
    }
}
