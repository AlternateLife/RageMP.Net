using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal partial class Player
    {
        public IVehicle Vehicle
        {
            get
            {
                var pointer = Rage.Player.Player_GetVehicle(NativePointer);

                return _plugin.VehiclePool[pointer];
            }
        }

        public int Seat => Rage.Player.Player_GetSeat(NativePointer);

        public void PutIntoVehicle(IVehicle vehicle, int seat)
        {
            Contract.NotNull(vehicle, nameof(vehicle));

            Rage.Player.Player_PutIntoVehicle(NativePointer, vehicle.NativePointer, seat);
        }

        public void RemoveFromVehicle()
        {
            Rage.Player.Player_RemoveFromVehicle(NativePointer);
        }
    }
}
