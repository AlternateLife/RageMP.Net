using System;
using System.Numerics;
using RageMP.Net.Data;
using RageMP.Net.Entities;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Scripting.ScriptingClasses
{
    internal class MarkerPool : PoolBase<IMarker>, IMarkerPool
    {
        internal MarkerPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public IMarker New(uint model, Vector3 position, Vector3 rotation, Vector3 direction, float scale, ColorRgba color, bool visible, uint dimension)
        {
            var pointer = Rage.MarkerPool.MarkerPool_New(_nativePointer, model, position, rotation, direction, scale, color, visible, dimension);

            return new Marker(pointer, _plugin);
        }
    }
}
