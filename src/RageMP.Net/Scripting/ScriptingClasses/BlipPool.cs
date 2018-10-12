using System;
using System.Numerics;
using RageMP.Net.Entities;
using RageMP.Net.Helpers;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Scripting.ScriptingClasses
{
    internal class BlipPool : PoolBase<IBlip>, IBlipPool
    {
        public BlipPool(IntPtr nativePointer) : base(nativePointer)
        {
        }

        public IBlip New(uint sprite, Vector3 position, float scale, uint color, string name, uint alpha, float drawDistance, bool shortRange, int rotation, uint dimension)
        {
            using (var converter = new StringConverter())
            {
                var blipPointer = Rage.BlipPool.VehiclePool_New(_nativePointer, sprite, position, scale, color, converter.StringToPointer(name), alpha, drawDistance, shortRange,
                    rotation, dimension);

                return new Blip(blipPointer);
            }
        }
    }
}
