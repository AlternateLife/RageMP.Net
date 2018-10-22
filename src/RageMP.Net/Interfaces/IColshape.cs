using System.Numerics;
using RageMP.Net.Enums;

namespace RageMP.Net.Interfaces
{
    public interface IColshape : IEntity
    {
        /// <summary>
        /// Get the type of the colshape.
        /// </summary>
        ColshapeType ShapeType { get; }

        /// <summary>
        /// Check if a position is within the colshape.
        /// </summary>
        /// <param name="position">Position to check</param>
        /// <returns>True if the <paramref name="position" /> is inside the colshape, otherwise false</returns>
        bool IsPointWhithin(Vector3 position);
    }
}
