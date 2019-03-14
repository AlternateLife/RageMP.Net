using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Elements.Entities;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Extensions;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Pools
{
    internal class MarkerPool : PoolBase<IMarker>, IMarkerPool
    {
        public MarkerPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public IMarker New(MarkerType type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension)
        {
            var pointer = Rage.MarkerPool.MarkerPool_New(_nativePointer, (uint) type, position, rotation, direction, scale, color.GetNumberValue(), visible, dimension);

            return CreateAndSaveEntity(pointer);
        }

        public Task<IMarker> NewAsync(MarkerType type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension)
        {
            return _plugin.Schedule(() => New(type, position, rotation, direction, scale, color, visible, dimension));
        }

        public IMarker New(uint type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension)
        {
            return New((MarkerType) type, position, rotation, direction, scale, color, visible, dimension);
        }

        public Task<IMarker> NewAsync(uint type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension)
        {
            return NewAsync((MarkerType) type, position, rotation, direction, scale, color, visible, dimension);
        }

        public IMarker New(int type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension)
        {
            return New((MarkerType) type, position, rotation, direction, scale, color, visible, dimension);
        }

        public Task<IMarker> NewAsync(int type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension)
        {
            return NewAsync((MarkerType) type, position, rotation, direction, scale, color, visible, dimension);
        }

        protected override IMarker BuildEntity(IntPtr entityPointer)
        {
            return new Marker(entityPointer, _plugin);
        }
    }
}
