using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class VehicleTrailerEventArgs : VehicleEventArgs
    {
        public IVehicle Trailer { get; }

        internal VehicleTrailerEventArgs(IVehicle vehicle, IVehicle trailer) : base(vehicle)
        {
            Trailer = trailer;
        }
    }
}
