using System.Numerics;
using RageMP.Net.Enums;

namespace RageMP.Net.Interfaces
{
    public interface IColshape : IEntity
    {
        ColshapeType ShapeType { get; }

        bool IsPointWhithin(Vector3 position);
    }
}
