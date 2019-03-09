using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal partial class Player
    {
        public async Task<IVehicle> GetVehicleAsync()
        {
            CheckExistence();

            var pointer = await _plugin
                .Schedule(() => Rage.Player.Player_GetVehicle(NativePointer))
                .ConfigureAwait(false);

            return _plugin.VehiclePool[pointer];
        }

        public async Task<bool> IsInVehicleAsync()
        {
            return await GetVehicleAsync()
                       .ConfigureAwait(false) != null;
        }

        public async Task<int> GetSeatAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Player.Player_GetSeat(NativePointer))
                .ConfigureAwait(false);
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
