using System;
using System.Numerics;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Elements.Entities;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Pools
{
    internal class MarkerPool : PoolBase<IMarker>, IMarkerPool
    {
        internal MarkerPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public IMarker New(uint model, Vector3 position, Vector3 rotation, Vector3 direction, float scale, ColorRgba color, bool visible, uint dimension)
        {
            var pointer = Rage.MarkerPool.MarkerPool_New(_nativePointer, model, position, rotation, direction, scale, color, visible, dimension);

            return CreateAndSaveEntity(pointer);
        }

        protected override IMarker BuildEntity(IntPtr entityPointer)
        {
            return new Marker(entityPointer, _plugin);
        }
    }
}
