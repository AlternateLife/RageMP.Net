using System;
using System.Collections.Generic;
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

            MP.Events.PlayerChat += OnPlayerChat;
            MP.Events.PlayerEnterVehicle += PlayerEnterVehicle;
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

        private void PlayerEnterVehicle(IPlayer player, IVehicle vehicle, uint seat)
        {
            player.OutputChatBox($"Du hast das Fahrzeug {vehicle.Model} betreten! (Sitz: {seat}");
        }

        private void OnPlayerChat(IPlayer player, string text)
        {
            Console.WriteLine($"{nameof(OnPlayerChat)}: {player.Name}, {text}, {player.Position}");

            player.GiveWeapon(0x97EA20B8, 100);

            //player.Call("TEST", "cello", 1, 1.2, new Vector3(-1388.594f, -586.711f, 30.219f));

            var vehicle = MP.Vehicles.New(2364918497, player.Position, player.Rotation.Z, "LEL", 255, false, false, uint.MaxValue);

            Console.WriteLine($"Dimension: P: {player.Dimension} - V: {vehicle.Dimension}");

            player.Position = vehicle.Position;
            player.Dimension = vehicle.Dimension;

            player.PutIntoVehicle(vehicle, -1);

            MP.Players.Broadcast("LEL");

            foreach (var otherPlayer in MP.Players)
            {
                otherPlayer.OutputChatBox("HEH");
            }
        }
    }
}
