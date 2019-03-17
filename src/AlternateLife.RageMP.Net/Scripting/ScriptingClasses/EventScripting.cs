using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.EventArgs;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Helpers.EventDispatcher;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses
{
    internal class EventScripting : IEventScripting
    {
        private readonly Plugin _plugin;
        private readonly RemoteEventHandler _remoteEventHandler;

        private readonly NativeAsyncEventDispatcher<NativeEntityCreatedDelegate, EntityEventArgs> _entityCreated;
        public event AsyncEventHandler<EntityEventArgs> EntityCreated
        {
            add => _entityCreated.Subscribe(value);
            remove => _entityCreated.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativeEntityDestroyedDelegate, EntityEventArgs> _entityDestroyed;
        public event AsyncEventHandler<EntityEventArgs> EntityDestroyed
        {
            add => _entityDestroyed.Subscribe(value);
            remove => _entityDestroyed.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativeEntityModelChangeDelegate, EntityModelEventArgs> _entityModelChange;
        public event AsyncEventHandler<EntityModelEventArgs> EntityModelChange
        {
            add => _entityModelChange.Subscribe(value);
            remove => _entityModelChange.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativeTickDelegate, System.EventArgs> _tick;
        public event AsyncEventHandler<System.EventArgs> Tick
        {
            add => _tick.Subscribe(value);
            remove => _tick.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerJoinDelegate, PlayerEventArgs> _playerJoin;
        public event AsyncEventHandler<PlayerEventArgs> PlayerJoin
        {
            add => _playerJoin.Subscribe(value);
            remove => _playerJoin.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerReadyDelegate, PlayerEventArgs> _playerReady;
        public event AsyncEventHandler<PlayerEventArgs> PlayerReady
        {
            add => _playerReady.Subscribe(value);
            remove => _playerReady.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerDeathDelegate, PlayerDeathEventArgs> _playerDeath;
        public event AsyncEventHandler<PlayerDeathEventArgs> PlayerDeath
        {
            add => _playerDeath.Subscribe(value);
            remove => _playerDeath.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerQuitDelegate, PlayerQuitDelegate> _playerQuit;
        public event PlayerQuitDelegate PlayerQuit
        {
            add => _playerQuit.Subscribe(value);
            remove => _playerQuit.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerCommandDelegate, PlayerCommandEventArgs> _playerCommand;
        public event AsyncEventHandler<PlayerCommandEventArgs> PlayerCommand
        {
            add => _playerCommand.Subscribe(value);
            remove => _playerCommand.Unsubscribe(value);
        }

        private readonly AsyncEventDispatcher<PlayerCommandFailedEventArgs> _playerCommandFailed;
        public event AsyncEventHandler<PlayerCommandFailedEventArgs> PlayerCommandFailed
        {
            add => _playerCommandFailed.Subscribe(value);
            remove => _playerCommandFailed.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerChatDelegate, PlayerChatEventArgs> _playerChat;
        public event AsyncEventHandler<PlayerChatEventArgs> PlayerChat
        {
            add => _playerChat.Subscribe(value);
            remove => _playerChat.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerSpawnDelegate, PlayerEventArgs> _playerSpawn;
        public event AsyncEventHandler<PlayerEventArgs> PlayerSpawn
        {
            add => _playerSpawn.Subscribe(value);
            remove => _playerSpawn.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerDamageDelegate, PlayerDamageEventArgs> _playerDamage;
        public event AsyncEventHandler<PlayerDamageEventArgs> PlayerDamage
        {
            add => _playerDamage.Subscribe(value);
            remove => _playerDamage.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerWeaponChangeDelegate, PlayerWeaponChangeEventArgs> _playerWeaponChange;
        public event AsyncEventHandler<PlayerWeaponChangeEventArgs> PlayerWeaponChange
        {
            add => _playerWeaponChange.Subscribe(value);
            remove => _playerWeaponChange.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerStartEnterVehicleDelegate, PlayerEnterVehicleEventArgs> _playerStartEnterVehicle;
        public event AsyncEventHandler<PlayerEnterVehicleEventArgs> PlayerStartEnterVehicle
        {
            add => _playerStartEnterVehicle.Subscribe(value);
            remove => _playerStartEnterVehicle.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerEnterVehicleDelegate, PlayerEnterVehicleEventArgs> _playerEnterVehicle;
        public event AsyncEventHandler<PlayerEnterVehicleEventArgs> PlayerEnterVehicle
        {
            add => _playerEnterVehicle.Subscribe(value);
            remove => _playerEnterVehicle.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerStartExitVehicleDelegate, PlayerVehicleEventArgs> _playerStartExitVehicle;
        public event AsyncEventHandler<PlayerVehicleEventArgs> PlayerStartExitVehicle
        {
            add => _playerStartExitVehicle.Subscribe(value);
            remove => _playerStartExitVehicle.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerExitVehicleDelegate, PlayerVehicleEventArgs> _playerExitVehicle;
        public event AsyncEventHandler<PlayerVehicleEventArgs> PlayerExitVehicle
        {
            add => _playerExitVehicle.Subscribe(value);
            remove => _playerExitVehicle.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerEnterCheckpointDelegate, PlayerCheckpointEventArgs> _playerEnterCheckpoint;
        public event AsyncEventHandler<PlayerCheckpointEventArgs> PlayerEnterCheckpoint
        {
            add => _playerEnterCheckpoint.Subscribe(value);
            remove => _playerEnterCheckpoint.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerExitCheckpointDelegate, PlayerCheckpointEventArgs> _playerExitCheckpoint;
        public event AsyncEventHandler<PlayerCheckpointEventArgs> PlayerExitCheckpoint
        {
            add => _playerExitCheckpoint.Subscribe(value);
            remove => _playerExitCheckpoint.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerEnterColshapeDelegate, PlayerColshapeEventArgs> _playerEnterColshape;
        public event AsyncEventHandler<PlayerColshapeEventArgs> PlayerEnterColshape
        {
            add => _playerEnterColshape.Subscribe(value);
            remove => _playerEnterColshape.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerExitColshapeDelegate, PlayerColshapeEventArgs> _playerExitColshape;
        public event AsyncEventHandler<PlayerColshapeEventArgs> PlayerExitColshape
        {
            add => _playerExitColshape.Subscribe(value);
            remove => _playerExitColshape.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativeVehicleDeathDelegate, VehicleDeathEventArgs> _vehicleDeath;
        public event AsyncEventHandler<VehicleDeathEventArgs> VehicleDeath
        {
            add => _vehicleDeath.Subscribe(value);
            remove => _vehicleDeath.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativeVehicleSirenToggleDelegate, VehicleToggleEventArgs> _vehicleSirenToggle;
        public event AsyncEventHandler<VehicleToggleEventArgs> VehicleSirenToggle
        {
            add => _vehicleSirenToggle.Subscribe(value);
            remove => _vehicleSirenToggle.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativeVehicleHornToggleDelegate, VehicleToggleEventArgs> _vehicleHornToggle;
        public event AsyncEventHandler<VehicleToggleEventArgs> VehicleHornToggle
        {
            add => _vehicleHornToggle.Subscribe(value);
            remove => _vehicleHornToggle.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativeVehicleTrailerAttachedDelegate, VehicleTrailerEventArgs> _vehicleTrailerAttached;
        public event AsyncEventHandler<VehicleTrailerEventArgs> VehicleTrailerAttached
        {
            add => _vehicleTrailerAttached.Subscribe(value);
            remove => _vehicleTrailerAttached.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativeVehicleDamageDelegate, VehicleDamageEventArgs> _vehicleDamage;
        public event AsyncEventHandler<VehicleDamageEventArgs> VehicleDamage
        {
            add => _vehicleDamage.Subscribe(value);
            remove => _vehicleDamage.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerCreateWaypointDelegate, PlayerCreateWaypointEventArgs> _playerCreateWaypoint;
        public event AsyncEventHandler<PlayerCreateWaypointEventArgs> PlayerCreateWaypoint
        {
            add => _playerCreateWaypoint.Subscribe(value);
            remove => _playerCreateWaypoint.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerReachWaypointDelegate, PlayerEventArgs> _playerReachWaypoint;
        public event AsyncEventHandler<PlayerEventArgs> PlayerReachWaypoint
        {
            add => _playerReachWaypoint.Subscribe(value);
            remove => _playerReachWaypoint.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerStreamInDelegate, PlayerStreamEventArgs> _playerStreamIn;
        public event AsyncEventHandler<PlayerStreamEventArgs> PlayerStreamIn
        {
            add => _playerStreamIn.Subscribe(value);
            remove => _playerStreamIn.Unsubscribe(value);
        }

        private readonly NativeAsyncEventDispatcher<NativePlayerStreamOutDelegate, PlayerStreamEventArgs> _playerStreamOut;
        public event AsyncEventHandler<PlayerStreamEventArgs> PlayerStreamOut
        {
            add => _playerStreamOut.Subscribe(value);
            remove => _playerStreamOut.Unsubscribe(value);
        }

        internal EventScripting(Plugin plugin)
        {
            _plugin = plugin;
            _remoteEventHandler = new RemoteEventHandler(plugin);

            _tick = new NativeAsyncEventDispatcher<NativeTickDelegate, System.EventArgs>(plugin, EventType.Tick, DispatchTick, true);

            _entityCreated = new NativeAsyncEventDispatcher<NativeEntityCreatedDelegate, EntityEventArgs>(plugin, EventType.EntityCreated, DispatchEntityCreated, true);
            _entityDestroyed = new NativeAsyncEventDispatcher<NativeEntityDestroyedDelegate, EntityEventArgs>(plugin, EventType.EntityDestroyed, DispatchEntityDestroyed, true);
            _entityModelChange = new NativeAsyncEventDispatcher<NativeEntityModelChangeDelegate, EntityModelEventArgs>(plugin, EventType.EntityModelChanged, DispatchEntityModelChange);

            _playerJoin = new NativeAsyncEventDispatcher<NativePlayerJoinDelegate, PlayerEventArgs>(plugin, EventType.PlayerJoin, DispatchPlayerJoin);
            _playerReady = new NativeAsyncEventDispatcher<NativePlayerReadyDelegate, PlayerEventArgs>(plugin, EventType.PlayerReady, DispatchPlayerReady);
            _playerDeath = new NativeAsyncEventDispatcher<NativePlayerDeathDelegate, PlayerDeathEventArgs>(plugin, EventType.PlayerDeath, DispatchPlayerDeath);
            _playerQuit = new NativeAsyncEventDispatcher<NativePlayerQuitDelegate, PlayerQuitDelegate>(plugin, EventType.PlayerQuit, DisaptchPlayerQuit);
            _playerCommand = new NativeAsyncEventDispatcher<NativePlayerCommandDelegate, PlayerCommandEventArgs>(plugin, EventType.PlayerCommand, DispatchPlayerCommand, true);
            _playerCommandFailed = new AsyncEventDispatcher<PlayerCommandFailedEventArgs>(plugin);
            _playerChat = new NativeAsyncEventDispatcher<NativePlayerChatDelegate, PlayerChatEventArgs>(plugin, EventType.PlayerChat, DispatchPlayerChat);
            _playerSpawn = new NativeAsyncEventDispatcher<NativePlayerSpawnDelegate, PlayerEventArgs>(plugin, EventType.PlayerSpawn, DispatchPlayerSpawn);
            _playerDamage = new NativeAsyncEventDispatcher<NativePlayerDamageDelegate, PlayerDamageEventArgs>(plugin, EventType.PlayerDamage, DispatchPlayerDamage);
            _playerWeaponChange = new NativeAsyncEventDispatcher<NativePlayerWeaponChangeDelegate, PlayerWeaponChangeEventArgs>(plugin, EventType.PlayerWeaponChange, DispatchPlayerWeaponChange);

            _playerStartEnterVehicle = new NativeAsyncEventDispatcher<NativePlayerStartEnterVehicleDelegate, PlayerEnterVehicleEventArgs>(plugin, EventType.PlayerStartEnterVehicle, DispatchStartEnterVehicle);
            _playerEnterVehicle = new NativeAsyncEventDispatcher<NativePlayerEnterVehicleDelegate, PlayerEnterVehicleEventArgs>(plugin, EventType.PlayerEnterVehicle, DispatchPlayerEnterVehicle);
            _playerStartExitVehicle = new NativeAsyncEventDispatcher<NativePlayerStartExitVehicleDelegate, PlayerVehicleEventArgs>(plugin, EventType.PlayerStartExitVehicle, DispatchStartExitVehicle);
            _playerExitVehicle = new NativeAsyncEventDispatcher<NativePlayerExitVehicleDelegate, PlayerVehicleEventArgs>(plugin, EventType.PlayerExitVehicle, DispatchPlayerExitVehicle);

            _playerEnterCheckpoint = new NativeAsyncEventDispatcher<NativePlayerEnterCheckpointDelegate, PlayerCheckpointEventArgs>(plugin, EventType.PlayerEnterCheckpoint, DispatchPlayerEnterCheckpoint);
            _playerExitCheckpoint = new NativeAsyncEventDispatcher<NativePlayerExitCheckpointDelegate, PlayerCheckpointEventArgs>(plugin, EventType.PlayerExitCheckpoint, DispatchPlayerExitCheckpoint);

            _playerEnterColshape = new NativeAsyncEventDispatcher<NativePlayerEnterColshapeDelegate, PlayerColshapeEventArgs>(plugin, EventType.PlayerEnterColshape, DispatchPlayerEnterColshape);
            _playerExitColshape = new NativeAsyncEventDispatcher<NativePlayerExitColshapeDelegate, PlayerColshapeEventArgs>(plugin, EventType.PlayerExitColshape, DispatchPlayerExitColshape);

            _playerCreateWaypoint = new NativeAsyncEventDispatcher<NativePlayerCreateWaypointDelegate, PlayerCreateWaypointEventArgs>(plugin, EventType.PlayerCreateWaypoint, DispatchPlayerCreateWaypoint);
            _playerReachWaypoint = new NativeAsyncEventDispatcher<NativePlayerReachWaypointDelegate, PlayerEventArgs>(plugin, EventType.PlayerReachWaypoint, DispatchPlayerReachWaypoint);

            _playerStreamIn = new NativeAsyncEventDispatcher<NativePlayerStreamInDelegate, PlayerStreamEventArgs>(plugin, EventType.PlayerStreamIn, DispatchPlayerStreamIn);
            _playerStreamOut = new NativeAsyncEventDispatcher<NativePlayerStreamOutDelegate, PlayerStreamEventArgs>(plugin, EventType.PlayerStreamOut, DispatchPlayerStreamOut);

            _vehicleDeath = new NativeAsyncEventDispatcher<NativeVehicleDeathDelegate, VehicleDeathEventArgs>(plugin, EventType.VehicleDeath, DispatchVehicleDeath);
            _vehicleSirenToggle = new NativeAsyncEventDispatcher<NativeVehicleSirenToggleDelegate, VehicleToggleEventArgs>(plugin, EventType.VehicleSirenToggle, DispatchVehicleSirenToggle);
            _vehicleHornToggle = new NativeAsyncEventDispatcher<NativeVehicleHornToggleDelegate, VehicleToggleEventArgs>(plugin, EventType.VehicleHornToggle, DispatchVehicleHornToggle);
            _vehicleTrailerAttached = new NativeAsyncEventDispatcher<NativeVehicleTrailerAttachedDelegate, VehicleTrailerEventArgs>(plugin, EventType.VehicleTrailerAttached, DispatchTrailerAttached);
            _vehicleDamage = new NativeAsyncEventDispatcher<NativeVehicleDamageDelegate, VehicleDamageEventArgs>(plugin, EventType.VehicleDamage, DispatchVehicleDamage);
        }

        public void Add(string eventName, AsyncEventHandler<PlayerRemoteEventEventArgs> callback)
        {
            Contract.NotEmpty(eventName, nameof(eventName));

            _remoteEventHandler.Subscribe(eventName, callback);
        }

        private void DispatchEntityCreated(IntPtr entitypointer)
        {
            if (TryBuildEntity(entitypointer, out IEntity createdEntity) == false)
            {
                return;
            }

            _entityCreated.CallAsync(this, new EntityEventArgs(createdEntity));
        }

        private void DispatchEntityDestroyed(IntPtr entitypointer)
        {
            TryRemoveEntity(entitypointer, entity =>
            {
                _entityDestroyed.CallAsync(this, new EntityEventArgs(entity));
            });
        }

        private void DispatchEntityModelChange(IntPtr entitypointer, uint oldmodel)
        {
            if (TryGetEntity(entitypointer, out IEntity entity) == false)
            {
                return;
            }

            _entityModelChange.CallAsync(this, new EntityModelEventArgs(entity, oldmodel));
        }

        private void DispatchTick()
        {
            _tick.CallAsync(this, System.EventArgs.Empty);

            _plugin.TickScheduler();
        }

        private void DispatchPlayerJoin(IntPtr playerPointer)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerJoin.CallAsync(this, new PlayerEventArgs(player));
        }

        private void DispatchPlayerReady(IntPtr playerPointer)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerReady.CallAsync(this, new PlayerEventArgs(player));
        }

        private void DispatchPlayerDeath(IntPtr playerPointer, uint reason, IntPtr killerplayerpointer)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var killer = _plugin.PlayerPool[killerplayerpointer];

            _playerDeath.CallAsync(this, new PlayerDeathEventArgs(player, reason, killer));
        }

        private void DisaptchPlayerQuit(IntPtr playerPointer, uint type, IntPtr reason)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var message = StringConverter.PointerToString(reason);

            _playerQuit.Call(x => x(player, (DisconnectReason)type, message));
        }

        private async void DispatchPlayerCommand(IntPtr playerPointer, IntPtr text)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var message = Marshal.PtrToStringUni(text);

            var eventArgs = new PlayerCommandEventArgs(player, message);

            await _playerCommand
                .CallAsyncAwaitable(this, eventArgs)
                .ConfigureAwait(false);

            if (eventArgs.Cancelled)
            {
                return;
            }

            await Task.Run(() => _plugin.Commands.ExecuteCommand(player, message))
                .ConfigureAwait(false);
        }

        internal void DispatchPlayerCommandFailed(IPlayer player, string input, CommandError error, string errorMessage)
        {
            _playerCommandFailed.CallAsync(this, new PlayerCommandFailedEventArgs(player, input, error, errorMessage));
        }

        private void DispatchPlayerChat(IntPtr playerPointer, IntPtr text)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var message = Marshal.PtrToStringUni(text);

            _playerChat.CallAsync(this, new PlayerChatEventArgs(player, message));
        }

        private void DispatchPlayerSpawn(IntPtr playerPointer)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerSpawn.CallAsync(this, new PlayerEventArgs(player));
        }

        private void DispatchPlayerDamage(IntPtr playerPointer, float healthLoss, float armorLoss)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerDamage.CallAsync(this, new PlayerDamageEventArgs(player, healthLoss, armorLoss));
        }

        private void DispatchPlayerWeaponChange(IntPtr playerPointer, uint oldWeapon, uint newWeapon)
        {
            var player = _plugin.PlayerPool[playerPointer];

            _playerWeaponChange.CallAsync(this, new PlayerWeaponChangeEventArgs(player, oldWeapon, newWeapon));
        }

        private void DispatchStartEnterVehicle(IntPtr playerPointer, IntPtr vehiclePointer, int seat)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            _playerStartEnterVehicle.CallAsync(this, new PlayerEnterVehicleEventArgs(player, vehicle, seat));
        }

        private void DispatchPlayerEnterVehicle(IntPtr playerPointer, IntPtr vehiclePointer, int seat)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            _playerEnterVehicle.CallAsync(this, new PlayerEnterVehicleEventArgs(player, vehicle, seat));
        }

        private void DispatchStartExitVehicle(IntPtr playerPointer, IntPtr vehiclePointer)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            _playerStartExitVehicle.CallAsync(this, new PlayerVehicleEventArgs(player, vehicle));
        }

        private void DispatchPlayerExitVehicle(IntPtr playerPointer, IntPtr vehiclePointer)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            _playerStartExitVehicle.CallAsync(this, new PlayerVehicleEventArgs(player, vehicle));
        }

        private void DispatchPlayerEnterCheckpoint(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.CheckpointPool[checkpointPointer];

            _playerEnterCheckpoint.CallAsync(this, new PlayerCheckpointEventArgs(player, checkpoint));
        }

        private void DispatchPlayerExitCheckpoint(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.CheckpointPool[checkpointPointer];

            _playerExitCheckpoint.CallAsync(this, new PlayerCheckpointEventArgs(player, checkpoint));
        }

        private void DispatchPlayerEnterColshape(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.ColshapePool[checkpointPointer];

            _playerEnterColshape.CallAsync(this, new PlayerColshapeEventArgs(player, checkpoint));
        }

        private void DispatchPlayerExitColshape(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.ColshapePool[checkpointPointer];

            _playerExitColshape.CallAsync(this, new PlayerColshapeEventArgs(player, checkpoint));
        }

        private void DispatchVehicleDeath(IntPtr vehiclepointer, uint reason, IntPtr killerplayerpointer)
        {
            var vehicle = _plugin.VehiclePool[vehiclepointer];
            var killerPlayer = _plugin.PlayerPool[killerplayerpointer];

            _vehicleDeath.CallAsync(this, new VehicleDeathEventArgs(vehicle, reason, killerPlayer));
        }

        private void DispatchVehicleSirenToggle(IntPtr vehiclepointer, bool toggle)
        {
            var vehicle = _plugin.VehiclePool[vehiclepointer];

            _vehicleSirenToggle.CallAsync(this, new VehicleToggleEventArgs(vehicle, toggle));
        }

        private void DispatchVehicleHornToggle(IntPtr vehiclepointer, bool toggle)
        {
            var vehicle = _plugin.VehiclePool[vehiclepointer];

            _vehicleHornToggle.CallAsync(this, new VehicleToggleEventArgs(vehicle, toggle));
        }

        private void DispatchTrailerAttached(IntPtr vehiclepointer, IntPtr trailerpointer)
        {
            var vehicle = _plugin.VehiclePool[vehiclepointer];
            var trailer = _plugin.VehiclePool[trailerpointer];

            _vehicleTrailerAttached.CallAsync(this, new VehicleTrailerEventArgs(vehicle, trailer));
        }

        private void DispatchVehicleDamage(IntPtr vehiclepointer, float bodyhealthloss, float enginehealthloss)
        {
            var vehicle = _plugin.VehiclePool[vehiclepointer];

            _vehicleDamage.CallAsync(this, new VehicleDamageEventArgs(vehicle, bodyhealthloss, enginehealthloss));
        }

        private void DispatchPlayerCreateWaypoint(IntPtr playerpointer, Vector3 position)
        {
            var player = _plugin.PlayerPool[playerpointer];

            _playerCreateWaypoint.CallAsync(this, new PlayerCreateWaypointEventArgs(player, position));
        }

        private void DispatchPlayerReachWaypoint(IntPtr playerpointer)
        {
            var player = _plugin.PlayerPool[playerpointer];

            _playerReachWaypoint.CallAsync(this, new PlayerEventArgs(player));
        }

        private void DispatchPlayerStreamIn(IntPtr playerpointer, IntPtr forplayerpointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var forPlayer = _plugin.PlayerPool[forplayerpointer];

            _playerStreamIn.CallAsync(this, new PlayerStreamEventArgs(player, forPlayer));
        }

        private void DispatchPlayerStreamOut(IntPtr playerpointer, IntPtr forplayerpointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var forPlayer = _plugin.PlayerPool[forplayerpointer];

            _playerStreamOut.CallAsync(this, new PlayerStreamEventArgs(player, forPlayer));
        }

        private bool GetPoolFromPointer(IntPtr entityPointer, out IInternalPool pool, out EntityType type)
        {
            type = (EntityType) Rage.Entity.Entity_GetType(entityPointer);

            if (_plugin.TryGetPool(type, out pool) == false)
            {
                pool = null;

                return false;
            }

            return true;
        }

        private bool TryBuildEntity(IntPtr entityPointer, out IEntity createdEntity)
        {
            if (GetPoolFromPointer(entityPointer, out IInternalPool pool, out _) == false)
            {
                createdEntity = null;

                return false;
            }

            return pool.CreateAndSaveEntity(entityPointer, out createdEntity);
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

        private void TryRemoveEntity(IntPtr entityPointer, Action<IEntity> preRemoveCallback)
        {
            if (GetPoolFromPointer(entityPointer, out IInternalPool pool, out _) == false)
            {
                return;
            }

            pool.RemoveEntity(entityPointer, preRemoveCallback);
        }
    }
}
