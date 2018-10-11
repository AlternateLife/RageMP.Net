using System.Collections.Generic;
using System.Numerics;

namespace RageMP.Net.Interfaces
{
    public interface IPlayerPool : IPool<IPlayer>
    {
        void Broadcast(string message);
        void BroadcastInRange(string message, Vector3 position, float range, uint dimension);
        void BroadcastInDimension(string message, uint dimension);

        void Call(string eventName, params object[] arguments);
        void CallInRange(Vector3 position, float range, uint dimension, string eventName, params object[] arguments);
        void CallInDimension(uint dimension, string eventName, params object[] arguments);
        void CallFor(ICollection<IPlayer> players, string eventName, params object[] arguments);

        void Invoke(ulong nativeHash, params object[] arguments);
        void InvokeInRange(Vector3 position, float range, uint dimension, ulong nativeHash, params object[] arguments);
        void InvokeInDimension(uint dimension, ulong nativeHash, params object[] arguments);
        void InvokeFor(ICollection<IPlayer> players, ulong nativeHash, params object[] arguments);
    }
}
