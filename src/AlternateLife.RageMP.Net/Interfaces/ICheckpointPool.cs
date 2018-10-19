using System.Numerics;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ICheckpointPool : IPool<ICheckpoint>
    {
        ICheckpoint New(uint type, Vector3 position, Vector3 nextPosition, float radius, ColorRgba color, bool visible = true, uint dimension = MP.GlobalDimension);
    }
}
