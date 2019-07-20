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

        internal NativeAsyncEventDispatcher<NativeEntityCreatedDelegate, EntityEventArgs> EntityCreatedDispatcher { get; }
        public event AsyncEventHandler<EntityEventArgs> EntityCreated
        {
            add => EntityCreatedDispatcher.Subscribe(value, out _);
            remove => EntityCreatedDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativeEntityDestroyedDelegate, EntityEventArgs> EntityDestroyedDispatcher { get; }
        public event AsyncEventHandler<EntityEventArgs> EntityDestroyed
        {
            add => EntityDestroyedDispatcher.Subscribe(value, out _);
            remove => EntityDestroyedDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativeEntityModelChangeDelegate, EntityModelEventArgs> EntityModelChangeDispatcher { get; }
        public event AsyncEventHandler<EntityModelEventArgs> EntityModelChange
        {
            add => EntityModelChangeDispatcher.Subscribe(value, out _);
            remove => EntityModelChangeDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativeTickDelegate, System.EventArgs> TickDispatcher { get; }
        public event AsyncEventHandler<System.EventArgs> Tick
        {
            add => TickDispatcher.Subscribe(value, out _);
            remove => TickDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerJoinDelegate, PlayerEventArgs> PlayerJoinDispatcher { get; }
        public event AsyncEventHandler<PlayerEventArgs> PlayerJoin
        {
            add => PlayerJoinDispatcher.Subscribe(value, out _);
            remove => PlayerJoinDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerReadyDelegate, PlayerEventArgs> PlayerReadyDispatcher { get; }
        public event AsyncEventHandler<PlayerEventArgs> PlayerReady
        {
            add => PlayerReadyDispatcher.Subscribe(value, out _);
            remove => PlayerReadyDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerDeathDelegate, PlayerDeathEventArgs> PlayerDeathDispatcher { get; }
        public event AsyncEventHandler<PlayerDeathEventArgs> PlayerDeath
        {
            add => PlayerDeathDispatcher.Subscribe(value, out _);
            remove => PlayerDeathDispatcher.Unsubscribe(value, out _);
        }

        internal NativeSyncEventDispatcher<NativePlayerQuitDelegate, PlayerQuitEventArgs> PlayerQuitDispatcher { get; }
        public event EventHandler<PlayerQuitEventArgs> PlayerQuit
        {
            add => PlayerQuitDispatcher.Subscribe(value, out _);
            remove => PlayerQuitDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerCommandDelegate, PlayerCommandEventArgs> PlayerCommandDispatcher { get; }
        public event AsyncEventHandler<PlayerCommandEventArgs> PlayerCommand
        {
            add => PlayerCommandDispatcher.Subscribe(value, out _);
            remove => PlayerCommandDispatcher.Unsubscribe(value, out _);
        }

        internal AsyncEventDispatcher<PlayerCommandFailedEventArgs> PlayerCommandFailedDispatcher { get; }
        public event AsyncEventHandler<PlayerCommandFailedEventArgs> PlayerCommandFailed
        {
            add => PlayerCommandFailedDispatcher.Subscribe(value, out _);
            remove => PlayerCommandFailedDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerChatDelegate, PlayerChatEventArgs> PlayerChatDispatcher { get; }
        public event AsyncEventHandler<PlayerChatEventArgs> PlayerChat
        {
            add => PlayerChatDispatcher.Subscribe(value, out _);
            remove => PlayerChatDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerSpawnDelegate, PlayerEventArgs> PlayerSpawnDispatcher { get; }
        public event AsyncEventHandler<PlayerEventArgs> PlayerSpawn
        {
            add => PlayerSpawnDispatcher.Subscribe(value, out _);
            remove => PlayerSpawnDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerDamageDelegate, PlayerDamageEventArgs> PlayerDamageDispatcher { get; }
        public event AsyncEventHandler<PlayerDamageEventArgs> PlayerDamage
        {
            add => PlayerDamageDispatcher.Subscribe(value, out _);
            remove => PlayerDamageDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerWeaponChangeDelegate, PlayerWeaponChangeEventArgs> PlayerWeaponChangeDispatcher { get; }
        public event AsyncEventHandler<PlayerWeaponChangeEventArgs> PlayerWeaponChange
        {
            add => PlayerWeaponChangeDispatcher.Subscribe(value, out _);
            remove => PlayerWeaponChangeDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerStartEnterVehicleDelegate, PlayerEnterVehicleEventArgs> PlayerStartEnterVehicleDispatcher { get; }
        public event AsyncEventHandler<PlayerEnterVehicleEventArgs> PlayerStartEnterVehicle
        {
            add => PlayerStartEnterVehicleDispatcher.Subscribe(value, out _);
            remove => PlayerStartEnterVehicleDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerEnterVehicleDelegate, PlayerEnterVehicleEventArgs> PlayerEnterVehicleDispatcher { get; }
        public event AsyncEventHandler<PlayerEnterVehicleEventArgs> PlayerEnterVehicle
        {
            add => PlayerEnterVehicleDispatcher.Subscribe(value, out _);
            remove => PlayerEnterVehicleDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerStartExitVehicleDelegate, PlayerVehicleEventArgs> PlayerStartExitVehicleDispatcher { get; }
        public event AsyncEventHandler<PlayerVehicleEventArgs> PlayerStartExitVehicle
        {
            add => PlayerStartExitVehicleDispatcher.Subscribe(value, out _);
            remove => PlayerStartExitVehicleDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerExitVehicleDelegate, PlayerVehicleEventArgs> PlayerExitVehicleDispatcher { get; }
        public event AsyncEventHandler<PlayerVehicleEventArgs> PlayerExitVehicle
        {
            add => PlayerExitVehicleDispatcher.Subscribe(value, out _);
            remove => PlayerExitVehicleDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerEnterCheckpointDelegate, PlayerCheckpointEventArgs> PlayerEnterCheckpointDispatcher { get; }
        public event AsyncEventHandler<PlayerCheckpointEventArgs> PlayerEnterCheckpoint
        {
            add => PlayerEnterCheckpointDispatcher.Subscribe(value, out _);
            remove => PlayerEnterCheckpointDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerExitCheckpointDelegate, PlayerCheckpointEventArgs> PlayerExitCheckpointDispatcher { get; }
        public event AsyncEventHandler<PlayerCheckpointEventArgs> PlayerExitCheckpoint
        {
            add => PlayerExitCheckpointDispatcher.Subscribe(value, out _);
            remove => PlayerExitCheckpointDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerEnterColshapeDelegate, PlayerColshapeEventArgs> PlayerEnterColshapeDispatcher { get; }
        public event AsyncEventHandler<PlayerColshapeEventArgs> PlayerEnterColshape
        {
            add => PlayerEnterColshapeDispatcher.Subscribe(value, out _);
            remove => PlayerEnterColshapeDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerExitColshapeDelegate, PlayerColshapeEventArgs> PlayerExitColshapeDispatcher { get; }
        public event AsyncEventHandler<PlayerColshapeEventArgs> PlayerExitColshape
        {
            add => PlayerExitColshapeDispatcher.Subscribe(value, out _);
            remove => PlayerExitColshapeDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativeVehicleDeathDelegate, VehicleDeathEventArgs> VehicleDeathDispatcher { get; }
        public event AsyncEventHandler<VehicleDeathEventArgs> VehicleDeath
        {
            add => VehicleDeathDispatcher.Subscribe(value, out _);
            remove => VehicleDeathDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativeVehicleSirenToggleDelegate, VehicleToggleEventArgs> VehicleSirenToggleDispatcher { get; }
        public event AsyncEventHandler<VehicleToggleEventArgs> VehicleSirenToggle
        {
            add => VehicleSirenToggleDispatcher.Subscribe(value, out _);
            remove => VehicleSirenToggleDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativeVehicleHornToggleDelegate, VehicleToggleEventArgs> VehicleHornToggleDispatcher { get; }
        public event AsyncEventHandler<VehicleToggleEventArgs> VehicleHornToggle
        {
            add => VehicleHornToggleDispatcher.Subscribe(value, out _);
            remove => VehicleHornToggleDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativeVehicleTrailerAttachedDelegate, VehicleTrailerEventArgs> VehicleTrailerAttachedDispatcher { get; }
        public event AsyncEventHandler<VehicleTrailerEventArgs> VehicleTrailerAttached
        {
            add => VehicleTrailerAttachedDispatcher.Subscribe(value, out _);
            remove => VehicleTrailerAttachedDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativeVehicleDamageDelegate, VehicleDamageEventArgs> VehicleDamageDispatcher { get; }
        public event AsyncEventHandler<VehicleDamageEventArgs> VehicleDamage
        {
            add => VehicleDamageDispatcher.Subscribe(value, out _);
            remove => VehicleDamageDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerCreateWaypointDelegate, PlayerCreateWaypointEventArgs> PlayerCreateWaypointDispatcher { get; }
        public event AsyncEventHandler<PlayerCreateWaypointEventArgs> PlayerCreateWaypoint
        {
            add => PlayerCreateWaypointDispatcher.Subscribe(value, out _);
            remove => PlayerCreateWaypointDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerReachWaypointDelegate, PlayerEventArgs> PlayerReachWaypointDispatcher { get; }
        public event AsyncEventHandler<PlayerEventArgs> PlayerReachWaypoint
        {
            add => PlayerReachWaypointDispatcher.Subscribe(value, out _);
            remove => PlayerReachWaypointDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerStreamInDelegate, PlayerStreamEventArgs> PlayerStreamInDispatcher { get; }
        public event AsyncEventHandler<PlayerStreamEventArgs> PlayerStreamIn
        {
            add => PlayerStreamInDispatcher.Subscribe(value, out _);
            remove => PlayerStreamInDispatcher.Unsubscribe(value, out _);
        }

        internal NativeAsyncEventDispatcher<NativePlayerStreamOutDelegate, PlayerStreamEventArgs> PlayerStreamOutDispatcher { get; }
        public event AsyncEventHandler<PlayerStreamEventArgs> PlayerStreamOut
        {
            add => PlayerStreamOutDispatcher.Subscribe(value, out _);
            remove => PlayerStreamOutDispatcher.Unsubscribe(value, out _);
        }

        internal EventScripting(Plugin plugin)
        {
            _plugin = plugin;
            _remoteEventHandler = new RemoteEventHandler(plugin);

            TickDispatcher = new NativeAsyncEventDispatcher<NativeTickDelegate, System.EventArgs>(plugin, EventType.Tick, DispatchTick, true);

            EntityCreatedDispatcher = new NativeAsyncEventDispatcher<NativeEntityCreatedDelegate, EntityEventArgs>(plugin, EventType.EntityCreated, DispatchEntityCreated, true);
            EntityDestroyedDispatcher = new NativeAsyncEventDispatcher<NativeEntityDestroyedDelegate, EntityEventArgs>(plugin, EventType.EntityDestroyed, DispatchEntityDestroyed, true);
            EntityModelChangeDispatcher = new NativeAsyncEventDispatcher<NativeEntityModelChangeDelegate, EntityModelEventArgs>(plugin, EventType.EntityModelChanged, DispatchEntityModelChange);

            PlayerJoinDispatcher = new NativeAsyncEventDispatcher<NativePlayerJoinDelegate, PlayerEventArgs>(plugin, EventType.PlayerJoin, DispatchPlayerJoin);
            PlayerReadyDispatcher = new NativeAsyncEventDispatcher<NativePlayerReadyDelegate, PlayerEventArgs>(plugin, EventType.PlayerReady, DispatchPlayerReady);
            PlayerDeathDispatcher = new NativeAsyncEventDispatcher<NativePlayerDeathDelegate, PlayerDeathEventArgs>(plugin, EventType.PlayerDeath, DispatchPlayerDeath);
            PlayerQuitDispatcher = new NativeSyncEventDispatcher<NativePlayerQuitDelegate, PlayerQuitEventArgs>(plugin, EventType.PlayerQuit, DisaptchPlayerQuit);
            PlayerCommandDispatcher = new NativeAsyncEventDispatcher<NativePlayerCommandDelegate, PlayerCommandEventArgs>(plugin, EventType.PlayerCommand, DispatchPlayerCommand, true);
            PlayerCommandFailedDispatcher = new AsyncEventDispatcher<PlayerCommandFailedEventArgs>(plugin, "PlayerCommandFailed");
            PlayerChatDispatcher = new NativeAsyncEventDispatcher<NativePlayerChatDelegate, PlayerChatEventArgs>(plugin, EventType.PlayerChat, DispatchPlayerChat);
            PlayerSpawnDispatcher = new NativeAsyncEventDispatcher<NativePlayerSpawnDelegate, PlayerEventArgs>(plugin, EventType.PlayerSpawn, DispatchPlayerSpawn);
            PlayerDamageDispatcher = new NativeAsyncEventDispatcher<NativePlayerDamageDelegate, PlayerDamageEventArgs>(plugin, EventType.PlayerDamage, DispatchPlayerDamage);
            PlayerWeaponChangeDispatcher = new NativeAsyncEventDispatcher<NativePlayerWeaponChangeDelegate, PlayerWeaponChangeEventArgs>(plugin, EventType.PlayerWeaponChange, DispatchPlayerWeaponChange);

            PlayerStartEnterVehicleDispatcher = new NativeAsyncEventDispatcher<NativePlayerStartEnterVehicleDelegate, PlayerEnterVehicleEventArgs>(plugin, EventType.PlayerStartEnterVehicle, DispatchStartEnterVehicle);
            PlayerEnterVehicleDispatcher = new NativeAsyncEventDispatcher<NativePlayerEnterVehicleDelegate, PlayerEnterVehicleEventArgs>(plugin, EventType.PlayerEnterVehicle, DispatchPlayerEnterVehicle);
            PlayerStartExitVehicleDispatcher = new NativeAsyncEventDispatcher<NativePlayerStartExitVehicleDelegate, PlayerVehicleEventArgs>(plugin, EventType.PlayerStartExitVehicle, DispatchStartExitVehicle);
            PlayerExitVehicleDispatcher = new NativeAsyncEventDispatcher<NativePlayerExitVehicleDelegate, PlayerVehicleEventArgs>(plugin, EventType.PlayerExitVehicle, DispatchPlayerExitVehicle);

            PlayerEnterCheckpointDispatcher = new NativeAsyncEventDispatcher<NativePlayerEnterCheckpointDelegate, PlayerCheckpointEventArgs>(plugin, EventType.PlayerEnterCheckpoint, DispatchPlayerEnterCheckpoint);
            PlayerExitCheckpointDispatcher = new NativeAsyncEventDispatcher<NativePlayerExitCheckpointDelegate, PlayerCheckpointEventArgs>(plugin, EventType.PlayerExitCheckpoint, DispatchPlayerExitCheckpoint);

            PlayerEnterColshapeDispatcher = new NativeAsyncEventDispatcher<NativePlayerEnterColshapeDelegate, PlayerColshapeEventArgs>(plugin, EventType.PlayerEnterColshape, DispatchPlayerEnterColshape);
            PlayerExitColshapeDispatcher = new NativeAsyncEventDispatcher<NativePlayerExitColshapeDelegate, PlayerColshapeEventArgs>(plugin, EventType.PlayerExitColshape, DispatchPlayerExitColshape);

            PlayerCreateWaypointDispatcher = new NativeAsyncEventDispatcher<NativePlayerCreateWaypointDelegate, PlayerCreateWaypointEventArgs>(plugin, EventType.PlayerCreateWaypoint, DispatchPlayerCreateWaypoint);
            PlayerReachWaypointDispatcher = new NativeAsyncEventDispatcher<NativePlayerReachWaypointDelegate, PlayerEventArgs>(plugin, EventType.PlayerReachWaypoint, DispatchPlayerReachWaypoint);

            PlayerStreamInDispatcher = new NativeAsyncEventDispatcher<NativePlayerStreamInDelegate, PlayerStreamEventArgs>(plugin, EventType.PlayerStreamIn, DispatchPlayerStreamIn);
            PlayerStreamOutDispatcher = new NativeAsyncEventDispatcher<NativePlayerStreamOutDelegate, PlayerStreamEventArgs>(plugin, EventType.PlayerStreamOut, DispatchPlayerStreamOut);

            VehicleDeathDispatcher = new NativeAsyncEventDispatcher<NativeVehicleDeathDelegate, VehicleDeathEventArgs>(plugin, EventType.VehicleDeath, DispatchVehicleDeath);
            VehicleSirenToggleDispatcher = new NativeAsyncEventDispatcher<NativeVehicleSirenToggleDelegate, VehicleToggleEventArgs>(plugin, EventType.VehicleSirenToggle, DispatchVehicleSirenToggle);
            VehicleHornToggleDispatcher = new NativeAsyncEventDispatcher<NativeVehicleHornToggleDelegate, VehicleToggleEventArgs>(plugin, EventType.VehicleHornToggle, DispatchVehicleHornToggle);
            VehicleTrailerAttachedDispatcher = new NativeAsyncEventDispatcher<NativeVehicleTrailerAttachedDelegate, VehicleTrailerEventArgs>(plugin, EventType.VehicleTrailerAttached, DispatchTrailerAttached);
            VehicleDamageDispatcher = new NativeAsyncEventDispatcher<NativeVehicleDamageDelegate, VehicleDamageEventArgs>(plugin, EventType.VehicleDamage, DispatchVehicleDamage);
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

            EntityCreatedDispatcher.CallAsync(this, new EntityEventArgs(createdEntity));
        }

        private void DispatchEntityDestroyed(IntPtr entitypointer)
        {
            TryRemoveEntity(entitypointer, entity =>
            {
                EntityDestroyedDispatcher.CallAsync(this, new EntityEventArgs(entity));
            });
        }

        private void DispatchEntityModelChange(IntPtr entitypointer, uint oldmodel)
        {
            if (TryGetEntity(entitypointer, out IEntity entity) == false)
            {
                return;
            }

            EntityModelChangeDispatcher.CallAsync(this, new EntityModelEventArgs(entity, oldmodel));
        }

        private void DispatchTick()
        {
            TickDispatcher.CallAsync(this, System.EventArgs.Empty);

            _plugin.TickScheduler();
        }

        private void DispatchPlayerJoin(IntPtr playerPointer)
        {
            var player = _plugin.PlayerPool[playerPointer];

            PlayerJoinDispatcher.CallAsync(this, new PlayerEventArgs(player));
        }

        private void DispatchPlayerReady(IntPtr playerPointer)
        {
            var player = _plugin.PlayerPool[playerPointer];

            PlayerReadyDispatcher.CallAsync(this, new PlayerEventArgs(player));
        }

        private void DispatchPlayerDeath(IntPtr playerPointer, uint reason, IntPtr killerplayerpointer)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var killer = _plugin.PlayerPool[killerplayerpointer];

            PlayerDeathDispatcher.CallAsync(this, new PlayerDeathEventArgs(player, reason, killer));
        }

        private void DisaptchPlayerQuit(IntPtr playerPointer, uint type, IntPtr reason)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var message = StringConverter.PointerToString(reason);

            PlayerQuitDispatcher.Call(this, new PlayerQuitEventArgs(player, (DisconnectReason)type, message));
        }

        private async void DispatchPlayerCommand(IntPtr playerPointer, IntPtr text)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var message = Marshal.PtrToStringUni(text);

            var eventArgs = new PlayerCommandEventArgs(player, message);

            await PlayerCommandDispatcher
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
            PlayerCommandFailedDispatcher.CallAsync(this, new PlayerCommandFailedEventArgs(player, input, error, errorMessage));
        }

        private void DispatchPlayerChat(IntPtr playerPointer, IntPtr text)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var message = Marshal.PtrToStringUni(text);

            PlayerChatDispatcher.CallAsync(this, new PlayerChatEventArgs(player, message));
        }

        private void DispatchPlayerSpawn(IntPtr playerPointer)
        {
            var player = _plugin.PlayerPool[playerPointer];

            PlayerSpawnDispatcher.CallAsync(this, new PlayerEventArgs(player));
        }

        private void DispatchPlayerDamage(IntPtr playerPointer, float healthLoss, float armorLoss)
        {
            var player = _plugin.PlayerPool[playerPointer];

            PlayerDamageDispatcher.CallAsync(this, new PlayerDamageEventArgs(player, healthLoss, armorLoss));
        }

        private void DispatchPlayerWeaponChange(IntPtr playerPointer, uint oldWeapon, uint newWeapon)
        {
            var player = _plugin.PlayerPool[playerPointer];

            PlayerWeaponChangeDispatcher.CallAsync(this, new PlayerWeaponChangeEventArgs(player, oldWeapon, newWeapon));
        }

        private void DispatchStartEnterVehicle(IntPtr playerPointer, IntPtr vehiclePointer, int seat)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            PlayerStartEnterVehicleDispatcher.CallAsync(this, new PlayerEnterVehicleEventArgs(player, vehicle, seat));
        }

        private void DispatchPlayerEnterVehicle(IntPtr playerPointer, IntPtr vehiclePointer, int seat)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            PlayerEnterVehicleDispatcher.CallAsync(this, new PlayerEnterVehicleEventArgs(player, vehicle, seat));
        }

        private void DispatchStartExitVehicle(IntPtr playerPointer, IntPtr vehiclePointer)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            PlayerStartExitVehicleDispatcher.CallAsync(this, new PlayerVehicleEventArgs(player, vehicle));
        }

        private void DispatchPlayerExitVehicle(IntPtr playerPointer, IntPtr vehiclePointer)
        {
            var player = _plugin.PlayerPool[playerPointer];
            var vehicle = _plugin.VehiclePool[vehiclePointer];

            PlayerStartExitVehicleDispatcher.CallAsync(this, new PlayerVehicleEventArgs(player, vehicle));
        }

        private void DispatchPlayerEnterCheckpoint(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.CheckpointPool[checkpointPointer];

            PlayerEnterCheckpointDispatcher.CallAsync(this, new PlayerCheckpointEventArgs(player, checkpoint));
        }

        private void DispatchPlayerExitCheckpoint(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.CheckpointPool[checkpointPointer];

            PlayerExitCheckpointDispatcher.CallAsync(this, new PlayerCheckpointEventArgs(player, checkpoint));
        }

        private void DispatchPlayerEnterColshape(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.ColshapePool[checkpointPointer];

            PlayerEnterColshapeDispatcher.CallAsync(this, new PlayerColshapeEventArgs(player, checkpoint));
        }

        private void DispatchPlayerExitColshape(IntPtr playerpointer, IntPtr checkpointPointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var checkpoint = _plugin.ColshapePool[checkpointPointer];

            PlayerExitColshapeDispatcher.CallAsync(this, new PlayerColshapeEventArgs(player, checkpoint));
        }

        private void DispatchVehicleDeath(IntPtr vehiclepointer, uint reason, IntPtr killerplayerpointer)
        {
            var vehicle = _plugin.VehiclePool[vehiclepointer];
            var killerPlayer = _plugin.PlayerPool[killerplayerpointer];

            VehicleDeathDispatcher.CallAsync(this, new VehicleDeathEventArgs(vehicle, reason, killerPlayer));
        }

        private void DispatchVehicleSirenToggle(IntPtr vehiclepointer, bool toggle)
        {
            var vehicle = _plugin.VehiclePool[vehiclepointer];

            VehicleSirenToggleDispatcher.CallAsync(this, new VehicleToggleEventArgs(vehicle, toggle));
        }

        private void DispatchVehicleHornToggle(IntPtr vehiclepointer, bool toggle)
        {
            var vehicle = _plugin.VehiclePool[vehiclepointer];

            VehicleHornToggleDispatcher.CallAsync(this, new VehicleToggleEventArgs(vehicle, toggle));
        }

        private void DispatchTrailerAttached(IntPtr vehiclepointer, IntPtr trailerpointer)
        {
            var vehicle = _plugin.VehiclePool[vehiclepointer];
            var trailer = _plugin.VehiclePool[trailerpointer];

            VehicleTrailerAttachedDispatcher.CallAsync(this, new VehicleTrailerEventArgs(vehicle, trailer));
        }

        private void DispatchVehicleDamage(IntPtr vehiclepointer, float bodyhealthloss, float enginehealthloss)
        {
            var vehicle = _plugin.VehiclePool[vehiclepointer];

            VehicleDamageDispatcher.CallAsync(this, new VehicleDamageEventArgs(vehicle, bodyhealthloss, enginehealthloss));
        }

        private void DispatchPlayerCreateWaypoint(IntPtr playerpointer, Vector3 position)
        {
            var player = _plugin.PlayerPool[playerpointer];

            PlayerCreateWaypointDispatcher.CallAsync(this, new PlayerCreateWaypointEventArgs(player, position));
        }

        private void DispatchPlayerReachWaypoint(IntPtr playerpointer)
        {
            var player = _plugin.PlayerPool[playerpointer];

            PlayerReachWaypointDispatcher.CallAsync(this, new PlayerEventArgs(player));
        }

        private void DispatchPlayerStreamIn(IntPtr playerpointer, IntPtr forplayerpointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var forPlayer = _plugin.PlayerPool[forplayerpointer];

            PlayerStreamInDispatcher.CallAsync(this, new PlayerStreamEventArgs(player, forPlayer));
        }

        private void DispatchPlayerStreamOut(IntPtr playerpointer, IntPtr forplayerpointer)
        {
            var player = _plugin.PlayerPool[playerpointer];
            var forPlayer = _plugin.PlayerPool[forplayerpointer];

            PlayerStreamOutDispatcher.CallAsync(this, new PlayerStreamEventArgs(player, forPlayer));
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
