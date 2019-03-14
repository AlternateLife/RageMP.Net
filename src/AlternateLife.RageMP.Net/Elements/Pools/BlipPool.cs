using System;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Elements.Entities;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Pools
{
    internal class BlipPool : PoolBase<IBlip>, IBlipPool
    {
        public BlipPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public IBlip New(uint sprite, Vector3 position, float scale, uint color, string name, uint alpha, float drawDistance, bool shortRange, int rotation, uint dimension)
        {
            Contract.NotNull(name, nameof(name));

            using (var converter = new StringConverter())
            {
                var namePointer = converter.StringToPointer(name);

                var pointer = Rage.BlipPool.BlipPool_New(_nativePointer, sprite, position, scale, color, namePointer, alpha, drawDistance, shortRange, rotation, dimension);

                return CreateAndSaveEntity(pointer);
            }
        }

        public Task<IBlip> NewAsync(uint sprite, Vector3 position, float scale, uint color, string name, uint alpha, float drawDistance, bool shortRange, int rotation, uint dimension)
        {
            return _plugin.Schedule(() => New(sprite, position, scale, color, name, alpha, drawDistance, shortRange, rotation, dimension));
        }

        public IBlip New(int sprite, Vector3 position, float scale, int color, string name, int alpha, float drawDistance, bool shortRange, int rotation, uint dimension)
        {
            return New((uint) sprite, position, scale, (uint) color, name, (uint) alpha, drawDistance, shortRange, rotation, dimension);
        }

        public Task<IBlip> NewAsync(int sprite, Vector3 position, float scale, int color, string name, int alpha, float drawDistance, bool shortRange, int rotation, uint dimension)
        {
            return NewAsync((uint) sprite, position, scale, (uint) color, name, (uint) alpha, drawDistance, shortRange, rotation, dimension);
        }

        protected override IBlip BuildEntity(IntPtr entity)
        {
            return new Blip(entity, _plugin);
        }
    }
}
