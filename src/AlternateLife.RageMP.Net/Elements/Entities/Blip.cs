using System;
using System.Collections.Generic;
using System.Linq;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal class Blip : Entity, IBlip
    {
        public float DrawDistance
        {
            get => Rage.Blip.Blip_GetDrawDistance(NativePointer);
            set => Rage.Blip.Blip_SetDrawDistance(NativePointer, value);
        }

        public new int Rotation
        {
            get => Rage.Blip.Blip_GetRotation(NativePointer);
            set => Rage.Blip.Blip_SetRotation(NativePointer, value);
        }

        public bool ShortRange
        {
            get => Rage.Blip.Blip_IsShortRange(NativePointer);
            set => Rage.Blip.Blip_SetShortRange(NativePointer, value);
        }

        public uint Color
        {
            get => Rage.Blip.Blip_GetColor(NativePointer);
            set => Rage.Blip.Blip_SetColor(NativePointer, value);
        }

        public float Scale
        {
            get => Rage.Blip.Blip_GetScale(NativePointer);
            set => Rage.Blip.Blip_SetScale(NativePointer, value);
        }

        public string Name
        {
            get => StringConverter.PointerToString(Rage.Blip.Blip_GetName(NativePointer));
            set
            {
                using (var converter = new StringConverter())
                {
                    Rage.Blip.Blip_SetName(NativePointer, converter.StringToPointer(value));
                }
            }
        }

        internal Blip(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Blip)
        {
        }

        public void ShowRoute(IEnumerable<IPlayer> forPlayers, uint color, float scale)
        {
            Contract.NotNull(forPlayers, nameof(forPlayers));

            var playerPointers = forPlayers.Select(x => x.NativePointer).ToArray();

            Rage.Blip.Blip_RouteFor(NativePointer, playerPointers, playerPointers.Length, color, scale);
        }

        public void ShowRoute(IEnumerable<IPlayer> forPlayers, int color, float scale)
        {
            ShowRoute(forPlayers, (uint) color, scale);
        }

        public void HideRoute(IEnumerable<IPlayer> forPlayers)
        {
            Contract.NotNull(forPlayers, nameof(forPlayers));

            var playerPointers = forPlayers.Select(x => x.NativePointer).ToArray();

            Rage.Blip.Blip_UnrouteFor(NativePointer, playerPointers, playerPointers.Length);
        }
    }
}