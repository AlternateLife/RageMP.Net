using System;
using System.Numerics;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Scripting.ScriptingClasses
{
    internal class PlayerPool : PoolBase<IPlayer>, IPlayerPool
    {
        public PlayerPool(IntPtr nativePointer) : base(nativePointer)
        {
        }

        public void Broadcast(string message)
        {
            Rage.PlayerPool.PlayerPool_Broadcast(_nativePointer, message);
        }

        public void BroadcastInRange(string message, Vector3 position, float range, uint dimension)
        {
            Rage.PlayerPool.PlayerPool_BroadcastInRange(_nativePointer, message, position, range, dimension);
        }

        public void BroadcastInDimension(string message, uint dimension)
        {
            Rage.PlayerPool.PlayerPool_BroadcastInDimension(_nativePointer, message, dimension);
        }
    }
}
