using System.Numerics;

namespace RageMP.Net.Interfaces
{
    public interface IColshapePool : IPool<IColshape>
    {
        IColshape NewCircle(Vector2 position, float radius, uint dimension);
        IColshape NewSphere(Vector3 position, float radius, uint dimension);
        IColshape NewTube(Vector3 position, float radius, float height, uint dimension);
        IColshape NewRectangle(Vector2 position, Vector2 size, uint dimension);
        IColshape NewCube(Vector3 position, Vector3 size, uint dimension);
    }
}
