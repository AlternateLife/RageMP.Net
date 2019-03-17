using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerVehicleEventArgs : PlayerEventArgs
    {
        public IVehicle Vehicle { get; }

        internal PlayerVehicleEventArgs(IPlayer player, IVehicle vehicle) : base(player)
        {
            Vehicle = vehicle;
        }
    }
}
