using System.Numerics;
using RageMP.Net.Data;

namespace RageMP.Net.Interfaces
{
    public interface ICheckpointPool : IPool<ICheckpoint>
    {
        ICheckpoint New(uint type, Vector3 position, Vector3 nextPosition, float radius, ColorRgba color, bool visible, uint dimension);
    }
}
