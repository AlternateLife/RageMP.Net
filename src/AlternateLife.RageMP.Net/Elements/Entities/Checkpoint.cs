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

        public void SetColor(Color value)
        {
            CheckExistence();

            Rage.Checkpoint.Checkpoint_SetColor(NativePointer, value.R, value.G, value.B, value.A);
        }

        public Task SetColorAsync(Color value)
        {
            return _plugin.Schedule(() => SetColor(value));
        }

        public Color GetColor()
        {
            CheckExistence();

            var colorPointer = Rage.Checkpoint.Checkpoint_GetColor(NativePointer);

            return StructConverter.PointerToStruct<ColorRgba>(colorPointer).FromModColor();
        }

        public Task<Color> GetColorAsync()
        {
            return _plugin.Schedule(GetColor);
        }

        public void SetDirection(Vector3 value)
        {
            CheckExistence();

            Rage.Checkpoint.Checkpoint_SetDirection(NativePointer, value);
        }

        public Task SetDirectionAsync(Vector3 value)
        {
            return _plugin.Schedule(() => SetDirection(value));
        }

        public Vector3 GetDirection()
        {
            CheckExistence();

            var directionPointer = Rage.Checkpoint.Checkpoint_GetDirection(NativePointer);

            return StructConverter.PointerToStruct<Vector3>(directionPointer);
        }

        public Task<Vector3> GetDirectionAsync()
        {
            return _plugin.Schedule(GetDirection);
        }

        public void SetRadius(float value)
        {
            CheckExistence();

            Rage.Checkpoint.Checkpoint_SetRadius(NativePointer, value);
        }

        public Task SetRadiusAsync(float value)
        {
            return _plugin.Schedule(() => SetRadius(value));
        }

        public float GetRadius()
        {
            CheckExistence();

            return Rage.Checkpoint.Checkpoint_GetRadius(NativePointer);
        }

        public Task<float> GetRadiusAsync()
        {
            return _plugin.Schedule(GetRadius);
        }

        public void SetVisible(bool value)
        {
            CheckExistence();

            Rage.Checkpoint.Checkpoint_SetVisible(NativePointer, value);
        }

        public Task SetVisibleAsync(bool value)
        {
            return _plugin.Schedule(() => SetVisible(value));
        }

        public bool IsVisible()
        {
            CheckExistence();

            return Rage.Checkpoint.Checkpoint_IsVisible(NativePointer);
        }

        public Task<bool> IsVisibleAsync()
        {
            return _plugin.Schedule(IsVisible);
        }

        public void ShowFor(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));
            CheckExistence();

            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            Rage.Checkpoint.Checkpoint_ShowFor(NativePointer, playerPointers, (ulong) playerPointers.LongLength);
        }

        public Task ShowForAsync(IEnumerable<IPlayer> players)
        {
            return _plugin.Schedule(() => ShowFor(players));
        }

        public void HideFor(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));
            CheckExistence();

            var playerPointers = players.Select(x => x.NativePointer).ToArray();

            Rage.Checkpoint.Checkpoint_HideFor(NativePointer, playerPointers, (ulong) playerPointers.LongLength);
        }

        public Task HideForAsync(IEnumerable<IPlayer> players)
        {
            return _plugin.Schedule(() => HideForAsync(players));
        }
    }
}
