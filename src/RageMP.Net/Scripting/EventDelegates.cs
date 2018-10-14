using RageMP.Net.Interfaces;

namespace RageMP.Net.Scripting
{
    public delegate void TickDelegate();

    public delegate void EntityCreatedDelegate(IEntity entity);
    public delegate void EntityDestroyedDelegate(IEntity entity);
    public delegate void EntityModelChangeDelegate(IEntity entity, uint oldModel);

    public delegate void PlayerJoinDelegate(IPlayer player);
    public delegate void PlayerReadyDelegate(IPlayer player);
    public delegate void PlayerQuitDelegate(IPlayer player, uint type, string reason);
    public delegate void PlayerCommandDelegate(IPlayer player, string text);
    public delegate void PlayerChatDelegate(IPlayer player, string text);
    public delegate void PlayerDeathDelegate(IPlayer player, uint reason, IPlayer killerPlayer);
    public delegate void PlayerSpawnDelegate(IPlayer player);
    public delegate void PlayerDamageDelegate(IPlayer player, float healthLoss, float armorLoss);
    public delegate void PlayerWeaponChangeDelegate(IPlayer player, uint oldWeapon, uint newWeapon);
    //public delegate void PlayerRemoteEventDelegate(IPlayer player, uint eventNameHash, object[] arguments);
    public delegate void PlayerStartEnterVehicleDelegate(IPlayer player, IVehicle vehicle, uint seat);
    public delegate void PlayerEnterVehicleDelegate(IPlayer player, IVehicle vehicle, uint seat);
    public delegate void PlayerStartExitVehicleDelegate(IPlayer player, IVehicle vehicle);
    public delegate void PlayerExitVehicleDelegate(IPlayer player, IVehicle vehicle);

    public delegate void VehicleDeathDelegate(IVehicle vehicle, uint reason, IPlayer killerPlayer);
    public delegate void VehicleSirenToggleDelegate(IVehicle vehicle, bool toggle);
    public delegate void VehicleHornDelegate(IVehicle vehicle, bool toggle);
    public delegate void VehicleTrailerAttachedDelegate(IVehicle vehicle, IVehicle trailer);
    public delegate void VehicleDamageDelegateDelegate(IVehicle vehicle, float bodyHealthLoss, float engineHealthLoss);

    public delegate void PlayerEnterColshapeDelegate(IPlayer player, IColshape colshapePointer);
    public delegate void PlayerExitColshapeDelegate(IPlayer player, IColshape colshapePointer);

    public delegate void PlayerEnterCheckpointDelegate(IPlayer player, ICheckpoint checkpointPointer);
    public delegate void PlayerExitCheckpointDelegate(IPlayer player, ICheckpoint checkpointPointer);

    //public delegate void CreateWaypointDelegate(IPlayer player/**, Vector3 position (?) **/);
    public delegate void ReachWaypointDelegate(IPlayer player);

    public delegate void PlayerStreamInDelegate(IPlayer player, IPlayer forPlayer);
    public delegate void PlayerStreamOutDelegate(IPlayer player, IPlayer forPlayer);

    public delegate void PlayerRemoteEventDelegate(IPlayer player, string eventName, object[] arguments);
}
