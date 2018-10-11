using System.Collections.Generic;

namespace RageMP.Net.Interfaces
{
    public interface IPool<T> : IReadOnlyList<T> where T : IEntity
    {
        T this[uint index] { get; }

        T GetAt(int index);
        T GetAt(uint index);
    }
}
