using System;
using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Data;
using RageMP.Net.Elements.Entities;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Elements.Pools
{
    internal class MarkerPool : PoolBase<IMarker>, IMarkerPool
    {
        internal MarkerPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public async Task<IMarker> NewAsync(uint model, Vector3 position, Vector3 rotation, Vector3 direction, float scale, ColorRgba color, bool visible, uint dimension)
        {
            var pointer = await _plugin
                .Schedule(() => Rage.MarkerPool.MarkerPool_New(_nativePointer, model, position, rotation, direction, scale, color, visible, dimension))
                .ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        protected override IMarker BuildEntity(IntPtr entityPointer)
        {
            return new Marker(entityPointer, _plugin);
        }
    }
}
