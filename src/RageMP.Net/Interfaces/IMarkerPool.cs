using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Data;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IMarkerPool : IPool<IMarker>
    {
        /// <summary>
        /// Create a new marker.
        /// </summary>
        /// <param name="model">Model of the marker</param>
        /// <param name="position">Position of the marker</param>
        /// <param name="rotation">Rotation of the marker</param>
        /// <param name="direction">Direction of the marker</param>
        /// <param name="scale">Scale of the marker</param>
        /// <param name="color">Color of the marker</param>
        /// <param name="visible">Visible state of the marker</param>
        /// <param name="dimension">Dimension of the marker</param>
        /// <returns>New marker instance</returns>
        Task<IMarker> NewAsync(uint model, Vector3 position, Vector3 rotation, Vector3 direction, float scale, ColorRgba color, bool visible, uint dimension = MP.GlobalDimension);
    }
}
