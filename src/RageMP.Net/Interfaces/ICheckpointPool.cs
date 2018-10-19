using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Data;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface ICheckpointPool : IPool<ICheckpoint>
    {
        Task<ICheckpoint> NewAsync(uint type, Vector3 position, Vector3 nextPosition, float radius, ColorRgba color, bool visible = true, uint dimension = MP.GlobalDimension);
    }
}
