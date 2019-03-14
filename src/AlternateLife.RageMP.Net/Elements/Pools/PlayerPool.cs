using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Elements.Entities;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Pools
{
    internal class PlayerPool : PoolBase<IPlayer>, IPlayerPool
    {
        public PlayerPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
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

        public Task BroadcastAsync(string message)
        {
            return _plugin.Schedule(() => Broadcast(message));
        }

        public void Broadcast(string message, Vector3 position, float range, uint dimension)
        {
            Contract.NotNull(message, nameof(message));

            using (var converter = new StringConverter())
            {
                Rage.PlayerPool.PlayerPool_BroadcastInRange(_nativePointer, converter.StringToPointer(message), position, range, dimension);
            }
        }

        public Task BroadcastAsync(string message, Vector3 position, float range, uint dimension)
        {
            return _plugin.Schedule(() => Broadcast(message, position, range, dimension));
        }

        public void Broadcast(string message, uint dimension)
        {
            Contract.NotNull(message, nameof(message));

            using (var converter = new StringConverter())
            {
                Rage.PlayerPool.PlayerPool_BroadcastInDimension(_nativePointer, converter.StringToPointer(message), dimension);
            }
        }

        public Task BroadcastAsync(string message, uint dimension)
        {
            return _plugin.Schedule(() => Broadcast(message, dimension));
        }

        public void Call(string eventName, params object[] arguments)
        {
            Call(eventName, (IEnumerable<object>) arguments);
        }

        public Task CallAsync(string eventName, params object[] arguments)
        {
            return CallAsync(eventName, (IEnumerable<object>) arguments);
        }

        public void Call(string eventName, IEnumerable<object> arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                Rage.PlayerPool.PlayerPool__Call(_nativePointer, converter.StringToPointer(eventName), data, (ulong) data.LongLength);
            }

            ArgumentData.Dispose(data);
        }

        public Task CallAsync(string eventName, IEnumerable<object> arguments)
        {
            return _plugin.Schedule(() => Call(eventName, arguments));
        }

        public void Call(Vector3 position, float range, uint dimension, string eventName, params object[] arguments)
        {
            Call(position, range, dimension, eventName, (IEnumerable<object>) arguments);
        }

        public Task CallAsync(Vector3 position, float range, uint dimension, string eventName, params object[] arguments)
        {
            return CallAsync(position, range, dimension, eventName, (IEnumerable<object>) arguments);
        }

        public void Call(Vector3 position, float range, uint dimension, string eventName, IEnumerable<object> arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                var eventNamePointer = converter.StringToPointer(eventName);

                Rage.PlayerPool.PlayerPool__CallInRange(_nativePointer, position, range, dimension, eventNamePointer, data, (ulong) data.LongLength);
            }

            ArgumentData.Dispose(data);
        }

        public Task CallAsync(Vector3 position, float range, uint dimension, string eventName, IEnumerable<object> arguments)
        {
            return _plugin.Schedule(() => Call(position, range, dimension, eventName, arguments));
        }

        public void Call(uint dimension, string eventName, params object[] arguments)
        {
            Call(dimension, eventName, (IEnumerable<object>) arguments);
        }

        public Task CallAsync(uint dimension, string eventName, params object[] arguments)
        {
            return CallAsync(dimension, eventName, (IEnumerable<object>) arguments);
        }

        public void Call(uint dimension, string eventName, IEnumerable<object> arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                Rage.PlayerPool.PlayerPool__CallInDimension(_nativePointer, dimension, converter.StringToPointer(eventName), data, (ulong) data.LongLength);
            }

            ArgumentData.Dispose(data);
        }

        public Task CallAsync(uint dimension, string eventName, IEnumerable<object> arguments)
        {
            return _plugin.Schedule(() => Call(dimension, eventName, arguments));
        }

        public void Call(IEnumerable<IPlayer> players, string eventName, params object[] arguments)
        {
            Call(players, eventName, (IEnumerable<object>) arguments);
        }

        public Task CallAsync(IEnumerable<IPlayer> players, string eventName, params object[] arguments)
        {
            return CallAsync(players, eventName, (IEnumerable<object>) arguments);
        }

        public void Call(IEnumerable<IPlayer> players, string eventName, IEnumerable<object> arguments)
        {
            Contract.NotNull(players, nameof(players));
            Contract.NotEmpty(eventName, nameof(eventName));
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);
            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            if (playerPointers.Any() == false)
            {
                return;
            }

            using (var converter = new StringConverter())
            {
                var eventNamePointer = converter.StringToPointer(eventName);

                Rage.PlayerPool.PlayerPool__CallFor(_nativePointer, playerPointers, (ulong) playerPointers.LongLength, eventNamePointer, data, (ulong) data.LongLength);
            }

            ArgumentData.Dispose(data);
        }

        public Task CallAsync(IEnumerable<IPlayer> players, string eventName, IEnumerable<object> arguments)
        {
            return _plugin.Schedule(() => Call(players, eventName, arguments));
        }

        public void Invoke(ulong nativeHash, params object[] arguments)
        {
            Invoke(nativeHash, (IEnumerable<object>) arguments);
        }

        public Task InvokeAsync(ulong nativeHash, params object[] arguments)
        {
            return InvokeAsync(nativeHash, (IEnumerable<object>) arguments);
        }

        public void Invoke(ulong nativeHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            Rage.PlayerPool.PlayerPool__Invoke(_nativePointer, nativeHash, data, (ulong) data.LongLength);

            ArgumentData.Dispose(data);
        }

        public Task InvokeAsync(ulong nativeHash, IEnumerable<object> arguments)
        {
            return _plugin.Schedule(() => Invoke(nativeHash, arguments));
        }

        public void Invoke(Vector3 position, float range, uint dimension, ulong nativeHash, params object[] arguments)
        {
            Invoke(position, range, dimension, nativeHash, (IEnumerable<object>) arguments);
        }

        public Task InvokeAsync(Vector3 position, float range, uint dimension, ulong nativeHash, params object[] arguments)
        {
            return InvokeAsync(position, range, dimension, nativeHash, (IEnumerable<object>) arguments);
        }

        public void Invoke(Vector3 position, float range, uint dimension, ulong nativeHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            Rage.PlayerPool.PlayerPool__InvokeInRange(_nativePointer, position, range, dimension, nativeHash, data, (ulong) data.LongLength);

            ArgumentData.Dispose(data);
        }

        public Task InvokeAsync(Vector3 position, float range, uint dimension, ulong nativeHash, IEnumerable<object> arguments)
        {
            return _plugin.Schedule(() => Invoke(position, range, dimension, nativeHash, arguments));
        }

        public void Invoke(uint dimension, ulong nativeHash, params object[] arguments)
        {
            Invoke(dimension, nativeHash, (IEnumerable<object>) arguments);
        }

        public Task InvokeAsync(uint dimension, ulong nativeHash, params object[] arguments)
        {
            return InvokeAsync(dimension, nativeHash, (IEnumerable<object>) arguments);
        }

        public void Invoke(uint dimension, ulong nativeHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            Rage.PlayerPool.PlayerPool__InvokeInDimension(_nativePointer, dimension, nativeHash, data, (ulong) data.LongLength);

            ArgumentData.Dispose(data);
        }

        public Task InvokeAsync(uint dimension, ulong nativeHash, IEnumerable<object> arguments)
        {
            return _plugin.Schedule(() => Invoke(dimension, nativeHash, arguments));
        }

        public void Invoke(IEnumerable<IPlayer> players, ulong nativeHash, params object[] arguments)
        {
            Invoke(players, nativeHash, (IEnumerable<object>) arguments);
        }

        public Task InvokeAsync(IEnumerable<IPlayer> players, ulong nativeHash, params object[] arguments)
        {
            return InvokeAsync(players, nativeHash, (IEnumerable<object>) arguments);
        }

        public void Invoke(IEnumerable<IPlayer> players, ulong nativeHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(players, nameof(players));
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);
            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            Rage.PlayerPool.PlayerPool__InvokeFor(_nativePointer, playerPointers, (ulong) playerPointers.LongLength, nativeHash, data, (ulong) data.LongLength);

            ArgumentData.Dispose(data);
        }

        public Task InvokeAsync(IEnumerable<IPlayer> players, ulong nativeHash, IEnumerable<object> arguments)
        {
            return _plugin.Schedule(() => Invoke(players, nativeHash, arguments));
        }

        protected override IPlayer BuildEntity(IntPtr entityPointer)
        {
            return new Player(entityPointer, _plugin);
        }
    }

}
