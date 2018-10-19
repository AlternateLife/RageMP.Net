using System;
using System.Numerics;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;
using Object = AlternateLife.RageMP.Net.Elements.Entities.Object;

namespace AlternateLife.RageMP.Net.Elements.Pools
{
    internal class ObjectPool : PoolBase<IObject>, IObjectPool
    {
        public ObjectPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public IObject New(uint model, Vector3 position, Vector3 rotation, uint dimension)
        {
            var pointer = Rage.ObjectPool.ObjectPool_New(_nativePointer, model, position, rotation, dimension);

            return CreateAndSaveEntity(pointer);
        }

        protected override IObject BuildEntity(IntPtr entityPointer)
        {
            return new Entities.Object(entityPointer, _plugin);
        }
    }
}
