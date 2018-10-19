using System.Numerics;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IObjectPool : IPool<IObject>
    {
        IObject New(uint model, Vector3 position, Vector3 rotation, uint dimension = MP.GlobalDimension);
    }
}
