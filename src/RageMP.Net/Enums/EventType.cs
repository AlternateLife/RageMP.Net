namespace RageMP.Net.Enums
{
    internal enum EventType
    {
        EntityCreated,
        EntityDestroyed,
        EntityModelChanged,

        PlayerJoin,
        PlayerReady,
        PlayerQuit,
        PlayerCommand,
        PlayerChat,
        PlayerDeath,
        PlayerSpawn,
        PlayerDamage,
        PlayerWeaponChange,
        PlayerRemoteEvent,
        PlayerStartEnterVehicle,
        PlayerEnterVehicle,
        PlayerStartExitVehicle,
        PlayerExitVehicle,

        VehicleDeath,
        VehicleSirenToggle,
        VehicleHornToggle,
        VehicleTrailerAttached,
        VehicleDamage,

        PlayerEnterColshape,
        PlayerExitColshape,

        PlayerEnterCheckpoint,
        PlayerExitCheckpoint,

        PlayerCreateWaypoint,
        PlayerReachWaypoint,

        PlayerStreamIn,
        PlayerStreamOut,

        Tick
    }
}
