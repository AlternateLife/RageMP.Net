using System;
using System.Runtime.InteropServices;
using RageMP.Net.Entities;
using RageMP.Net.Enums;
using RageMP.Net.Helpers;
using RageMP.Net.Interfaces;

namespace RageMP.Net.Scripting.ScriptingClasses
{
    public class EventScripting : IEventScripting
    {
        private readonly EventHandler<NativeTickDelegate, TickDelegate> _tick;
        public event TickDelegate Tick
        {
            add => _tick.Subscribe(value);
            remove => _tick.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerJoinDelegate, PlayerJoinDelegate> _playerJoin;
        public event PlayerJoinDelegate PlayerJoin
        {
            add => _playerJoin.Subscribe(value);
            remove => _playerJoin.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerReadyDelegate, PlayerReadyDelegate> _playerReady;
        public event PlayerReadyDelegate PlayerReady
        {
            add => _playerReady.Subscribe(value);
            remove => _playerReady.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerDeathDelegate, PlayerDeathDelegate> _playerDeath;

        public event PlayerDeathDelegate PlayerDeath
        {
            add => _playerDeath.Subscribe(value);
            remove => _playerDeath.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerQuitDelegate, PlayerQuitDelegate> _playerQuit;
        public event PlayerQuitDelegate PlayerQuit
        {
            add => _playerQuit.Subscribe(value);
            remove => _playerQuit.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerCommandDelegate, PlayerCommandDelegate> _playerCommand;

        public event PlayerCommandDelegate PlayerCommand
        {
            add => _playerCommand.Subscribe(value);
            remove => _playerCommand.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerChatDelegate, PlayerChatDelegate> _playerChat;
        public event PlayerChatDelegate PlayerChat
        {
            add => _playerChat.Subscribe(value);
            remove => _playerChat.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerSpawnDelegate, PlayerSpawnDelegate> _playerSpawn;
        public event PlayerSpawnDelegate PlayerSpawn
        {
            add => _playerSpawn.Subscribe(value);
            remove => _playerSpawn.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerDamageDelegate, PlayerDamageDelegate> _playerDamage;
        public event PlayerDamageDelegate PlayerDamage
        {
            add => _playerDamage.Subscribe(value);
            remove => _playerDamage.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerWeaponChangeDelegate, PlayerWeaponChangeDelegate> _playerWeaponChange;
        public event PlayerWeaponChangeDelegate PlayerWeaponChange
        {
            add => _playerWeaponChange.Subscribe(value);
            remove => _playerWeaponChange.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerStartEnterVehicleDelegate, PlayerStartEnterVehicleDelegate> _playerStartEnterVehicle;
        public event PlayerStartEnterVehicleDelegate PlayerStartEnterVehicle
        {
            add => _playerStartEnterVehicle.Subscribe(value);
            remove => _playerStartEnterVehicle.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerEnterVehicleDelegate, PlayerEnterVehicleDelegate> _playerEnterVehicle;
        public event PlayerEnterVehicleDelegate PlayerEnterVehicle
        {
            add => _playerEnterVehicle.Subscribe(value);
            remove => _playerEnterVehicle.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerStartExitVehicleDelegate, PlayerStartExitVehicleDelegate> _playerStartExitVehicle;
        public event PlayerStartExitVehicleDelegate PlayerStartExitVehicle
        {
            add => _playerStartExitVehicle.Subscribe(value);
            remove => _playerStartExitVehicle.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerExitVehicleDelegate, PlayerExitVehicleDelegate> _playerExitVehicle;
        public event PlayerExitVehicleDelegate PlayerExitVehicle
        {
            add => _playerExitVehicle.Subscribe(value);
            remove => _playerExitVehicle.Unsubscribe(value);
        }

        public EventScripting()
        {
            _tick = new EventHandler<NativeTickDelegate, TickDelegate>(EventType.Tick, DispatchTick);
            _playerJoin = new EventHandler<NativePlayerJoinDelegate, PlayerJoinDelegate>(EventType.PlayerJoin, DispatchPlayerJoin);
            _playerReady = new EventHandler<NativePlayerReadyDelegate, PlayerReadyDelegate>(EventType.PlayerReady, DispatchPlayerReady);
            _playerDeath = new EventHandler<NativePlayerDeathDelegate, PlayerDeathDelegate>(EventType.PlayerDeath, DispatchPlayerDeath);
            _playerQuit = new EventHandler<NativePlayerQuitDelegate, PlayerQuitDelegate>(EventType.PlayerQuit, DisaptchPlayerQuit);
            _playerCommand = new EventHandler<NativePlayerCommandDelegate, PlayerCommandDelegate>(EventType.PlayerCommand, DispatchPlayerCommand);
            _playerChat = new EventHandler<NativePlayerChatDelegate, PlayerChatDelegate>(EventType.PlayerChat, DispatchPlayerChat);
            _playerSpawn = new EventHandler<NativePlayerSpawnDelegate, PlayerSpawnDelegate>(EventType.PlayerSpawn, DispatchPlayerSpawn);
            _playerDamage = new EventHandler<NativePlayerDamageDelegate, PlayerDamageDelegate>(EventType.PlayerDamage, DispatchPlayerDamage);
            _playerWeaponChange = new EventHandler<NativePlayerWeaponChangeDelegate, PlayerWeaponChangeDelegate>(EventType.PlayerWeaponChange, DispatchPlayerWeaponChange);
            _playerStartEnterVehicle = new EventHandler<NativePlayerStartEnterVehicleDelegate, PlayerStartEnterVehicleDelegate>(EventType.PlayerStartEnterVehicle, DispatchStartEnterVehicle);
            _playerEnterVehicle = new EventHandler<NativePlayerEnterVehicleDelegate, PlayerEnterVehicleDelegate>(EventType.PlayerEnterVehicle, DispatchPlayerEnterVehicle);
            _playerStartExitVehicle = new EventHandler<NativePlayerStartExitVehicleDelegate, PlayerStartExitVehicleDelegate>(EventType.PlayerStartExitVehicle, DispatchStartExitVehicle);
            _playerExitVehicle = new EventHandler<NativePlayerExitVehicleDelegate, PlayerExitVehicleDelegate>(EventType.PlayerExitVehicle, DispatchPlayerExitVehicle);
        }

        private void DispatchTick()
        {
            _tick.Call(x => x());
        }

        private void DispatchPlayerJoin(IntPtr playerPointer)
        {
            var player = new Player(playerPointer);

            _playerJoin.Call(x => x(player));
        }

        private void DispatchPlayerReady(IntPtr playerPointer)
        {
            var player = new Player(playerPointer);

            _playerReady.Call(x => x(player));
        }

        private void DispatchPlayerDeath(IntPtr playerPointer, uint reason, IntPtr killerplayerpointer)
        {
            var player = new Player(playerPointer);
            var killer = new Player(killerplayerpointer);

            _playerDeath.Call(x => x(player, reason, killer));
        }

        private void DisaptchPlayerQuit(IntPtr playerPointer, uint type, string reason)
        {
            var player = new Player(playerPointer);

            _playerQuit.Call(x => x(player, type, reason));
        }

        private void DispatchPlayerCommand(IntPtr playerPointer, IntPtr text)
        {
            var player = new Player(playerPointer);

            _playerCommand.Call(x => x(player, Marshal.PtrToStringUni(text)));
        }

        private void DispatchPlayerChat(IntPtr playerPointer, IntPtr text)
        {
            var player = new Player(playerPointer);

            _playerChat.Call(x => x(player, Marshal.PtrToStringUni(text)));
        }

        private void DispatchPlayerSpawn(IntPtr playerPointer)
        {
            var player = new Player(playerPointer);

            _playerSpawn.Call(x => x(player));
        }

        private void DispatchPlayerDamage(IntPtr playerPointer, float healthLoss, float armorLoss)
        {
            var player = new Player(playerPointer);

            _playerDamage.Call(x => x(player, healthLoss, armorLoss));
        }

        private void DispatchPlayerWeaponChange(IntPtr playerPointer, uint oldWeapon, uint newWeapon)
        {
            var player = new Player(playerPointer);

            _playerWeaponChange.Call(x => x(player, oldWeapon, newWeapon));
        }

        private void DispatchStartEnterVehicle(IntPtr playerPointer, IntPtr vehiclepointer, uint seat)
        {
            var player = new Player(playerPointer);

            _playerStartEnterVehicle.Call(x => x(player, null, seat));
        }

        private void DispatchPlayerEnterVehicle(IntPtr playerPointer, IntPtr vehiclepointer, uint seat)
        {
            var player = new Player(playerPointer);

            _playerEnterVehicle.Call(x => x(player, null, seat));
        }

        private void DispatchStartExitVehicle(IntPtr playerPointer, IntPtr vehiclepointer)
        {
            var player = new Player(playerPointer);

            _playerStartExitVehicle.Call(x => x(player, null));
        }

        private void DispatchPlayerExitVehicle(IntPtr playerPointer, IntPtr vehiclepointer)
        {
            var player = new Player(playerPointer);

            _playerExitVehicle.Call(x => x(player, null));
        }
    }
}
