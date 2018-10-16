using System.Numerics;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IColshapePool : IPool<IColshape>
    {
        IColshape NewCircle(Vector2 position, float radius, uint dimension = MP.GlobalDimension);
        IColshape NewSphere(Vector3 position, float radius, uint dimension = MP.GlobalDimension);
        IColshape NewTube(Vector3 position, float radius, float height, uint dimension = MP.GlobalDimension);
        IColshape NewRectangle(Vector2 position, Vector2 size, uint dimension = MP.GlobalDimension);
        IColshape NewCube(Vector3 position, Vector3 size, uint dimension = MP.GlobalDimension);
    }
}
