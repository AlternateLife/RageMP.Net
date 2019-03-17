using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class VehicleDamageEventArgs : VehicleEventArgs
    {
        public float BodyHealthLoss { get; }
        public float EngineHealthLoss { get; }

        internal VehicleDamageEventArgs(IVehicle vehicle, float bodyHealthLoss, float engineHealthLoss) : base(vehicle)
        {
            BodyHealthLoss = bodyHealthLoss;
            EngineHealthLoss = engineHealthLoss;
        }
    }
}
