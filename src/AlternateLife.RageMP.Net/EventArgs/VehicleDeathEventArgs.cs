using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class VehicleDeathEventArgs : VehicleEventArgs
    {
        public uint Reason { get; }
        public IPlayer Killer { get; }

        internal VehicleDeathEventArgs(IVehicle vehicle, uint reason, IPlayer killer) : base(vehicle)
        {
            Reason = reason;
            Killer = killer;
        }
    }
}
