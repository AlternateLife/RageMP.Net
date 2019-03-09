using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal class Blip : Entity, IBlip
    {
        internal Blip(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Blip)
        {
        }

        public async Task SetDrawDistanceAsync(float value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Blip.Blip_SetDrawDistance(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<float> GetDrawDistanceAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Blip.Blip_GetDrawDistance(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetRotationAsync(int value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Blip.Blip_SetRotation(NativePointer, value))
                .ConfigureAwait(false);
        }

        public new async Task<int> GetRotationAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Blip.Blip_GetRotation(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetShortRangeAsync(bool value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Blip.Blip_SetShortRange(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<bool> GetShortRangeAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Blip.Blip_IsShortRange(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetColorAsync(uint value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Blip.Blip_SetColor(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetColorAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Blip.Blip_GetColor(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetScaleAsync(float value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Blip.Blip_SetScale(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<float> GetScaleAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Blip.Blip_GetScale(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetNameAsync(string value)
        {
            Contract.NotNull(value, nameof(value));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var name = converter.StringToPointer(value);

                await _plugin
                    .Schedule(() => Rage.Blip.Blip_SetName(NativePointer, name))
                    .ConfigureAwait(false);
            }
        }

        public async Task<string> GetNameAsync()
        {
            CheckExistence();

            var namePointer = await _plugin
                .Schedule(() => Rage.Blip.Blip_GetName(NativePointer))
                .ConfigureAwait(false);

            return StringConverter.PointerToString(namePointer);
        }

        public async Task ShowRouteAsync(IEnumerable<IPlayer> forPlayers, uint color, float scale)
        {
            Contract.NotNull(forPlayers, nameof(forPlayers));
            CheckExistence();

            var playerPointers = forPlayers.Select(x => x.NativePointer).ToArray();

            await _plugin
                .Schedule(() => Rage.Blip.Blip_RouteFor(NativePointer, playerPointers, playerPointers.Length, color, scale))
                .ConfigureAwait(false);
        }

        public Task ShowRouteAsync(IEnumerable<IPlayer> forPlayers, int color, float scale)
        {
            return ShowRouteAsync(forPlayers, (uint) color, scale);
        }

        public async Task HideRouteAsync(IEnumerable<IPlayer> forPlayers)
        {
            Contract.NotNull(forPlayers, nameof(forPlayers));
            CheckExistence();

            var playerPointers = forPlayers.Select(x => x.NativePointer).ToArray();

            await _plugin
                .Schedule(() => Rage.Blip.Blip_UnrouteFor(NativePointer, playerPointers, playerPointers.Length))
                .ConfigureAwait(false);
        }
    }
}
