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
        internal BlipPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public IBlip New(uint sprite, Vector3 position, float scale, uint color, string name, uint alpha, float drawDistance, bool shortRange, int rotation, uint dimension)
        {
            using (var converter = new StringConverter())
            {
                var pointer = Rage.BlipPool.BlipPool_New(_nativePointer, sprite, position, scale, color, converter.StringToPointer(name), alpha, drawDistance, shortRange,
                    rotation, dimension);

                return TryCreateAndSaveEntity(pointer);
            }
        }

        protected override IBlip BuildEntity(IntPtr entity)
        {
            return new Blip(entity, _plugin);
        }
    }
}
