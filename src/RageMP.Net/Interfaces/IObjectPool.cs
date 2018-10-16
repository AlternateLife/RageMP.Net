using System.Numerics;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IObjectPool : IPool<IObject>
    {
        IObject New(uint model, Vector3 position, Vector3 rotation, uint dimension = MP.GlobalDimension);
    }
}
