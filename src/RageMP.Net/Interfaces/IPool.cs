using System.Collections.Generic;
using System.Numerics;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IPool<T> : IReadOnlyList<T> where T : IEntity
    {
        /// <summary>
        /// Get entity with given entity id.
        /// </summary>
        /// <param name="index">Entity id to search for</param>
        /// <returns>Entity if found, otherwise null</returns>
        T this[uint index] { get; }

        /// <summary>
        /// Get entity with given entity id.
        /// </summary>
        /// <param name="index">Entity id to search for</param>
        /// <returns>Entity if found, otherwise null</returns>
        T GetAt(int index);

        /// <summary>
        /// Get entity with given entity id.
        /// </summary>
        /// <param name="index">Entity id to search for</param>
        /// <returns>Entity if found, otherwise null</returns>
        T GetAt(uint index);

        /// <summary>
        /// Get a list of entities at given position.
        /// </summary>
        /// <param name="position">Position to search entities at</param>
        /// <param name="range">Range to search entities in</param>
        /// <param name="dimension">Dimension to search entities in</param>
        /// <returns>List of found entities</returns>
        IReadOnlyCollection<T> GetInRange(Vector3 position, float range, uint dimension = MP.GlobalDimension);

        /// <summary>
        /// Get a list of entities in given dimension.
        /// </summary>
        /// <param name="dimension">Dimension to search entities in</param>
        /// <returns>List of found entities</returns>
        IReadOnlyCollection<T> GetInDimension(uint dimension);
    }
}
