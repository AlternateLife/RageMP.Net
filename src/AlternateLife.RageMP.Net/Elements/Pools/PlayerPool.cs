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

        public async Task BroadcastAsync(string message)
        {
            Contract.NotNull(message, nameof(message));

            using (var converter = new StringConverter())
            {
                var messagePointer = converter.StringToPointer(message);

                await _plugin
                    .Schedule(() => Rage.PlayerPool.PlayerPool_Broadcast(_nativePointer, messagePointer))
                    .ConfigureAwait(false);
            }
        }

        public async Task BroadcastAsync(string message, Vector3 position, float range, uint dimension)
        {
            Contract.NotNull(message, nameof(message));

            using (var converter = new StringConverter())
            {
                var messagePointer = converter.StringToPointer(message);

                await _plugin
                    .Schedule(() => Rage.PlayerPool.PlayerPool_BroadcastInRange(_nativePointer, messagePointer, position, range, dimension))
                    .ConfigureAwait(false);
            }
        }

        public async Task BroadcastAsync(string message, uint dimension)
        {
            Contract.NotNull(message, nameof(message));

            using (var converter = new StringConverter())
            {
                var messagePointer = converter.StringToPointer(message);

                await _plugin
                    .Schedule(() => Rage.PlayerPool.PlayerPool_BroadcastInDimension(_nativePointer, messagePointer, dimension))
                    .ConfigureAwait(false);
            }
        }

        public Task CallAsync(string eventName, params object[] arguments)
        {
            return CallAsync(eventName, (IEnumerable<object>) arguments);
        }

        public async Task CallAsync(string eventName, IEnumerable<object> arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                var eventNamePointer = converter.StringToPointer(eventName);

                await _plugin
                    .Schedule(() => Rage.PlayerPool.PlayerPool__Call(_nativePointer, eventNamePointer, data, (ulong) data.LongLength))
                    .ConfigureAwait(false);
            }

            ArgumentData.Dispose(data);
        }

        public Task CallAsync(Vector3 position, float range, uint dimension, string eventName, params object[] arguments)
        {
            return CallAsync(position, range, dimension, eventName, (IEnumerable<object>) arguments);
        }

        public async Task CallAsync(Vector3 position, float range, uint dimension, string eventName, IEnumerable<object> arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                var eventNamePointer = converter.StringToPointer(eventName);

                await _plugin
                    .Schedule(() => Rage.PlayerPool.PlayerPool__CallInRange(_nativePointer, position, range, dimension, eventNamePointer, data, (ulong) data.LongLength))
                    .ConfigureAwait(false);
            }

            ArgumentData.Dispose(data);
        }

        public Task CallAsync(uint dimension, string eventName, params object[] arguments)
        {
            return CallAsync(dimension, eventName, (IEnumerable<object>) arguments);
        }

        public async Task CallAsync(uint dimension, string eventName, IEnumerable<object> arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                var eventNamePointer = converter.StringToPointer(eventName);

                await _plugin
                    .Schedule(() => Rage.PlayerPool.PlayerPool__CallInDimension(_nativePointer, dimension, eventNamePointer, data, (ulong) data.LongLength))
                    .ConfigureAwait(false);
            }

            ArgumentData.Dispose(data);
        }

        public Task CallAsync(IEnumerable<IPlayer> players, string eventName, params object[] arguments)
        {
            return CallAsync(players, eventName, (IEnumerable<object>) arguments);
        }

        public async Task CallAsync(IEnumerable<IPlayer> players, string eventName, IEnumerable<object> arguments)
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

                await _plugin
                    .Schedule(() => Rage.PlayerPool.PlayerPool__CallFor(_nativePointer, playerPointers, (ulong) playerPointers.LongLength, eventNamePointer, data, (ulong) data.LongLength))
                    .ConfigureAwait(false);
            }

            ArgumentData.Dispose(data);
        }

        public Task InvokeAsync(ulong nativeHash, params object[] arguments)
        {
            return InvokeAsync(nativeHash, (IEnumerable<object>) arguments);
        }

        public async Task InvokeAsync(ulong nativeHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            await _plugin
                .Schedule(() => Rage.PlayerPool.PlayerPool__Invoke(_nativePointer, nativeHash, data, (ulong) data.LongLength))
                .ConfigureAwait(false);

            ArgumentData.Dispose(data);
        }

        public Task InvokeAsync(Vector3 position, float range, uint dimension, ulong nativeHash, params object[] arguments)
        {
            return InvokeAsync(position, range, dimension, nativeHash, (IEnumerable<object>) arguments);
        }

        public async Task InvokeAsync(Vector3 position, float range, uint dimension, ulong nativeHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            await _plugin
                .Schedule(() => Rage.PlayerPool.PlayerPool__InvokeInRange(_nativePointer, position, range, dimension, nativeHash, data, (ulong) data.LongLength))
                .ConfigureAwait(false);

            ArgumentData.Dispose(data);
        }

        public Task InvokeAsync(uint dimension, ulong nativeHash, params object[] arguments)
        {
            return InvokeAsync(dimension, nativeHash, (IEnumerable<object>) arguments);
        }

        public async Task InvokeAsync(uint dimension, ulong nativeHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            await _plugin
                .Schedule(() => Rage.PlayerPool.PlayerPool__InvokeInDimension(_nativePointer, dimension, nativeHash, data, (ulong) data.LongLength))
                .ConfigureAwait(false);

            ArgumentData.Dispose(data);
        }

        public Task InvokeAsync(IEnumerable<IPlayer> players, ulong nativeHash, params object[] arguments)
        {
            return InvokeAsync(players, nativeHash, (IEnumerable<object>) arguments);
        }

        public async Task InvokeAsync(IEnumerable<IPlayer> players, ulong nativeHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(players, nameof(players));
            Contract.NotNull(arguments, nameof(arguments));

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);
            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            await _plugin
                .Schedule(() => Rage.PlayerPool.PlayerPool__InvokeFor(_nativePointer, playerPointers, (ulong) playerPointers.LongLength, nativeHash, data, (ulong) data.LongLength))
                .ConfigureAwait(false);

            ArgumentData.Dispose(data);
        }

        protected override IPlayer BuildEntity(IntPtr entityPointer)
        {
            return new Player(entityPointer, _plugin);
        }
    }

}
