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
    }
}
