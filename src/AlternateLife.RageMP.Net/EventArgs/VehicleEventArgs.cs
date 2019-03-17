using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class VehicleEventArgs : System.EventArgs
    {
        public IVehicle Vehicle { get; }

        internal VehicleEventArgs(IVehicle vehicle)
        {
            Vehicle = vehicle;
        }
    }
}
