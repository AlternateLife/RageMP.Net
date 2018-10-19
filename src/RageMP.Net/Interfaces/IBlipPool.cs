using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IBlipPool : IPool<IBlip>
    {
        Task<IBlip> NewAsync(uint sprite, Vector3 position, float scale, uint color, string name = "", uint alpha = 255, float drawDistance = 10, bool shortRange = false, int rotation = 0,
            uint dimension = MP.GlobalDimension);
    }
}
