using System.Numerics;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IBlipPool : IPool<IBlip>
    {
        IBlip New(uint sprite, Vector3 position, float scale, uint color, string name = "", uint alpha = 255, float drawDistance = 0, bool shortRange = false, int rotation = 0, uint dimension = MP.GlobalDimension);
    }
}
