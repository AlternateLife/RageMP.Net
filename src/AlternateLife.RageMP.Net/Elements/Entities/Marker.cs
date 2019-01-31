using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
        public Color Color
        {
            get
            {
                CheckExistence();

                return StructConverter.PointerToStruct<ColorRgba>(Rage.Marker.Marker_GetColor(NativePointer)).FromModColor();
            }
            set
            {
                CheckExistence();

                Rage.Marker.Marker_SetColor(NativePointer, value.R, value.G, value.B, value.A);
            }
        }

        public Vector3 Direction
        {
            get
            {
                CheckExistence();

                return StructConverter.PointerToStruct<Vector3>(Rage.Marker.Marker_GetDirection(NativePointer));
            }
            set
            {
                CheckExistence();

                Rage.Marker.Marker_SetDirection(NativePointer, value);
            }
        }

        public float Scale
        {
            get
            {
                CheckExistence();

                return Rage.Marker.Marker_GetScale(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Marker.Marker_SetScale(NativePointer, value);
            }
        }

        public bool IsVisible
        {
            get
            {
                CheckExistence();

                return Rage.Marker.Marker_IsVisible(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Marker.Marker_SetVisible(NativePointer, value);
            }
        }

        internal Marker(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Marker)
        {
        }

        public void ShowFor(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));
            CheckExistence();

            var pointers = players.Select(x => x.NativePointer).ToArray();

            Rage.Marker.Marker_ShowFor(NativePointer, pointers, (ulong) pointers.Length);
        }

        public void HideFor(IEnumerable<IPlayer> players)
        {
            Contract.NotNull(players, nameof(players));
            CheckExistence();

            var pointers = players.Select(x => x.NativePointer).ToArray();

            Rage.Marker.Marker_HideFor(NativePointer, pointers, (ulong) pointers.Length);
        }
    }
}
