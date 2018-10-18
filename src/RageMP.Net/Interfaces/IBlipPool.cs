using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IBlipPool : IPool<IBlip>
    {
        /// <summary>
        /// Create a new blip.
        /// </summary>
        /// <param name="sprite">Sprite number for the blip</param>
        /// <param name="position">Position of the blip</param>
        /// <param name="scale">Scale of the blip</param>
        /// <param name="color">Color number of the blip</param>
        /// <param name="name">Name of the blip</param>
        /// <param name="alpha">Alpha of the blip</param>
        /// <param name="drawDistance">Draw distance of the blip</param>
        /// <param name="shortRange">Short range flag of the blip</param>
        /// <param name="rotation">Rotation of the blip</param>
        /// <param name="dimension">Dimension of the blip</param>
        /// <returns>New blip instance</returns>
        Task<IBlip> NewAsync(uint sprite, Vector3 position, float scale, uint color, string name = "", uint alpha = 255, float drawDistance = 10, bool shortRange = false,
            int rotation = 0, uint dimension = MP.GlobalDimension);
    }
}
