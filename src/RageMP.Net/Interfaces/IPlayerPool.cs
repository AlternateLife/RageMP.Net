using System.Numerics;

namespace RageMP.Net.Interfaces
{
    public interface IPlayerPool : IPool<IPlayer>
    {
        void Broadcast(string message);
        void BroadcastInRange(string message, Vector3 position, float range, uint dimension);
        void BroadcastInDimension(string message, uint dimension);
    }
}
