using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.EventArgs;
using AlternateLife.RageMP.Net.Exceptions;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IColshape : IEntity
    {
        event AsyncEventHandler<PlayerColshapeEventArgs> PlayerEnter;
        event AsyncEventHandler<PlayerColshapeEventArgs> PlayerExit;

        /// <summary>
        /// Get the type of the colshape.
        /// </summary>
        /// <returns>Type of the colshape</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        ColshapeType GetShapeType();

        /// <summary>
        /// Get the type of the colshape.
        /// </summary>
        /// <returns>Type of the colshape</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<ColshapeType> GetShapeTypeAsync();

        /// <summary>
        /// Check if a position is within the colshape.
        /// </summary>
        /// <param name="position">Position to check</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        /// <returns>True if the <paramref name="position" /> is inside the colshape, otherwise false</returns>
        bool IsPointWhithin(Vector3 position);

        /// <summary>
        /// Check if a position is within the colshape.
        /// </summary>
        /// <param name="position">Position to check</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        /// <returns>True if the <paramref name="position" /> is inside the colshape, otherwise false</returns>
        Task<bool> IsPointWhithinAsync(Vector3 position);
    }
}
