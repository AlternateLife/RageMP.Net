using System;
using System.Collections.Generic;
using System.IO;
using RageMP.Net.Data;
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
        internal BlipPool BlipPool { get; }
        internal CheckpointPool CheckpointPool { get; }
        internal ColshapePool ColshapePool { get; }
        internal MarkerPool MarkerPool { get; }

        internal Logger Logger { get; }

        internal Dictionary<EntityType, IInternalPool> EntityPoolMapping { get; }

        public Plugin(IntPtr multiplayer)
        {
            NativeMultiplayer = multiplayer;
            Logger = new Logger(this);

            Rage.Multiplayer.Multiplayer_AddRemoteEventHandler(multiplayer, "RAGE", RemoteEvent);

            MP.Setup(this);

            PlayerPool = new PlayerPool(Rage.Multiplayer.Multiplayer_GetPlayerPool(NativeMultiplayer));
            VehiclePool = new VehiclePool(Rage.Multiplayer.Multiplayer_GetVehiclePool(NativeMultiplayer));
            BlipPool = new BlipPool(Rage.Multiplayer.Multiplayer_GetBlipPool(NativeMultiplayer));
            CheckpointPool = new CheckpointPool(Rage.Multiplayer.Multiplayer_GetCheckpointPool(NativeMultiplayer));
            ColshapePool = new ColshapePool(Rage.Multiplayer.Multiplayer_GetColshapePool(NativeMultiplayer));
            MarkerPool = new MarkerPool(Rage.Multiplayer.Multiplayer_GetMarkerPool(NativeMultiplayer));

            EntityPoolMapping = new Dictionary<EntityType, IInternalPool>
            {
                { EntityType.Player, PlayerPool },
                { EntityType.Vehicle, VehiclePool },
                { EntityType.Blip, BlipPool },
                { EntityType.Checkpoint, CheckpointPool },
                { EntityType.Colshape, ColshapePool },
                { EntityType.Marker, MarkerPool }
            };

            Start();
        }

        private void RemoteEvent(IntPtr playerPointer, ArgumentsData arguments)
        {
            MP.Logger.Info($"Remote event called: Length {arguments.Length}");

            for (ulong i = 0; i < arguments.Length; i++)
            {
                var argument = arguments.Arguments[i];

                MP.Logger.Info($"Argument: {argument.Int32Value}");
            }
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

                case EntityType.Blip:
                    return new Blip(entityPointer);

                case EntityType.Checkpoint:
                    return new Checkpoint(entityPointer);

                case EntityType.Colshape:
                    return new Colshape(entityPointer);

                case EntityType.Marker:
                    return new Marker(entityPointer);

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
