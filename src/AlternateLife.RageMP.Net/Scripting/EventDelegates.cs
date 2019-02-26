using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting.ScriptingClasses;

namespace AlternateLife.RageMP.Net.Scripting
{
    public delegate Task TickDelegate();

    public delegate Task EntityCreatedDelegate(IEntity entity);
    public delegate Task EntityDestroyedDelegate(IEntity entity);
    public delegate Task EntityModelChangeDelegate(IEntity entity, uint oldModel);

    public delegate Task PlayerJoinDelegate(IPlayer player);
    public delegate Task PlayerReadyDelegate(IPlayer player);
    public delegate void PlayerQuitDelegate(IPlayer player, DisconnectReason type, string reason);
    public delegate Task PlayerCommandDelegate(IPlayer player, string text, CommandEventArgs eventArgs);
    public delegate Task PlayerCommandFailedDelegate(IPlayer player, string input, CommandError error, string errorMessage);
    public delegate Task PlayerChatDelegate(IPlayer player, string text);
    public delegate Task PlayerDeathDelegate(IPlayer player, uint reason, IPlayer killerPlayer);
    public delegate Task PlayerSpawnDelegate(IPlayer player);
    public delegate Task PlayerDamageDelegate(IPlayer player, float healthLoss, float armorLoss);
    public delegate Task PlayerWeaponChangeDelegate(IPlayer player, uint oldWeapon, uint newWeapon);
    //public delegate void PlayerRemoteEventDelegate(IPlayer player, uint eventNameHash, object[] arguments);
    public delegate Task PlayerStartEnterVehicleDelegate(IPlayer player, IVehicle vehicle, int seat);
    public delegate Task PlayerEnterVehicleDelegate(IPlayer player, IVehicle vehicle, int seat);
    public delegate Task PlayerStartExitVehicleDelegate(IPlayer player, IVehicle vehicle);
    public delegate Task PlayerExitVehicleDelegate(IPlayer player, IVehicle vehicle);

    public delegate Task VehicleDeathDelegate(IVehicle vehicle, uint reason, IPlayer killerPlayer);
    public delegate Task VehicleSirenToggleDelegate(IVehicle vehicle, bool toggle);
    public delegate Task VehicleHornToggleDelegate(IVehicle vehicle, bool toggle);
    public delegate Task VehicleTrailerAttachedDelegate(IVehicle vehicle, IVehicle trailer);
    public delegate Task VehicleDamageDelegate(IVehicle vehicle, float bodyHealthLoss, float engineHealthLoss);

    public delegate Task PlayerEnterColshapeDelegate(IPlayer player, IColshape colshapePointer);
    public delegate Task PlayerExitColshapeDelegate(IPlayer player, IColshape colshapePointer);

    public delegate Task PlayerEnterCheckpointDelegate(IPlayer player, ICheckpoint checkpointPointer);
    public delegate Task PlayerExitCheckpointDelegate(IPlayer player, ICheckpoint checkpointPointer);

    public delegate Task PlayerCreateWaypointDelegate(IPlayer player, Vector3 position);
    public delegate Task PlayerReachWaypointDelegate(IPlayer player);

    public delegate Task PlayerStreamInDelegate(IPlayer player, IPlayer forPlayer);
    public delegate Task PlayerStreamOutDelegate(IPlayer player, IPlayer forPlayer);

    public delegate Task PlayerRemoteEventDelegate(IPlayer player, string eventName, object[] arguments);

    public delegate Task CommandDelegate(IPlayer player, string[] arguments);
    public delegate bool ParserDelegate<T>(string s, out T val);
}
