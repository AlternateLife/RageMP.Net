using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Marker
        {
            [DllImport(_dllName)]
            internal static extern IntPtr Marker_GetColor(IntPtr markerPointer);

            [DllImport(_dllName)]
            internal static extern void Marker_SetColor(IntPtr markerPointer, uint red, uint green, uint blue, uint alpha);

            [DllImport(_dllName)]
            internal static extern IntPtr Marker_GetDirection(IntPtr markerPointer);

            [DllImport(_dllName)]
            internal static extern void Marker_SetDirection(IntPtr markerPointer, Vector3 direction);

            [DllImport(_dllName)]
            internal static extern float Marker_GetScale(IntPtr markerPointer);

            [DllImport(_dllName)]
            internal static extern void Marker_SetScale(IntPtr markerPointer, float scale);

            [DllImport(_dllName)]
            internal static extern bool Marker_IsVisible(IntPtr markerPointer);

            [DllImport(_dllName)]
            internal static extern void Marker_SetVisible(IntPtr markerPointer, bool toggle);

            [DllImport(_dllName)]
            internal static extern void Marker_ShowFor(IntPtr markerPointer, IntPtr[] players, ulong count);

            [DllImport(_dllName)]
            internal static extern void Marker_HideFor(IntPtr markerPointer, IntPtr[] players, ulong count);
        }
    }
}
