using System.Numerics;

namespace RageMP.Net.Interfaces
{
    public interface IColshape : IEntity
    {
        uint ShapeType { get; }

        bool IsPointWhithin(Vector3 position);
    }
}
