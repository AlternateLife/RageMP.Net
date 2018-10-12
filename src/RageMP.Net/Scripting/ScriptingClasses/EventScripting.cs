using System;
using System.Runtime.InteropServices;
using System.Text;
using RageMP.Net.Data;
using RageMP.Net.Enums;
using RageMP.Net.Helpers;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Scripting.ScriptingClasses
{
    internal class EventScripting : IEventScripting
    {
        private readonly Plugin _plugin;

        private readonly EventHandler<NativeEntityCreatedDelegate, EntityCreatedDelegate> _entityCreated;
        public event EntityCreatedDelegate EntityCreated
        {
            add => _entityCreated.Subscribe(value);
            remove => _entityCreated.Unsubscribe(value);
        }

        private readonly EventHandler<NativeEntityDestroyedDelegate, EntityDestroyedDelegate> _entityDestroyed;
        public event EntityDestroyedDelegate EntityDestroyed
        {
            add => _entityDestroyed.Subscribe(value);
            remove => _entityDestroyed.Unsubscribe(value);
        }

        private readonly EventHandler<NativeEntityModelChangeDelegate, EntityModelChangeDelegate> _entityModelChange;
        public event EntityModelChangeDelegate EntityModelChange
        {
            add => _entityModelChange.Subscribe(value);
            remove => _entityModelChange.Unsubscribe(value);
        }

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

        private readonly EventHandler<NativePlayerEnterCheckpointDelegate, PlayerEnterCheckpointDelegate> _playerEnterCheckpoint;
        public event PlayerEnterCheckpointDelegate PlayerEnterCheckpoint
        {
            add => _playerEnterCheckpoint.Subscribe(value);
            remove => _playerEnterCheckpoint.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerExitCheckpointDelegate, PlayerExitCheckpointDelegate> _playerExitCheckpoint;
        public event PlayerExitCheckpointDelegate PlayerExitCheckpoint
        {
            add => _playerExitCheckpoint.Subscribe(value);
            remove => _playerExitCheckpoint.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerEnterColshapeDelegate, PlayerEnterColshapeDelegate> _playerEnterColshape;
        public event PlayerEnterColshapeDelegate PlayerEnterColshape
        {
            add => _playerEnterColshape.Subscribe(value);
            remove => _playerEnterColshape.Unsubscribe(value);
        }

        private readonly EventHandler<NativePlayerExitColshapeDelegate, PlayerExitColshapeDelegate> _playerExitColshape;
        public event PlayerExitColshapeDelegate PlayerExitColshape
        {
            add => _playerExitColshape.Subscribe(value);
            remove => _playerExitColshape.Unsubscribe(value);
        }

        internal EventScripting(Plugin plugin)
        {
            _plugin = plugin;

            _tick = new EventHandler<NativeTickDelegate, TickDelegate>(EventType.Tick, DispatchTick);

            _entityCreated = new EventHandler<NativeEntityCreatedDelegate, EntityCreatedDelegate>(EventType.EntityCreated, DispatchEntityCreated, true);
            _entityDestroyed = new EventHandler<NativeEntityDestroyedDelegate, EntityDestroyedDelegate>(EventType.EntityDestroyed, DispatchEntityDestroyed, true);
            _entityModelChange = new EventHandler<NativeEntityModelChangeDelegate, EntityModelChangeDelegate>(EventType.EntityModelChanged, DispatchEntityModelChange);

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

            _playerEnterCheckpoint = new EventHandler<NativePlayerEnterCheckpointDelegate, PlayerEnterCheckpointDelegate>(EventType.PlayerEnterCheckpoint, DispatchPlayerEnterCheckpoint);
            _playerExitCheckpoint = new EventHandler<NativePlayerExitCheckpointDelegate, PlayerExitCheckpointDelegate>(EventType.PlayerExitCheckpoint, DispatchPlayerExitCheckpoint);

            _playerEnterColshape = new EventHandler<NativePlayerEnterColshapeDelegate, PlayerEnterColshapeDelegate>(EventType.PlayerEnterColshape, DispatchPlayerEnterColshape);
            _playerExitColshape = new EventHandler<NativePlayerExitColshapeDelegate, PlayerExitColshapeDelegate>(EventType.PlayerExitColshape, DispatchPlayerExitColshape);
        }

        private void DispatchEntityCreated(IntPtr entitypointer)
        {
            if (TryBuildEntity(entitypointer, out IEntity createdEntity) == false)
            {
                return;
            }

            _entityCreated.Call(x => x(createdEntity));
        }

        private void DispatchEntityDestroyed(IntPtr entitypointer)
        {
            TryRemoveEntity(entitypointer, entity =>
            {
                _entityDestroyed.Call(x => x(entity));
            });
        }

        private void DispatchEntityModelChange(IntPtr entitypointer, uint oldmodel)
        {
            if (TryGetEntity(entitypointer, out IEntity entity) == false)
            {
                return;
            }

            _entityModelChange.Call(x => x(entity, oldmodel));
        }

        private void DispatchTick()
        {
            _tick.Call(x => x());
        }

        private void DispatchPlayerJoin(IntPtr playerPointer)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerJoin.Call(x => x(player));
        }

        private void DispatchPlayerReady(IntPtr playerPointer)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerReady.Call(x => x(player));
        }

        private void DispatchPlayerDeath(IntPtr playerPointer, uint reason, IntPtr killerplayerpointer)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var killer = _plugin.PlayerPool[killerplayerpointer];

            _playerDeath.Call(x => x(player, reason, killer));
        }

        private void DisaptchPlayerQuit(IntPtr playerPointer, uint type, IntPtr reason)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerQuit.Call(x => x(player, type, StringConverter.PointerToString(reason)));
        }

        private void DispatchPlayerCommand(IntPtr playerPointer, IntPtr text)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerCommand.Call(x => x(player, Marshal.PtrToStringUni(text)));
        }

        private void DispatchPlayerChat(IntPtr playerPointer, IntPtr text)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerChat.Call(x => x(player, Marshal.PtrToStringUni(text)));
        }

        private void DispatchPlayerSpawn(IntPtr playerPointer)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerSpawn.Call(x => x(player));
        }

        private void DispatchPlayerDamage(IntPtr playerPointer, float healthLoss, float armorLoss)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerDamage.Call(x => x(player, healthLoss, armorLoss));
        }

        private void DispatchPlayerWeaponChange(IntPtr playerPointer, uint oldWeapon, uint newWeapon)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerWeaponChange.Call(x => x(player, oldWeapon, newWeapon));
        }

        private void DispatchStartEnterVehicle(IntPtr playerPointer, IntPtr vehiclePointer, uint seat)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            _playerStartEnterVehicle.Call(x => x(player, vehicle, seat));
        }

        private void DispatchPlayerEnterVehicle(IntPtr playerPointer, IntPtr vehiclePointer, uint seat)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            _playerEnterVehicle.Call(x => x(player, vehicle, seat));
        }

        private void DispatchStartExitVehicle(IntPtr playerPointer, IntPtr vehiclePointer)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            _playerStartExitVehicle.Call(x => x(player, vehicle));
        }

        private void DispatchPlayerExitVehicle(IntPtr playerPointer, IntPtr vehiclePointer)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            _playerExitVehicle.Call(x => x(player, vehicle));
        }

        private void DispatchPlayerEnterCheckpoint(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.CheckpointPool[checkpointPointer];

            _playerEnterCheckpoint.Call(x => x(player, checkpoint));
        }

        private void DispatchPlayerExitCheckpoint(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.CheckpointPool[checkpointPointer];

            _playerExitCheckpoint.Call(x => x(player, checkpoint));
        }

        private void DispatchPlayerEnterColshape(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.ColshapePool[checkpointPointer];

            _playerEnterColshape.Call(x => x(player, checkpoint));
        }

        private void DispatchPlayerExitColshape(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.ColshapePool[checkpointPointer];

            _playerExitColshape.Call(x => x(player, checkpoint));
        }

        private bool GetPoolFromPointer(IntPtr entityPointer, out IInternalPool pool, out EntityType type)
        {
            type = (EntityType) Rage.Entity.Entity_GetType(entityPointer);

            if (_plugin.EntityPoolMapping.TryGetValue(type, out pool) == false)
            {
                pool = null;

                return false;
            }

            return true;
        }

        private bool TryBuildEntity(IntPtr entityPointer, out IEntity createdEntity)
        {
            if (GetPoolFromPointer(entityPointer, out IInternalPool pool, out EntityType type) == false)
            {
                createdEntity = null;

                return false;
            }

            createdEntity = _plugin.BuildEntity(type, entityPointer);
            if (createdEntity == null)
            {
                return false;
            }

            return pool.AddEntity(createdEntity);
        }

        private bool TryGetEntity(IntPtr entityPointer, out IEntity entity)
        {
            if (GetPoolFromPointer(entityPointer, out IInternalPool pool, out _) == false)
            {
                entity = null;

                return false;
            }

            entity = pool.GetEntity(entityPointer);

            return entity != null;
        }

        private bool TryRemoveEntity(IntPtr entityPointer, Action<IEntity> preRemoveCallback)
        {
            if (GetPoolFromPointer(entityPointer, out IInternalPool pool, out _) == false)
            {
                return false;
            }

            return pool.RemoveEntity(entityPointer, preRemoveCallback);
        }
    }
}
