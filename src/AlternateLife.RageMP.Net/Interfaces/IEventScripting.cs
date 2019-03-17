using System;
using AlternateLife.RageMP.Net.EventArgs;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IEventScripting
    {
        event AsyncEventHandler<System.EventArgs> Tick;
        event AsyncEventHandler<PlayerEventArgs> PlayerJoin;
        event AsyncEventHandler<PlayerEventArgs> PlayerReady;
        event AsyncEventHandler<PlayerDeathEventArgs> PlayerDeath;
        event PlayerQuitDelegate PlayerQuit;
        event AsyncEventHandler<PlayerCommandEventArgs> PlayerCommand;
        event AsyncEventHandler<PlayerCommandFailedEventArgs> PlayerCommandFailed;
        event AsyncEventHandler<PlayerChatEventArgs> PlayerChat;
        event AsyncEventHandler<PlayerEventArgs> PlayerSpawn;
        event AsyncEventHandler<PlayerDamageEventArgs> PlayerDamage;
        event AsyncEventHandler<PlayerWeaponChangeEventArgs> PlayerWeaponChange;
        event AsyncEventHandler<PlayerEnterVehicleEventArgs> PlayerStartEnterVehicle;
        event AsyncEventHandler<PlayerEnterVehicleEventArgs> PlayerEnterVehicle;
        event AsyncEventHandler<PlayerVehicleEventArgs> PlayerStartExitVehicle;
        event AsyncEventHandler<PlayerVehicleEventArgs> PlayerExitVehicle;
        event AsyncEventHandler<PlayerCheckpointEventArgs> PlayerEnterCheckpoint;
        event AsyncEventHandler<PlayerCheckpointEventArgs> PlayerExitCheckpoint;
        event AsyncEventHandler<PlayerColshapeEventArgs> PlayerEnterColshape;
        event AsyncEventHandler<PlayerColshapeEventArgs> PlayerExitColshape;
        event AsyncEventHandler<PlayerCreateWaypointEventArgs> PlayerCreateWaypoint;
        event AsyncEventHandler<PlayerEventArgs> PlayerReachWaypoint;

        event VehicleDeathDelegate VehicleDeath;
        event VehicleSirenToggleDelegate VehicleSirenToggle;
        event VehicleHornToggleDelegate VehicleHornToggle;
        event VehicleTrailerAttachedDelegate VehicleTrailerAttached;
        event VehicleDamageDelegate VehicleDamage;

        event AsyncEventHandler<PlayerStreamEventArgs> PlayerStreamIn;
        event AsyncEventHandler<PlayerStreamEventArgs> PlayerStreamOut;

        /// <summary>
        /// Add a client event callback.
        ///
        /// The <paramref name="callback" /> is called when a player sends a client event with the given <paramref name="eventName" />.
        /// </summary>
        /// <param name="eventName">Name of the event</param>
        /// <param name="callback">Callback to execute on the event</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventName" /> is null or empty</exception>
        void Add(string eventName, AsyncEventHandler<PlayerRemoteEventEventArgs> callback);
    }
}
