using System;
using System.Numerics;
using RageMP.Net.Entities;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Scripting.ScriptingClasses
{
    internal class ColshapePool : PoolBase<IColshape>, IColshapePool
    {
        internal ColshapePool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public IColshape NewCircle(Vector2 position, float radius, uint dimension)
        {
            var pointer = Rage.ColshapePool.ColshapePool_NewCircle(_nativePointer, position, radius, dimension);

            return new Colshape(pointer, _plugin);
        }

        public IColshape NewSphere(Vector3 position, float radius, uint dimension)
        {
            var pointer = Rage.ColshapePool.ColshapePool_NewSphere(_nativePointer, position, radius, dimension);

            return new Colshape(pointer, _plugin);
        }

        public IColshape NewTube(Vector3 position, float radius, float height, uint dimension)
        {
            var pointer = Rage.ColshapePool.ColshapePool_NewTube(_nativePointer, position, radius, height, dimension);

            return new Colshape(pointer, _plugin);
        }

        public IColshape NewRectangle(Vector2 position, Vector2 size, uint dimension)
        {
            var pointer = Rage.ColshapePool.ColshapePool_NewRectangle(_nativePointer, position, size, dimension);

            return new Colshape(pointer, _plugin);
        }

        public IColshape NewCube(Vector3 position, Vector3 size, uint dimension)
        {
            var pointer = Rage.ColshapePool.ColshapePool_NewCube(_nativePointer, position, size, dimension);

            return new Colshape(pointer, _plugin);
        }
    }
}
