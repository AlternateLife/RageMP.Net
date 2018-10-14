using System;
using System.Numerics;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;
using Object = RageMP.Net.Entities.Object;

namespace RageMP.Net.Scripting.ScriptingClasses
{
    internal class ObjectPool : PoolBase<IObject>, IObjectPool
    {
        public ObjectPool(IntPtr nativePointer) : base(nativePointer)
        {
        }

        public IObject New(uint model, Vector3 position, Vector3 rotation, uint dimension)
        {
            var pointer = Rage.ObjectPool.ObjectPool_New(_nativePointer, model, position, rotation, dimension);

            return new Object(pointer);
        }
    }
}
