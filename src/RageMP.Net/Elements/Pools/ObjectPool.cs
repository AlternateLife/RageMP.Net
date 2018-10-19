using System;
using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;
using Object = RageMP.Net.Elements.Entities.Object;

namespace RageMP.Net.Elements.Pools
{
    internal class ObjectPool : PoolBase<IObject>, IObjectPool
    {
        public ObjectPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public async Task<IObject> NewAsync(uint model, Vector3 position, Vector3 rotation, uint dimension)
        {
            var pointer = await _plugin
                .Schedule(() => Rage.ObjectPool.ObjectPool_New(_nativePointer, model, position, rotation, dimension))
                .ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        protected override IObject BuildEntity(IntPtr entityPointer)
        {
            return new Object(entityPointer, _plugin);
        }
    }
}
