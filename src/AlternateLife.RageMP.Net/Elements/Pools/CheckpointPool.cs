using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Elements.Entities;
using AlternateLife.RageMP.Net.Extensions;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Pools
{
    internal class CheckpointPool : PoolBase<ICheckpoint>, ICheckpointPool
    {
        public CheckpointPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public async Task<ICheckpoint> NewAsync(uint type, Vector3 position, Vector3 nextPosition, float radius, Color color, bool visible, uint dimension)
        {
            var pointer = await _plugin
                .Schedule(() => Rage.CheckpointPool.CheckpointPool_New(_nativePointer, type, position, nextPosition, radius, color.GetNumberValue(), visible, dimension))
                .ConfigureAwait(false);

            return CreateAndSaveEntity(pointer);
        }

        public Task<ICheckpoint> NewAsync(int type, Vector3 position, Vector3 nextPosition, float radius, Color color, bool visible, uint dimension)
        {
            return NewAsync((uint) type, position, nextPosition, radius, color, visible, dimension);
        }

        protected override ICheckpoint BuildEntity(IntPtr entityPointer)
        {
            return new Checkpoint(entityPointer, _plugin);
        }
    }
}
