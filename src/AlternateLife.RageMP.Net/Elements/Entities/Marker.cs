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

        public void SetColor(Color value)
        {
            CheckExistence();

            Rage.Marker.Marker_SetColor(NativePointer, value.R, value.G, value.B, value.A);
        }

        public Task SetColorAsync(Color value)
        {
            return _plugin.Schedule(() => SetColor(value));
        }

        public Color GetColor()
        {
            CheckExistence();

            return StructConverter.PointerToStruct<ColorRgba>(Rage.Marker.Marker_GetColor(NativePointer)).FromModColor();
        }

        public Task<Color> GetColorAsync()
        {
            return _plugin.Schedule(GetColor);
        }

        public void SetDirection(Vector3 value)
        {
            CheckExistence();

            Rage.Marker.Marker_SetDirection(NativePointer, value);
        }

        public Task SetDirectionAsync(Vector3 value)
        {
            return _plugin.Schedule(() => SetDirection(value));
        }

        public Vector3 GetDirection()
        {
            CheckExistence();

            return StructConverter.PointerToStruct<Vector3>(Rage.Marker.Marker_GetDirection(NativePointer));
        }

        public Task<Vector3> GetDirectionAsync()
        {
            return _plugin.Schedule(GetDirection);
        }

        public void SetScale(float value)
        {
            CheckExistence();

            Rage.Marker.Marker_SetScale(NativePointer, value);
        }

        public Task SetScaleAsync(float value)
        {
            return _plugin.Schedule(() => SetScale(value));
        }

        public float GetScale()
        {
            CheckExistence();

            return Rage.Marker.Marker_GetScale(NativePointer);
        }

        public Task<float> GetScaleAsync()
        {
            return _plugin.Schedule(GetScale);
        }

        public void SetVisible(bool value)
        {
            CheckExistence();

            Rage.Marker.Marker_SetVisible(NativePointer, value);
        }

        public Task SetVisibleAsync(bool value)
        {
            return _plugin.Schedule(() => SetVisible(value));
        }

        public bool IsVisible()
        {
            return Rage.Marker.Marker_IsVisible(NativePointer);
        }

        public Task<bool> IsVisibleAsync()
        {
            return _plugin.Schedule(IsVisible);
        }

        public void ShowFor(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));
            CheckExistence();

            var pointers = players.Select(x => x.NativePointer).ToArray();

            Rage.Marker.Marker_ShowFor(NativePointer, pointers, (ulong) pointers.LongLength);
        }

        public Task ShowForAsync(IEnumerable<IPlayer> players)
        {
            return _plugin.Schedule(() => ShowFor(players));
        }

        public void HideFor(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));
            CheckExistence();

            var pointers = players.Select(x => x.NativePointer).ToArray();

            Rage.Marker.Marker_HideFor(NativePointer, pointers, (ulong) pointers.LongLength);
        }

        public Task HideForAsync(IEnumerable<IPlayer> players)
        {
            return _plugin.Schedule(() => HideFor(players));
        }
    }
}
