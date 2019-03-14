using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IMarkerPool : IPool<IMarker>
    {
        /// <summary>
        /// Create a new marker.
        /// </summary>
        /// <param name="type">Model of the marker</param>
        /// <param name="position">Position of the marker</param>
        /// <param name="rotation">Rotation of the marker</param>
        /// <param name="direction">Direction of the marker</param>
        /// <param name="scale">Scale of the marker</param>
        /// <param name="color">Color of the marker</param>
        /// <param name="visible">Visible state of the marker</param>
        /// <param name="dimension">Dimension of the marker</param>
        /// <returns>New <see cref="IMarker" /> instance</returns>
        IMarker New(MarkerType type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension = MP.GlobalDimension);

        /// <summary>
        /// Create a new marker.
        /// </summary>
        /// <param name="type">Model of the marker</param>
        /// <param name="position">Position of the marker</param>
        /// <param name="rotation">Rotation of the marker</param>
        /// <param name="direction">Direction of the marker</param>
        /// <param name="scale">Scale of the marker</param>
        /// <param name="color">Color of the marker</param>
        /// <param name="visible">Visible state of the marker</param>
        /// <param name="dimension">Dimension of the marker</param>
        /// <returns>New <see cref="IMarker" /> instance</returns>
        Task<IMarker> NewAsync(MarkerType type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension = MP.GlobalDimension);

        /// <summary>
        /// Create a new marker.
        /// </summary>
        /// <param name="type">Model of the marker</param>
        /// <param name="position">Position of the marker</param>
        /// <param name="rotation">Rotation of the marker</param>
        /// <param name="direction">Direction of the marker</param>
        /// <param name="scale">Scale of the marker</param>
        /// <param name="color">Color of the marker</param>
        /// <param name="visible">Visible state of the marker</param>
        /// <param name="dimension">Dimension of the marker</param>
        /// <returns>New <see cref="IMarker" /> instance</returns>
        IMarker New(uint type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension = MP.GlobalDimension);

        /// <summary>
        /// Create a new marker.
        /// </summary>
        /// <param name="type">Model of the marker</param>
        /// <param name="position">Position of the marker</param>
        /// <param name="rotation">Rotation of the marker</param>
        /// <param name="direction">Direction of the marker</param>
        /// <param name="scale">Scale of the marker</param>
        /// <param name="color">Color of the marker</param>
        /// <param name="visible">Visible state of the marker</param>
        /// <param name="dimension">Dimension of the marker</param>
        /// <returns>New <see cref="IMarker" /> instance</returns>
        Task<IMarker> NewAsync(uint type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension = MP.GlobalDimension);

        /// <summary>
        /// Create a new marker.
        /// </summary>
        /// <param name="type">Model of the marker</param>
        /// <param name="position">Position of the marker</param>
        /// <param name="rotation">Rotation of the marker</param>
        /// <param name="direction">Direction of the marker</param>
        /// <param name="scale">Scale of the marker</param>
        /// <param name="color">Color of the marker</param>
        /// <param name="visible">Visible state of the marker</param>
        /// <param name="dimension">Dimension of the marker</param>
        /// <returns>New <see cref="IMarker" /> instance</returns>
        IMarker New(int type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension = MP.GlobalDimension);

        /// <summary>
        /// Create a new marker.
        /// </summary>
        /// <param name="type">Model of the marker</param>
        /// <param name="position">Position of the marker</param>
        /// <param name="rotation">Rotation of the marker</param>
        /// <param name="direction">Direction of the marker</param>
        /// <param name="scale">Scale of the marker</param>
        /// <param name="color">Color of the marker</param>
        /// <param name="visible">Visible state of the marker</param>
        /// <param name="dimension">Dimension of the marker</param>
        /// <returns>New <see cref="IMarker" /> instance</returns>
        Task<IMarker> NewAsync(int type, Vector3 position, Vector3 rotation, Vector3 direction, float scale, Color color, bool visible, uint dimension = MP.GlobalDimension);
    }
}
