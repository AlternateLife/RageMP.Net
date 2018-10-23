using System;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Elements.Entities;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Pools
{
    internal class VehiclePool : PoolBase<IVehicle>, IVehiclePool
    {
        internal VehiclePool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public async Task<IVehicle> NewAsync(VehicleHash model, Vector3 position, float heading, string numberPlate, uint alpha, bool locked, bool engine, uint dimension)
        {
            using (var converter = new StringConverter())
            {
                var numberplatePointer = converter.StringToPointer(numberPlate);

                var pointer = await _plugin
                    .Schedule(() => Rage.VehiclePool.VehiclePool_New(_nativePointer, (uint) model, position, heading, numberplatePointer, alpha, locked, engine, dimension))
                    .ConfigureAwait(false);

                return CreateAndSaveEntity(pointer);
            }
        }

        public Task<IVehicle> NewAsync(uint model, Vector3 position, float heading, string numberPlate, uint alpha, bool locked, bool engine, uint dimension)
        {
            return NewAsync((VehicleHash) model, position, heading, numberPlate, alpha, locked, engine, dimension);
        }

        public Task<IVehicle> NewAsync(int model, Vector3 position, float heading, string numberPlate, int alpha, bool locked, bool engine, uint dimension)
        {
            return NewAsync((VehicleHash) model, position, heading, numberPlate, (uint) alpha, locked, engine, dimension);
        }

        protected override IVehicle BuildEntity(IntPtr entityPointer)
        {
            return new Vehicle(entityPointer, _plugin);
        }
    }
}
