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
    internal class Checkpoint : Entity, ICheckpoint
    {
        internal Checkpoint(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Checkpoint)
        {
        }

        public async Task SetColorAsync(Color value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Checkpoint.Checkpoint_SetColor(NativePointer, value.R, value.G, value.B, value.A))
                .ConfigureAwait(false);
        }

        public async Task<Color> GetColorAsync()
        {
            CheckExistence();

            var colorPointer = await _plugin
                .Schedule(() => Rage.Checkpoint.Checkpoint_GetColor(NativePointer))
                .ConfigureAwait(false);

            return StructConverter.PointerToStruct<ColorRgba>(colorPointer).FromModColor();
        }

        public async Task SetDirectionAsync(Vector3 value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Checkpoint.Checkpoint_SetDirection(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<Vector3> GetDirectionAsync()
        {
            CheckExistence();

            var directionPointer = await _plugin
                .Schedule(() => Rage.Checkpoint.Checkpoint_GetDirection(NativePointer))
                .ConfigureAwait(false);

            return StructConverter.PointerToStruct<Vector3>(directionPointer);
        }

        public async Task SetRadiusAsync(float value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Checkpoint.Checkpoint_SetRadius(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<float> GetRadiusAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Checkpoint.Checkpoint_GetRadius(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetVisibleAsync(bool value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Checkpoint.Checkpoint_SetVisible(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<bool> IsVisibleAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Checkpoint.Checkpoint_IsVisible(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task ShowForAsync(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));
            CheckExistence();

            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            await _plugin
                .Schedule(() => Rage.Checkpoint.Checkpoint_ShowFor(NativePointer, playerPointers, (ulong) playerPointers.Length))
                .ConfigureAwait(false);
        }

        public async Task HideForAsync(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));
            CheckExistence();

            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            await _plugin
                .Schedule(() => Rage.Checkpoint.Checkpoint_HideFor(NativePointer, playerPointers, (ulong) playerPointers.Length))
                .ConfigureAwait(false);
        }
    }
}
