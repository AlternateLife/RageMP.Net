using System.Numerics;
using RageMP.Net.Data;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IMarkerPool : IPool<IMarker>
    {
        IMarker New(uint model, Vector3 position, Vector3 rotation, Vector3 direction, float scale, ColorRgba color, bool visible, uint dimension = MP.GlobalDimension);
    }
}
