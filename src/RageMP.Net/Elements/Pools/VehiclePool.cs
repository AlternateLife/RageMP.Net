using System;
using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Elements.Entities;
using RageMP.Net.Enums;
using RageMP.Net.Helpers;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Elements.Pools
{
    internal class VehiclePool : PoolBase<IVehicle>, IVehiclePool
    {
        internal VehiclePool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public async Task<IVehicle> NewAsync(VehicleHash model, Vector3 position, float heading, string numberPlate, uint alpha, bool locked, bool engine, uint dimension)
        {
            var pointer = await _plugin.Schedule(() =>
            {
                using (var converter = new StringConverter())
                {
                    return Rage.VehiclePool.VehiclePool_New(_nativePointer, (uint) model, position, heading, converter.StringToPointer(numberPlate), alpha, locked, engine, dimension);
                }
            }).ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        protected override IVehicle BuildEntity(IntPtr entityPointer)
        {
            return new Vehicle(entityPointer, _plugin);
        }
    }
}
