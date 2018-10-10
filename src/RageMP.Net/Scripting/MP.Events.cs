using System;
using RageMP.Net.Entities;
using RageMP.Net.Enums;
using RageMP.Net.Helpers;

namespace RageMP.Net.Scripting
{
    public static partial class MP
    {
        public static class Events
        {
            private static readonly EventHandler<NativeTickDelegate, TickDelegate> _tick
                = new EventHandler<NativeTickDelegate, TickDelegate>(EventType.Tick, DispatchTick);

            public static event TickDelegate Tick
            {
                add => _tick.Subscribe(value);
                remove => _tick.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerJoinDelegate, PlayerJoinDelegate> _playerJoin
                = new EventHandler<NativePlayerJoinDelegate, PlayerJoinDelegate>(EventType.PlayerJoin, DispatchPlayerJoin);

            public static event PlayerJoinDelegate PlayerJoin
            {
                add => _playerJoin.Subscribe(value);
                remove => _playerJoin.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerReadyDelegate, PlayerReadyDelegate> _playerReady
                = new EventHandler<NativePlayerReadyDelegate, PlayerReadyDelegate>(EventType.PlayerReady, DispatchPlayerReady);

            public static event PlayerReadyDelegate PlayerReady
            {
                add => _playerReady.Subscribe(value);
                remove => _playerReady.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerDeathDelegate, PlayerDeathDelegate> _playerDeath
                = new EventHandler<NativePlayerDeathDelegate, PlayerDeathDelegate>(EventType.PlayerDeath, DispatchPlayerDeath);

            public static event PlayerDeathDelegate PlayerDeath
            {
                add => _playerDeath.Subscribe(value);
                remove => _playerDeath.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerQuitDelegate, PlayerQuitDelegate> _playerQuit
                = new EventHandler<NativePlayerQuitDelegate, PlayerQuitDelegate>(EventType.PlayerQuit, DisaptchPlayerQuit);

            public static event PlayerQuitDelegate PlayerQuit
            {
                add => _playerQuit.Subscribe(value);
                remove => _playerQuit.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerCommandDelegate, PlayerCommandDelegate> _playerCommand
                = new EventHandler<NativePlayerCommandDelegate, PlayerCommandDelegate>(EventType.PlayerCommand, DispatchPlayerCommand);

            public static event PlayerCommandDelegate PlayerCommand
            {
                add => _playerCommand.Subscribe(value);
                remove => _playerCommand.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerChatDelegate, PlayerChatDelegate> _playerChat
                = new EventHandler<NativePlayerChatDelegate, PlayerChatDelegate>(EventType.PlayerChat, DispatchPlayerChat);

            public static event PlayerChatDelegate PlayerChat
            {
                add => _playerChat.Subscribe(value);
                remove => _playerChat.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerSpawnDelegate, PlayerSpawnDelegate> _playerSpawn
                = new EventHandler<NativePlayerSpawnDelegate, PlayerSpawnDelegate>(EventType.PlayerSpawn, DispatchPlayerSpawn);

            public static event PlayerSpawnDelegate PlayerSpawn
            {
                add => _playerSpawn.Subscribe(value);
                remove => _playerSpawn.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerDamageDelegate, PlayerDamageDelegate> _playerDamage
                = new EventHandler<NativePlayerDamageDelegate, PlayerDamageDelegate>(EventType.PlayerDamage, DispatchPlayerDamage);

            public static event PlayerDamageDelegate PlayerDamage
            {
                add => _playerDamage.Subscribe(value);
                remove => _playerDamage.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerWeaponChangeDelegate, PlayerWeaponChangeDelegate> _playerWeaponChange
                = new EventHandler<NativePlayerWeaponChangeDelegate, PlayerWeaponChangeDelegate>(EventType.PlayerWeaponChange, DispatchPlayerWeaponChange);

            public static event PlayerWeaponChangeDelegate PlayerWeaponChange
            {
                add => _playerWeaponChange.Subscribe(value);
                remove => _playerWeaponChange.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerStartEnterVehicleDelegate, PlayerStartEnterVehicleDelegate> _playerStartEnterVehicle
                = new EventHandler<NativePlayerStartEnterVehicleDelegate, PlayerStartEnterVehicleDelegate>(EventType.PlayerStartEnterVehicle, DispatchStartEnterVehicle);

            public static event PlayerStartEnterVehicleDelegate PlayerStartEnterVehicle
            {
                add => _playerStartEnterVehicle.Subscribe(value);
                remove => _playerStartEnterVehicle.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerEnterVehicleDelegate, PlayerEnterVehicleDelegate> _playerEnterVehicle
                = new EventHandler<NativePlayerEnterVehicleDelegate, PlayerEnterVehicleDelegate>(EventType.PlayerEnterVehicle, DispatchPlayerEnterVehicle);

            public static event PlayerEnterVehicleDelegate PlayerEnterVehicle
            {
                add => _playerEnterVehicle.Subscribe(value);
                remove => _playerEnterVehicle.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerStartExitVehicleDelegate, PlayerStartExitVehicleDelegate> _playerStartExitVehicle
                = new EventHandler<NativePlayerStartExitVehicleDelegate, PlayerStartExitVehicleDelegate>(EventType.PlayerStartExitVehicle, DispatchStartExitVehicle);

            public static event PlayerStartExitVehicleDelegate PlayerStartExitVehicle
            {
                add => _playerStartExitVehicle.Subscribe(value);
                remove => _playerStartExitVehicle.Unsubscribe(value);
            }

            private static readonly EventHandler<NativePlayerExitVehicleDelegate, PlayerExitVehicleDelegate> _playerExitVehicle
                = new EventHandler<NativePlayerExitVehicleDelegate, PlayerExitVehicleDelegate>(EventType.PlayerExitVehicle, DispatchPlayerExitVehicle);

            public static event PlayerExitVehicleDelegate PlayerExitVehicle
            {
                add => _playerExitVehicle.Subscribe(value);
                remove => _playerExitVehicle.Unsubscribe(value);
            }

            private static void DispatchTick()
            {
                _tick.Call(x => x());
            }

            private static void DispatchPlayerJoin(IntPtr playerPointer)
            {
                var player = new Player(playerPointer);

                _playerJoin.Call(x => x(player));
            }

            private static void DispatchPlayerReady(IntPtr playerPointer)
            {
                var player = new Player(playerPointer);

                _playerReady.Call(x => x(player));
            }

            private static void DispatchPlayerDeath(IntPtr playerPointer, uint reason, IntPtr killerplayerpointer)
            {
                var player = new Player(playerPointer);
                var killer = new Player(killerplayerpointer);

                _playerDeath.Call(x => x(player, reason, killer));
            }

            private static void DisaptchPlayerQuit(IntPtr playerPointer, uint type, string reason)
            {
                var player = new Player(playerPointer);

                _playerQuit.Call(x => x(player, type, reason));
            }

            private static void DispatchPlayerCommand(IntPtr playerPointer, string text)
            {
                var player = new Player(playerPointer);

                _playerCommand.Call(x => x(player, text));
            }

            private static void DispatchPlayerChat(IntPtr playerPointer, string text)
            {
                var player = new Player(playerPointer);

                _playerChat.Call(x => x(player, text));
            }

            private static void DispatchPlayerSpawn(IntPtr playerPointer)
            {
                var player = new Player(playerPointer);

                _playerSpawn.Call(x => x(player));
            }

            private static void DispatchPlayerDamage(IntPtr playerPointer, float healthLoss, float armorLoss)
            {
                var player = new Player(playerPointer);

                _playerDamage.Call(x => x(player, healthLoss, armorLoss));
            }

            private static void DispatchPlayerWeaponChange(IntPtr playerPointer, uint oldWeapon, uint newWeapon)
            {
                var player = new Player(playerPointer);

                _playerWeaponChange.Call(x => x(player, oldWeapon, newWeapon));
            }

            private static void DispatchStartEnterVehicle(IntPtr playerPointer, IntPtr vehiclepointer, uint seat)
            {
                var player = new Player(playerPointer);

                _playerStartEnterVehicle.Call(x => x(player, null, seat));
            }

            private static void DispatchPlayerEnterVehicle(IntPtr playerPointer, IntPtr vehiclepointer, uint seat)
            {
                var player = new Player(playerPointer);

                _playerEnterVehicle.Call(x => x(player, null, seat));
            }

            private static void DispatchStartExitVehicle(IntPtr playerPointer, IntPtr vehiclepointer)
            {
                var player = new Player(playerPointer);

                _playerStartExitVehicle.Call(x => x(player, null));
            }

            private static void DispatchPlayerExitVehicle(IntPtr playerPointer, IntPtr vehiclepointer)
            {
                var player = new Player(playerPointer);

                _playerExitVehicle.Call(x => x(player, null));
            }
        }
    }
}
