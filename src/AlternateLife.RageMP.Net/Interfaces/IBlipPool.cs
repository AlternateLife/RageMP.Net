using System.Numerics;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IBlipPool : IPool<IBlip>
    {
        IBlip New(uint sprite, Vector3 position, float scale, uint color, string name = "", uint alpha = 255, float drawDistance = 10, bool shortRange = false, int rotation = 0,
            uint dimension = MP.GlobalDimension);
    }
}
