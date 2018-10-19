using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IColshapePool : IPool<IColshape>
    {
        Task<IColshape> NewCircleAsync(Vector2 position, float radius, uint dimension = MP.GlobalDimension);
        Task<IColshape> NewSphereAsync(Vector3 position, float radius, uint dimension = MP.GlobalDimension);
        Task<IColshape> NewTubeAsync(Vector3 position, float radius, float height, uint dimension = MP.GlobalDimension);
        Task<IColshape> NewRectangleAsync(Vector2 position, Vector2 size, uint dimension = MP.GlobalDimension);
        Task<IColshape> NewCubeAsync(Vector3 position, Vector3 size, uint dimension = MP.GlobalDimension);
    }
}
