using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Data;
using RageMP.Net.Elements.Entities;
using RageMP.Net.Helpers;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Elements.Pools
{
    internal class PlayerPool : PoolBase<IPlayer>, IPlayerPool
    {
        internal PlayerPool(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin)
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

        public async Task BroadcastInRangeAsync(string message, Vector3 position, float range, uint dimension)
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

        public async Task BroadcastInDimensionAsync(string message, uint dimension)
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

        public async Task CallAsync(string eventName, params object[] arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));

            var data = ArgumentData.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                var eventNamePointer = converter.StringToPointer(eventName);

                await _plugin
                    .Schedule(() => Rage.PlayerPool.PlayerPool__Call(_nativePointer, eventNamePointer, data, (ulong) data.Length))
                    .ConfigureAwait(false);
            }

            ArgumentData.Dispose(data);
        }

        public async Task CallInRangeAsync(Vector3 position, float range, uint dimension, string eventName, params object[] arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));

            var data = ArgumentData.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                var eventNamePointer = converter.StringToPointer(eventName);

                await _plugin
                    .Schedule(() => Rage.PlayerPool.PlayerPool__CallInRange(_nativePointer, position, range, dimension, eventNamePointer, data, (ulong) data.Length))
                    .ConfigureAwait(false);
            }

            ArgumentData.Dispose(data);
        }

        public async Task CallInDimensionAsync(uint dimension, string eventName, params object[] arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));

            var data = ArgumentData.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                var eventNamePointer = converter.StringToPointer(eventName);

                await _plugin
                    .Schedule(() => Rage.PlayerPool.PlayerPool__CallInDimension(_nativePointer, dimension, eventNamePointer, data, (ulong) data.Length))
                    .ConfigureAwait(false);
            }

            ArgumentData.Dispose(data);
        }

        public async Task CallForAsync(IEnumerable<IPlayer> players, string eventName, params object[] arguments)
        {
            Contract.NotNull(players, nameof(players));
            Contract.NotEmpty(eventName, nameof(eventName));

            var data = ArgumentData.ConvertFromObjects(arguments);
            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            using (var converter = new StringConverter())
            {
                var eventNamePointer = converter.StringToPointer(eventName);

                await _plugin
                    .Schedule(() => Rage.PlayerPool.PlayerPool__CallFor(_nativePointer, playerPointers, (ulong) playerPointers.Length, eventNamePointer, data, (ulong) data.Length))
                    .ConfigureAwait(false);
            }

            ArgumentData.Dispose(data);
        }

        public async Task InvokeAsync(ulong nativeHash, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromObjects(arguments);

            await _plugin
                .Schedule(() => Rage.PlayerPool.PlayerPool__Invoke(_nativePointer, nativeHash, data, (ulong) data.Length))
                .ConfigureAwait(false);

            ArgumentData.Dispose(data);
        }

        public async Task InvokeInRangeAsync(Vector3 position, float range, uint dimension, ulong nativeHash, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromObjects(arguments);

            await _plugin
                .Schedule(() => Rage.PlayerPool.PlayerPool__InvokeInRange(_nativePointer, position, range, dimension, nativeHash, data, (ulong) data.Length))
                .ConfigureAwait(false);

            ArgumentData.Dispose(data);
        }

        public async Task InvokeInDimensionAsync(uint dimension, ulong nativeHash, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromObjects(arguments);

            await _plugin
                .Schedule(() => Rage.PlayerPool.PlayerPool__InvokeInDimension(_nativePointer, dimension, nativeHash, data, (ulong) data.Length))
                .ConfigureAwait(false);

            ArgumentData.Dispose(data);
        }

        public async Task InvokeForAsync(IEnumerable<IPlayer> players, ulong nativeHash, params object[] arguments)
        {
            Contract.NotNull(players, nameof(players));

            var data = ArgumentData.ConvertFromObjects(arguments);
            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            await _plugin
                .Schedule(() => Rage.PlayerPool.PlayerPool__InvokeFor(_nativePointer, playerPointers, (ulong) playerPointers.Length, nativeHash, data, (ulong) data.Length))
                .ConfigureAwait(false);

            ArgumentData.Dispose(data);
        }

        protected override IPlayer BuildEntity(IntPtr entityPointer)
        {
            return new Player(entityPointer, _plugin);
        }
    }

}
