using AlternateLife.RageMP.Net.EventArgs;
using AlternateLife.RageMP.Net.Helpers.EventDispatcher;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal partial class Player
    {
        private readonly AsyncChildEventDispatcher<PlayerCommandEventArgs> _commandDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerCommandFailedEventArgs> _commandFailedDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerChatEventArgs> _chatDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerEventArgs> _spawnDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerDamageEventArgs> _damageDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerWeaponChangeEventArgs> _weaponChangeDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerEnterVehicleEventArgs> _startEnterVehicleDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerEnterVehicleEventArgs> _enterVehicleDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerVehicleEventArgs> _startExitVehicleDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerVehicleEventArgs> _exitVehicleDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerCheckpointEventArgs> _enterCheckpointDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerCheckpointEventArgs> _exitCheckpointDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerColshapeEventArgs> _enterColshapeDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerColshapeEventArgs> _exitColshapeDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerCreateWaypointEventArgs> _createWaypointDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerEventArgs> _reachWaypointDispatcher;

        public event AsyncEventHandler<PlayerCommandEventArgs> Command
        {
            add => _commandDispatcher.Subscribe(value, out _);
            remove => _commandDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerCommandFailedEventArgs> CommandFailed
        {
            add => _commandFailedDispatcher.Subscribe(value, out _);
            remove => _commandFailedDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerChatEventArgs> Chat
        {
            add => _chatDispatcher.Subscribe(value, out _);
            remove => _chatDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerEventArgs> Spawned
        {
            add => _spawnDispatcher.Subscribe(value, out _);
            remove => _spawnDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerDamageEventArgs> Damage
        {
            add => _damageDispatcher.Subscribe(value, out _);
            remove => _damageDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerWeaponChangeEventArgs> WeaponChange
        {
            add => _weaponChangeDispatcher.Subscribe(value, out _);
            remove => _weaponChangeDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerEnterVehicleEventArgs> StartEnterVehicle
        {
            add => _startEnterVehicleDispatcher.Subscribe(value, out _);
            remove => _startEnterVehicleDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerEnterVehicleEventArgs> EnterVehicle
        {
            add => _enterVehicleDispatcher.Subscribe(value, out _);
            remove => _enterVehicleDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerVehicleEventArgs> StartExitVehicle
        {
            add => _startExitVehicleDispatcher.Subscribe(value, out _);
            remove => _startExitVehicleDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerVehicleEventArgs> ExitVehicle
        {
            add => _exitVehicleDispatcher.Subscribe(value, out _);
            remove => _exitVehicleDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerCheckpointEventArgs> EnterCheckpoint
        {
            add => _enterCheckpointDispatcher.Subscribe(value, out _);
            remove => _enterCheckpointDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerCheckpointEventArgs> ExitCheckpoint
        {
            add => _exitCheckpointDispatcher.Subscribe(value, out _);
            remove => _exitCheckpointDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerColshapeEventArgs> EnterColshape
        {
            add => _enterColshapeDispatcher.Subscribe(value, out _);
            remove => _enterColshapeDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerColshapeEventArgs> ExitColshape
        {
            add => _exitColshapeDispatcher.Subscribe(value, out _);
            remove => _exitColshapeDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerCreateWaypointEventArgs> CreateWaypoint
        {
            add => _createWaypointDispatcher.Subscribe(value, out _);
            remove => _createWaypointDispatcher.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerEventArgs> ReachWaypoint
        {
            add => _reachWaypointDispatcher.Subscribe(value, out _);
            remove => _reachWaypointDispatcher.Unsubscribe(value, out _);
        }

    }
}
