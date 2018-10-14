using RageMP.Net.Interfaces;
using RageMP.Net.Native;
using RageMP.Net.Scripting;

namespace RageMP.Net.Entities
{
    internal partial class Player
    {
        public IVehicle Vehicle
        {
            get
            {
                var pointer = Rage.Player.Player_GetVehicle(NativePointer);

                return MP.InternalVehicles[pointer];
            }
        }

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
