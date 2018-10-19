using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface IPlayerPool : IPool<IPlayer>
    {
        Task BroadcastAsync(string message);
        Task BroadcastInRangeAsync(string message, Vector3 position, float range, uint dimension = MP.GlobalDimension);
        Task BroadcastInDimensionAsync(string message, uint dimension);

        Task CallAsync(string eventName, params object[] arguments);
        Task CallInRangeAsync(Vector3 position, float range, uint dimension, string eventName, params object[] arguments);
        Task CallInDimensionAsync(uint dimension, string eventName, params object[] arguments);
        Task CallForAsync(ICollection<IPlayer> players, string eventName, params object[] arguments);

        Task InvokeAsync(ulong nativeHash, params object[] arguments);
        Task InvokeInRangeAsync(Vector3 position, float range, uint dimension, ulong nativeHash, params object[] arguments);
        Task InvokeInDimensionAsync(uint dimension, ulong nativeHash, params object[] arguments);
        Task InvokeForAsync(ICollection<IPlayer> players, ulong nativeHash, params object[] arguments);
    }
}
