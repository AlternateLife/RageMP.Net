using System;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Elements.Entities;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Pools
{
    internal class MarkerPool : PoolBase<IMarker>, IMarkerPool
    {
        internal MarkerPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public async Task<IMarker> NewAsync(MarkerType type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, ColorRgba color, bool visible, uint dimension)
        {
            var pointer = await _plugin
                .Schedule(() => Rage.MarkerPool.MarkerPool_New(_nativePointer, (uint) type, position, rotation, direction, scale, color, visible, dimension))
                .ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        protected override IMarker BuildEntity(IntPtr entityPointer)
        {
            return new Marker(entityPointer, _plugin);
        }
    }
}
