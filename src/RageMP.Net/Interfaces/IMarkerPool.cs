using System.Numerics;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IMarkerPool : IPool<IMarker>
    {
        IMarker New(uint model, Vector3 position, Vector3 rotation, Vector3 direction, float scale, ColorRgba color, bool visible, uint dimension = MP.GlobalDimension);
    }
}
