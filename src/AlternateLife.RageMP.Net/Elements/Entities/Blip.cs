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

        public void SetDrawDistance(float value)
        {
            CheckExistence();

            Rage.Blip.Blip_SetDrawDistance(NativePointer, value);
        }

        public Task SetDrawDistanceAsync(float value)
        {
            return _plugin.Schedule(() => SetDrawDistance(value));
        }

        public float GetDrawDistance()
        {
            CheckExistence();

            return Rage.Blip.Blip_GetDrawDistance(NativePointer);
        }

        public Task<float> GetDrawDistanceAsync()
        {
            return _plugin.Schedule(GetDrawDistance);
        }

        public void SetRotation(int value)
        {
            CheckExistence();

            Rage.Blip.Blip_SetRotation(NativePointer, value);
        }

        public Task SetRotationAsync(int value)
        {
            return _plugin.Schedule(() => SetRotation(value));
        }

        public new int GetRotation()
        {
            CheckExistence();

            return Rage.Blip.Blip_GetRotation(NativePointer);
        }

        public new Task<int> GetRotationAsync()
        {
            return _plugin.Schedule(GetRotation);
        }

        public void SetShortRange(bool value)
        {
            CheckExistence();

            Rage.Blip.Blip_SetShortRange(NativePointer, value);
        }

        public Task SetShortRangeAsync(bool value)
        {
            return _plugin.Schedule(() => SetShortRange(value));
        }

        public bool GetShortRange()
        {
            CheckExistence();

            return Rage.Blip.Blip_IsShortRange(NativePointer);
        }

        public Task<bool> GetShortRangeAsync()
        {
            return _plugin.Schedule(GetShortRange);
        }

        public void SetColor(uint value)
        {
            CheckExistence();

            Rage.Blip.Blip_SetColor(NativePointer, value);
        }

        public Task SetColorAsync(uint value)
        {
            return _plugin.Schedule(() => SetColor(value));
        }

        public uint GetColor()
        {
            CheckExistence();

            return Rage.Blip.Blip_GetColor(NativePointer);
        }

        public Task<uint> GetColorAsync()
        {
            return _plugin.Schedule(GetColor);
        }

        public void SetScale(float value)
        {
            CheckExistence();

            Rage.Blip.Blip_SetScale(NativePointer, value);
        }

        public Task SetScaleAsync(float value)
        {
            return _plugin.Schedule(() => SetScale(value));
        }

        public float GetScale()
        {
            CheckExistence();

            return Rage.Blip.Blip_GetScale(NativePointer);
        }

        public Task<float> GetScaleAsync()
        {
            return _plugin.Schedule(GetScale);
        }

        public void SetName(string value)
        {
            Contract.NotNull(value, nameof(value));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                Rage.Blip.Blip_SetName(NativePointer, converter.StringToPointer(value));
            }
        }

        public Task SetNameAsync(string value)
        {
            return _plugin.Schedule(() => SetName(value));
        }

        public string GetName()
        {
            CheckExistence();

            return StringConverter.PointerToString(Rage.Blip.Blip_GetName(NativePointer));
        }

        public Task<string> GetNameAsync()
        {
            return _plugin.Schedule(GetName);
        }

        public void ShowRoute(IEnumerable<IPlayer> forPlayers, uint color, float scale)
        {
            Contract.NotNull(forPlayers, nameof(forPlayers));
            CheckExistence();

            var playerPointers = forPlayers.Select(x => x.NativePointer).ToArray();

            Rage.Blip.Blip_RouteFor(NativePointer, playerPointers, playerPointers.Length, color, scale);
        }

        public Task ShowRouteAsync(IEnumerable<IPlayer> forPlayers, uint color, float scale)
        {
            return _plugin.Schedule(() => ShowRoute(forPlayers, color, scale));
        }

        public void ShowRoute(IEnumerable<IPlayer> forPlayers, int color, float scale)
        {
            ShowRoute(forPlayers, (uint) color, scale);
        }

        public Task ShowRouteAsync(IEnumerable<IPlayer> forPlayers, int color, float scale)
        {
            return ShowRouteAsync(forPlayers, (uint) color, scale);
        }

        public void HideRoute(IEnumerable<IPlayer> forPlayers)
        {
            Contract.NotNull(forPlayers, nameof(forPlayers));
            CheckExistence();

            var playerPointers = forPlayers.Select(x => x.NativePointer).ToArray();

            Rage.Blip.Blip_UnrouteFor(NativePointer, playerPointers, playerPointers.Length);
        }

        public Task HideRouteAsync(IEnumerable<IPlayer> forPlayers)
        {
            return _plugin.Schedule(() => HideRoute(forPlayers));
        }
    }
}
