using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using RageMP.Net.Data;
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

        public void Call(string eventName, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromArguments(arguments);

            Rage.PlayerPool.PlayerPool__Call(_nativePointer, eventName, data, (ulong) data.Length);
        }

        public void CallInRange(Vector3 position, float range, uint dimension, string eventName, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromArguments(arguments);

            Rage.PlayerPool.PlayerPool__CallInRange(_nativePointer, position, range, dimension, eventName, data, (ulong) data.Length);
        }

        public void CallInDimension(uint dimension, string eventName, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromArguments(arguments);

            Rage.PlayerPool.PlayerPool__CallInDimension(_nativePointer, dimension, eventName, data, (ulong) data.Length);
        }

        public void CallFor(ICollection<IPlayer> players, string eventName, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromArguments(arguments);
            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            Rage.PlayerPool.PlayerPool__CallFor(_nativePointer, playerPointers, (ulong) playerPointers.Length, eventName, data, (ulong) data.Length);
        }

        public void Invoke(ulong nativeHash, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromArguments(arguments);

            Rage.PlayerPool.PlayerPool__Invoke(_nativePointer, nativeHash, data, (ulong) data.Length);
        }

        public void InvokeInRange(Vector3 position, float range, uint dimension, ulong nativeHash, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromArguments(arguments);

            Rage.PlayerPool.PlayerPool__InvokeInRange(_nativePointer, position, range, dimension, nativeHash, data, (ulong) data.Length);
        }

        public void InvokeInDimension(uint dimension, ulong nativeHash, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromArguments(arguments);

            Rage.PlayerPool.PlayerPool__InvokeInDimension(_nativePointer, dimension, nativeHash, data, (ulong) data.Length);
        }

        public void InvokeFor(ICollection<IPlayer> players, ulong nativeHash, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromArguments(arguments);
            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            Rage.PlayerPool.PlayerPool__InvokeFor(_nativePointer, playerPointers, (ulong) playerPointers.Length, nativeHash, data, (ulong) data.Length);
        }
    }
}
