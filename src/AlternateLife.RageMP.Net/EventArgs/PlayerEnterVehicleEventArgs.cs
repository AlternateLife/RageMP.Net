using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerEnterVehicleEventArgs : PlayerVehicleEventArgs
    {
        public int Seat { get; }

        internal PlayerEnterVehicleEventArgs(IPlayer player, IVehicle vehicle, int seat) : base(player, vehicle)
        {
            Seat = seat;
        }
    }
}
