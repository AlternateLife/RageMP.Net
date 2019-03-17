using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting
{
    public delegate Task AsyncEventHandler<T>(object sender, T e) where T : System.EventArgs;

    public delegate void PlayerQuitDelegate(IPlayer player, DisconnectReason type, string reason);
    //public delegate void PlayerRemoteEventDelegate(IPlayer player, uint eventNameHash, object[] arguments);

    public delegate Task VehicleDeathDelegate(IVehicle vehicle, uint reason, IPlayer killerPlayer);
    public delegate Task VehicleSirenToggleDelegate(IVehicle vehicle, bool toggle);
    public delegate Task VehicleHornToggleDelegate(IVehicle vehicle, bool toggle);
    public delegate Task VehicleTrailerAttachedDelegate(IVehicle vehicle, IVehicle trailer);
    public delegate Task VehicleDamageDelegate(IVehicle vehicle, float bodyHealthLoss, float engineHealthLoss);

    public delegate Task CommandDelegate(IPlayer player, string[] arguments);
    public delegate bool ParserDelegate<T>(string s, out T val);
}
