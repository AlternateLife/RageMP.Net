using System.Numerics;
using RageMP.Net.Data;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface ICheckpointPool : IPool<ICheckpoint>
    {
        ICheckpoint New(uint type, Vector3 position, Vector3 nextPosition, float radius, ColorRgba color, bool visible = true, uint dimension = MP.GlobalDimension);
    }
}
