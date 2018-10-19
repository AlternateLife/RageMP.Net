using System;
using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Data;
using RageMP.Net.Elements.Entities;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Elements.Pools
{
    internal class CheckpointPool : PoolBase<ICheckpoint>, ICheckpointPool
    {
        internal CheckpointPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public async Task<ICheckpoint> NewAsync(uint type, Vector3 position, Vector3 nextPosition, float radius, ColorRgba color, bool visible, uint dimension)
        {
            var pointer = await _plugin
                .Schedule(() => Rage.CheckpointPool.CheckpointPool_New(_nativePointer, type, position, nextPosition, radius, color, visible, dimension))
                .ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        protected override ICheckpoint BuildEntity(IntPtr entityPointer)
        {
            return new Checkpoint(entityPointer, _plugin);
        }
    }
}
