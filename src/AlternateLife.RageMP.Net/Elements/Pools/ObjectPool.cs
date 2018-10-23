using System;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;
using AlternateLife.RageMP.Net.Scripting;
using Object = AlternateLife.RageMP.Net.Elements.Entities.Object;

namespace AlternateLife.RageMP.Net.Elements.Pools
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

        public Task<IObject> NewAsync(int model, Vector3 position, Vector3 rotation, uint dimension)
        {
            return NewAsync((uint) model, position, rotation, dimension);
        }

        protected override IObject BuildEntity(IntPtr entityPointer)
        {
            return new Entities.Object(entityPointer, _plugin);
        }
    }
}
