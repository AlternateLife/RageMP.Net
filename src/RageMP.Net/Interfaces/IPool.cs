using System.Collections.Generic;
using System.Numerics;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IPool<T> : IReadOnlyList<T> where T : IEntity
    {
        T this[uint index] { get; }

        T GetAt(int index);
        T GetAt(uint index);

        IEnumerable<T> GetInRange(Vector3 position, float range, uint dimension = MP.GlobalDimension);
        IEnumerable<T> GetInDimension(uint dimension);
    }
}
