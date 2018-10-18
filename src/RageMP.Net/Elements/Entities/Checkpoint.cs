using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using RageMP.Net.Data;
using RageMP.Net.Enums;
using RageMP.Net.Helpers;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Elements.Entities
{
    internal class Checkpoint : Entity, ICheckpoint
    {
        public ColorRgba Color
        {
            get => Marshal.PtrToStructure<ColorRgba>(Rage.Checkpoint.Checkpoint_GetColor(NativePointer));
            set => Rage.Checkpoint.Checkpoint_SetColor(NativePointer, value.GetRed(), value.GetGreen(), value.GetBlue(), value.GetAlpha());
        }

        public Vector3 Direction
        {
            get => Marshal.PtrToStructure<Vector3>(Rage.Checkpoint.Checkpoint_GetDirection(NativePointer));
            set => Rage.Checkpoint.Checkpoint_SetDirection(NativePointer, value);
        }

        public float Radius
        {
            get => Rage.Checkpoint.Checkpoint_GetRadius(NativePointer);
            set => Rage.Checkpoint.Checkpoint_SetRadius(NativePointer, value);
        }

        public bool IsVisible
        {
            get => Rage.Checkpoint.Checkpoint_IsVisible(NativePointer);
            set => Rage.Checkpoint.Checkpoint_SetVisible(NativePointer, value);
        }

        internal Checkpoint(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Checkpoint)
        {
        }

        public void ShowFor(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));

            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            Rage.Checkpoint.Checkpoint_ShowFor(NativePointer, playerPointers, (ulong) playerPointers.Length);
        }

        public void HideFor(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));

            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            Rage.Checkpoint.Checkpoint_HideFor(NativePointer, playerPointers, (ulong) playerPointers.Length);
        }
    }
}
