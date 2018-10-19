using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IObjectPool : IPool<IObject>
    {
        Task<IObject> NewAsync(uint model, Vector3 position, Vector3 rotation, uint dimension = MP.GlobalDimension);
    }
}
