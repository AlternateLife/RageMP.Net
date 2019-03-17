using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class VehicleToggleEventArgs : VehicleEventArgs
    {
        public bool Toggle { get; }

        internal VehicleToggleEventArgs(IVehicle vehicle, bool toggle) : base(vehicle)
        {
            Toggle = toggle;
        }
    }
}
