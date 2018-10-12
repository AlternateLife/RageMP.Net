using System;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Blip
        {
            [DllImport(_dllName)]
            internal static extern float Blip_GetDrawDistance(IntPtr blipPointer);

            [DllImport(_dllName)]
            internal static extern void Blip_SetDrawDistance(IntPtr blipPointer, float drawDistance);

            [DllImport(_dllName)]
            internal static extern int Blip_GetRotation(IntPtr blipPointer);

            [DllImport(_dllName)]
            internal static extern void Blip_SetRotation(IntPtr blipPointer, int drawDistance);

            [DllImport(_dllName)]
            internal static extern bool Blip_IsShortRange(IntPtr blipPointer);

            [DllImport(_dllName)]
            internal static extern void Blip_SetShortRange(IntPtr blipPointer, bool shortRange);

            [DllImport(_dllName)]
            internal static extern uint Blip_GetColor(IntPtr blipPointer);

            [DllImport(_dllName)]
            internal static extern void Blip_SetColor(IntPtr blipPointer, uint color);

            [DllImport(_dllName)]
            internal static extern float Blip_GetScale(IntPtr blipPointer);

            [DllImport(_dllName)]
            internal static extern void Blip_SetScale(IntPtr blipPointer, float scale);

            [DllImport(_dllName)]
            internal static extern IntPtr Blip_GetName(IntPtr blipPointer);

            [DllImport(_dllName)]
            internal static extern void Blip_SetName(IntPtr blipPointer, IntPtr name);

            [DllImport(_dllName)]
            internal static extern void Blip_RouteFor(IntPtr blipPointer, IntPtr[] players, int playerCount, uint color, float scale);

            [DllImport(_dllName)]
            internal static extern void Blip_UnrouteFor(IntPtr blipPointer, IntPtr[] players, int playerCount);
        }
    }
}
