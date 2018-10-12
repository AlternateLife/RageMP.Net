using System;
using System.Numerics;
using RageMP.Net.Data;
using RageMP.Net.Entities;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Scripting.ScriptingClasses
{
    internal class CheckpointPool : PoolBase<ICheckpoint>, ICheckpointPool
    {
        internal CheckpointPool(IntPtr nativePointer) : base(nativePointer)
        {
        }

        public ICheckpoint New(uint type, Vector3 position, Vector3 nextPosition, float radius, ColorRgba color, bool visible, uint dimension)
        {
            var pointer = Rage.CheckpointPool.CheckpointPool_New(_nativePointer, type, position, nextPosition, radius, color, visible, dimension);

            return new Checkpoint(pointer);
        }
    }
}
