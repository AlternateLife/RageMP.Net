using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Entities
{
    public partial class Player
    {
        public IVehicle Vehicle { get; }
        public int Seat => Rage.Player.Player_GetSeat(NativePointer);

        public void PutIntoVehicle(IVehicle vehicle, int seat)
        {
            Rage.Player.Player_PutIntoVehicle(NativePointer, vehicle.NativePointer, seat);
        }

        public void RemoveFromVehicle()
        {
            Rage.Player.Player_RemoveFromVehicle(NativePointer);
        }
    }
}
