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
        public Color Color
        {
            get
            {
                CheckExistence();

                return StructConverter.PointerToStruct<ColorRgba>(Rage.Checkpoint.Checkpoint_GetColor(NativePointer)).FromModColor();
            }
            set
            {
                CheckExistence();

                Rage.Checkpoint.Checkpoint_SetColor(NativePointer, value.R, value.G, value.B, value.A);
            }
        }

        public Vector3 Direction
        {
            get
            {
                CheckExistence();

                return StructConverter.PointerToStruct<Vector3>(Rage.Checkpoint.Checkpoint_GetDirection(NativePointer));
            }
            set
            {
                CheckExistence();

                Rage.Checkpoint.Checkpoint_SetDirection(NativePointer, value);
            }
        }

        public float Radius
        {
            get
            {
                CheckExistence();

                return Rage.Checkpoint.Checkpoint_GetRadius(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Checkpoint.Checkpoint_SetRadius(NativePointer, value);
            }
        }

        public bool IsVisible
        {
            get
            {
                CheckExistence();

                return Rage.Checkpoint.Checkpoint_IsVisible(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Checkpoint.Checkpoint_SetVisible(NativePointer, value);
            }
        }

        internal Checkpoint(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Checkpoint)
        {
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
