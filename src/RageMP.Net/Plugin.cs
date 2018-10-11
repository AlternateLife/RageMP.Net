using System;
using System.Collections.Generic;
using System.IO;
using RageMP.Net.Entities;
using RageMP.Net.Enums;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;
using RageMP.Net.Scripting;
using RageMP.Net.Scripting.ScriptingClasses;

namespace RageMP.Net
{
    internal class Plugin
    {
        private ResourceLoader _resourceLoader;

        internal IntPtr NativeMultiplayer { get; }

        internal PlayerPool PlayerPool { get; }
        internal VehiclePool VehiclePool { get; }

        internal Dictionary<EntityType, IInternalPool> EntityPoolMapping { get; }

        public Plugin(IntPtr multiplayer)
        {
            NativeMultiplayer = multiplayer;

            MP.Setup(this);

            PlayerPool = new PlayerPool(Rage.Multiplayer.Multiplayer_GetPlayerPool(NativeMultiplayer));
            VehiclePool = new VehiclePool(Rage.Multiplayer.Multiplayer_GetVehiclePool(NativeMultiplayer));

            EntityPoolMapping = new Dictionary<EntityType, IInternalPool>
            {
                { EntityType.Player, PlayerPool },
                { EntityType.Vehicle, VehiclePool }
            };

            _resourceLoader = new ResourceLoader(this);
            _resourceLoader.Start();
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
    }
}
