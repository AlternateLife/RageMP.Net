using System;
using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Elements.Entities;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Elements.Pools
{
    internal class ColshapePool : PoolBase<IColshape>, IColshapePool
    {
        internal ColshapePool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public async Task<IColshape> NewCircleAsync(Vector2 position, float radius, uint dimension)
        {
            var pointer = await _plugin
                .Schedule(() => Rage.ColshapePool.ColshapePool_NewCircle(_nativePointer, position, radius, dimension))
                .ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        public async Task<IColshape> NewSphereAsync(Vector3 position, float radius, uint dimension)
        {
            var pointer = await _plugin
                .Schedule(() => Rage.ColshapePool.ColshapePool_NewSphere(_nativePointer, position, radius, dimension))
                .ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        public async Task<IColshape> NewTubeAsync(Vector3 position, float radius, float height, uint dimension)
        {
            var pointer = await _plugin
                .Schedule(() => Rage.ColshapePool.ColshapePool_NewTube(_nativePointer, position, radius, height, dimension))
                .ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        public async Task<IColshape> NewRectangleAsync(Vector2 position, Vector2 size, uint dimension)
        {
            var pointer = await _plugin
                .Schedule(() => Rage.ColshapePool.ColshapePool_NewRectangle(_nativePointer, position, size, dimension))
                .ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        public async Task<IColshape> NewCubeAsync(Vector3 position, Vector3 size, uint dimension)
        {
            var pointer = await _plugin
                .Schedule(() => Rage.ColshapePool.ColshapePool_NewCube(_nativePointer, position, size, dimension))
                .ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        protected override IColshape BuildEntity(IntPtr entityPointer)
        {
            return new Colshape(entityPointer, _plugin);
        }
    }
}
