using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal partial class Player
    {
        public IVehicle GetVehicle()
        {
            CheckExistence();

            var pointer = Rage.Player.Player_GetVehicle(NativePointer);

            return _plugin.VehiclePool[pointer];
        }

        public Task<IVehicle> GetVehicleAsync()
        {
            return _plugin.Schedule(GetVehicle);
        }

        public bool IsInVehicle()
        {
            return GetVehicle() != null;
        }

        public Task<bool> IsInVehicleAsync()
        {
            return _plugin.Schedule(IsInVehicle);
        }

        public int GetSeat()
        {
            CheckExistence();

            return Rage.Player.Player_GetSeat(NativePointer);
        }

        public Task<int> GetSeatAsync()
        {
            return _plugin.Schedule(GetSeat);
        }

        public void PutIntoVehicle(IVehicle vehicle, int seat)
        {
            Contract.NotNull(vehicle, nameof(vehicle));
            CheckExistence();

            Rage.Player.Player_PutIntoVehicle(NativePointer, vehicle.NativePointer, seat);
        }

        public Task PutIntoVehicleAsync(IVehicle vehicle, int seat)
        {
            return _plugin.Schedule(() => PutIntoVehicle(vehicle, seat));
        }

        public void RemoveFromVehicle()
        {
            CheckExistence();

            Rage.Player.Player_RemoveFromVehicle(NativePointer);
        }

        public Task RemoveFromVehicleAsync()
        {
            return _plugin.Schedule(RemoveFromVehicle);
        }
    }
}
