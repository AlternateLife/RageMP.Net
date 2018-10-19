using System.Collections.Generic;
using System.Numerics;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IPool<T> : IReadOnlyList<T> where T : IEntity
    {
        T this[uint index] { get; }

        T GetAt(int index);
        T GetAt(uint index);

        IReadOnlyCollection<T> GetInRange(Vector3 position, float range, uint dimension = MP.GlobalDimension);
        IReadOnlyCollection<T> GetInDimension(uint dimension);
    }
}
