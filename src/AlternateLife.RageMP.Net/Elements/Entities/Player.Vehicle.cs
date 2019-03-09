using System.Threading.Tasks;
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
                CheckExistence();

                var pointer = Rage.Player.Player_GetVehicle(NativePointer);

                return _plugin.VehiclePool[pointer];
            }
        }

        public bool IsInVehicle => Vehicle != null;

        public int Seat
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_GetSeat(NativePointer);
            }
        }

        public async Task PutIntoVehicleAsync(IVehicle vehicle, int seat)
        {
            Contract.NotNull(vehicle, nameof(vehicle));
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_PutIntoVehicle(NativePointer, vehicle.NativePointer, seat))
                .ConfigureAwait(false);
        }

        public async Task RemoveFromVehicleAsync()
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_RemoveFromVehicle(NativePointer))
                .ConfigureAwait(false);
        }
    }
}
