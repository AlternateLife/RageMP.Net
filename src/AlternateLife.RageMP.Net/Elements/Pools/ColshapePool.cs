using System;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Elements.Entities;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Pools
{
    internal class ColshapePool : PoolBase<IColshape>, IColshapePool
    {
        public ColshapePool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public IColshape NewCircle(Vector2 position, float radius, uint dimension)
        {
            var pointer = Rage.ColshapePool.ColshapePool_NewCircle(_nativePointer, position, radius, dimension);

            return CreateAndSaveEntity(pointer);
        }

        public Task<IColshape> NewCircleAsync(Vector2 position, float radius, uint dimension)
        {
            return _plugin.Schedule(() => NewCircle(position, radius, dimension));
        }

        public IColshape NewSphere(Vector3 position, float radius, uint dimension)
        {
            var pointer = Rage.ColshapePool.ColshapePool_NewSphere(_nativePointer, position, radius, dimension);

            return CreateAndSaveEntity(pointer);
        }

        public Task<IColshape> NewSphereAsync(Vector3 position, float radius, uint dimension)
        {
            return _plugin.Schedule(() => NewSphere(position, radius, dimension));
        }

        public IColshape NewTube(Vector3 position, float radius, float height, uint dimension)
        {
            var pointer = Rage.ColshapePool.ColshapePool_NewTube(_nativePointer, position, radius, height, dimension);

            return CreateAndSaveEntity(pointer);
        }

        public Task<IColshape> NewTubeAsync(Vector3 position, float radius, float height, uint dimension)
        {
            return _plugin.Schedule(() => NewTube( position, radius, height, dimension));
        }

        public IColshape NewRectangle(Vector2 position, Vector2 size, uint dimension)
        {
            var pointer = Rage.ColshapePool.ColshapePool_NewRectangle(_nativePointer, position, size, dimension);

            return CreateAndSaveEntity(pointer);
        }

        public Task<IColshape> NewRectangleAsync(Vector2 position, Vector2 size, uint dimension)
        {
            return _plugin.Schedule(() => NewRectangle(position, size, dimension));
        }

        public IColshape NewCube(Vector3 position, Vector3 size, uint dimension)
        {
            var pointer = Rage.ColshapePool.ColshapePool_NewCube(_nativePointer, position, size, dimension);

            return CreateAndSaveEntity(pointer);
        }

        public Task<IColshape> NewCubeAsync(Vector3 position, Vector3 size, uint dimension)
        {
            return _plugin.Schedule(() => NewCube(position, size, dimension));
        }

        protected override IColshape BuildEntity(IntPtr entityPointer)
        {
            return new Colshape(entityPointer, _plugin);
        }
    }
}
