using System.Numerics;

namespace RageMP.Net.Interfaces
{
    public interface IBlipPool : IPool<IBlip>
    {
        IBlip New(uint sprite, Vector3 position, float scale, uint color, string name, uint alpha, float drawDistance, bool shortRange, int rotation, uint dimension);
    }
}
