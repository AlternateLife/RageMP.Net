using System;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IEventScripting
    {
        event TickDelegate Tick;
        event PlayerJoinDelegate PlayerJoin;
        event PlayerReadyDelegate PlayerReady;
        event PlayerDeathDelegate PlayerDeath;
        event PlayerQuitDelegate PlayerQuit;
        event PlayerCommandDelegate PlayerCommand;
        event PlayerChatDelegate PlayerChat;
        event PlayerSpawnDelegate PlayerSpawn;
        event PlayerDamageDelegate PlayerDamage;
        event PlayerWeaponChangeDelegate PlayerWeaponChange;
        event PlayerStartEnterVehicleDelegate PlayerStartEnterVehicle;
        event PlayerEnterVehicleDelegate PlayerEnterVehicle;
        event PlayerStartExitVehicleDelegate PlayerStartExitVehicle;
        event PlayerExitVehicleDelegate PlayerExitVehicle;
        event PlayerEnterCheckpointDelegate PlayerEnterCheckpoint;
        event PlayerExitCheckpointDelegate PlayerExitCheckpoint;
        event PlayerEnterColshapeDelegate PlayerEnterColshape;
        event PlayerExitColshapeDelegate PlayerExitColshape;
        event PlayerCreateWaypointDelegate PlayerCreateWaypoint;
        event PlayerReachWaypointDelegate PlayerReachWaypoint;

        event VehicleDeathDelegate VehicleDeath;
        event VehicleSirenToggleDelegate VehicleSirenToggle;
        event VehicleHornToggleDelegate VehicleHornToggle;
        event VehicleTrailerAttachedDelegate VehicleTrailerAttached;
        event VehicleDamageDelegate VehicleDamage;

        event PlayerStreamInDelegate PlayerStreamIn;
        event PlayerStreamOutDelegate PlayerStreamOut;

        /// <summary>
        /// Add a client event callback.
        ///
        /// The <paramref name="callback" /> is called when a player sends a client event with the given <paramref name="eventName" />.
        /// </summary>
        /// <param name="eventName">Name of the event</param>
        /// <param name="callback">Callback to execute on the event</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventName" /> is null or empty</exception>
        void Add(string eventName, PlayerRemoteEventDelegate callback);
    }
}
