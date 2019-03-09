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
        public float DrawDistance
        {
            get
            {
                CheckExistence();

                return Rage.Blip.Blip_GetDrawDistance(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Blip.Blip_SetDrawDistance(NativePointer, value);
            }
        }

        public new int Rotation
        {
            get
            {
                CheckExistence();

                return Rage.Blip.Blip_GetRotation(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Blip.Blip_SetRotation(NativePointer, value);
            }
        }

        public bool ShortRange
        {
            get
            {
                CheckExistence();

                return Rage.Blip.Blip_IsShortRange(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Blip.Blip_SetShortRange(NativePointer, value);
            }
        }

        public uint Color
        {
            get
            {
                CheckExistence();

                return Rage.Blip.Blip_GetColor(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Blip.Blip_SetColor(NativePointer, value);
            }
        }

        public float Scale
        {
            get
            {
                CheckExistence();

                return Rage.Blip.Blip_GetScale(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Blip.Blip_SetScale(NativePointer, value);
            }
        }

        public string Name
        {
            get
            {
                CheckExistence();

                return StringConverter.PointerToString(Rage.Blip.Blip_GetName(NativePointer));
            }
            set
            {
                Contract.NotNull(value, nameof(value));
                CheckExistence();

                using (var converter = new StringConverter())
                {
                    Rage.Blip.Blip_SetName(NativePointer, converter.StringToPointer(value));
                }
            }
        }

        internal Blip(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Blip)
        {
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
