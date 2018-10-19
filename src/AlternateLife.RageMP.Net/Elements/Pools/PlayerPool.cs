using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Elements.Entities;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Pools
{
    internal class PlayerPool : PoolBase<IPlayer>, IPlayerPool
    {
        internal PlayerPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
        {
        }

        public void Broadcast(string message)
        {
            Contract.NotNull(message, nameof(message));

            using (var converter = new StringConverter())
            {
                Rage.PlayerPool.PlayerPool_Broadcast(_nativePointer, converter.StringToPointer(message));
            }
        }

        public void BroadcastInRange(string message, Vector3 position, float range, uint dimension)
        {
            Contract.NotNull(message, nameof(message));

            using (var converter = new StringConverter())
            {
                Rage.PlayerPool.PlayerPool_BroadcastInRange(_nativePointer, converter.StringToPointer(message), position, range, dimension);
            }
        }

        public void BroadcastInDimension(string message, uint dimension)
        {
            Contract.NotNull(message, nameof(message));

            using (var converter = new StringConverter())
            {
                Rage.PlayerPool.PlayerPool_BroadcastInDimension(_nativePointer, converter.StringToPointer(message), dimension);
            }
        }

        public void Call(string eventName, params object[] arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));

            var data = ArgumentData.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                Rage.PlayerPool.PlayerPool__Call(_nativePointer, converter.StringToPointer(eventName), data, (ulong) data.Length);
            }

            ArgumentData.Dispose(data);
        }

        public void CallInRange(Vector3 position, float range, uint dimension, string eventName, params object[] arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));

            var data = ArgumentData.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                Rage.PlayerPool.PlayerPool__CallInRange(_nativePointer, position, range, dimension, converter.StringToPointer(eventName), data, (ulong) data.Length);
            }

            ArgumentData.Dispose(data);
        }

        public void CallInDimension(uint dimension, string eventName, params object[] arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));

            var data = ArgumentData.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                Rage.PlayerPool.PlayerPool__CallInDimension(_nativePointer, dimension, converter.StringToPointer(eventName), data, (ulong) data.Length);
            }

            ArgumentData.Dispose(data);
        }

        public void CallFor(ICollection<IPlayer> players, string eventName, params object[] arguments)
        {
            Contract.NotNull(players, nameof(players));
            Contract.NotEmpty(eventName, nameof(eventName));

            var data = ArgumentData.ConvertFromObjects(arguments);
            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            using (var converter = new StringConverter())
            {
                Rage.PlayerPool.PlayerPool__CallFor(_nativePointer, playerPointers, (ulong) playerPointers.Length, converter.StringToPointer(eventName), data, (ulong) data.Length);
            }

            ArgumentData.Dispose(data);
        }

        public void Invoke(ulong nativeHash, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromObjects(arguments);

            Rage.PlayerPool.PlayerPool__Invoke(_nativePointer, nativeHash, data, (ulong) data.Length);

            ArgumentData.Dispose(data);
        }

        public void InvokeInRange(Vector3 position, float range, uint dimension, ulong nativeHash, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromObjects(arguments);

            Rage.PlayerPool.PlayerPool__InvokeInRange(_nativePointer, position, range, dimension, nativeHash, data, (ulong) data.Length);

            ArgumentData.Dispose(data);
        }

        public void InvokeInDimension(uint dimension, ulong nativeHash, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromObjects(arguments);

            Rage.PlayerPool.PlayerPool__InvokeInDimension(_nativePointer, dimension, nativeHash, data, (ulong) data.Length);

            ArgumentData.Dispose(data);
        }

        public void InvokeFor(ICollection<IPlayer> players, ulong nativeHash, params object[] arguments)
        {
            Contract.NotNull(players, nameof(players));

            var data = ArgumentData.ConvertFromObjects(arguments);
            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            Rage.PlayerPool.PlayerPool__InvokeFor(_nativePointer, playerPointers, (ulong) playerPointers.Length, nativeHash, data, (ulong) data.Length);

            ArgumentData.Dispose(data);
        }

        protected override IPlayer BuildEntity(IntPtr entityPointer)
        {
            return new Player(entityPointer, _plugin);
        }
    }

}
