using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Extensions;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal class Marker : Entity, IMarker
    {
        internal Marker(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Marker)
        {
        }

        public async Task SetColorAsync(Color value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Marker.Marker_SetColor(NativePointer, value.R, value.G, value.B, value.A))
                .ConfigureAwait(false);
        }

        public async Task<Color> GetColorAsync()
        {
            CheckExistence();

            var colorPointer = await _plugin
                .Schedule(() => Rage.Marker.Marker_GetColor(NativePointer))
                .ConfigureAwait(false);

            return StructConverter.PointerToStruct<ColorRgba>(colorPointer).FromModColor();
        }

        public async Task SetDirectionAsync(Vector3 value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Marker.Marker_SetDirection(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<Vector3> GetDirectionAsync()
        {
            CheckExistence();

            var directionPointer = await _plugin
                .Schedule(() => Rage.Marker.Marker_GetDirection(NativePointer))
                .ConfigureAwait(false);

            return StructConverter.PointerToStruct<Vector3>(directionPointer);
        }

        public async Task SetScaleAsync(float value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Marker.Marker_SetScale(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<float> GetScaleAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Marker.Marker_GetScale(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetVisibleAsync(bool value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Marker.Marker_SetVisible(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<bool> IsVisibleAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Marker.Marker_IsVisible(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task ShowForAsync(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));
            CheckExistence();

            var pointers = players.Select(x => x.NativePointer).ToArray();

            await _plugin
                .Schedule(() => Rage.Marker.Marker_ShowFor(NativePointer, pointers, (ulong) pointers.Length))
                .ConfigureAwait(false);
        }

        public async Task HideForAsync(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));
            CheckExistence();

            var pointers = players.Select(x => x.NativePointer).ToArray();

            await _plugin
                .Schedule(() => Rage.Marker.Marker_HideFor(NativePointer, pointers, (ulong) pointers.Length))
                .ConfigureAwait(false);
        }
    }
}
