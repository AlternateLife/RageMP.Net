using System;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Blip
        {
            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern float Blip_GetDrawDistance(IntPtr blipPointer);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Blip_SetDrawDistance(IntPtr blipPointer, float drawDistance);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern int Blip_GetRotation(IntPtr blipPointer);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Blip_SetRotation(IntPtr blipPointer, int drawDistance);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern bool Blip_IsShortRange(IntPtr blipPointer);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Blip_SetShortRange(IntPtr blipPointer, bool shortRange);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern uint Blip_GetColor(IntPtr blipPointer);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Blip_SetColor(IntPtr blipPointer, uint color);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern float Blip_GetScale(IntPtr blipPointer);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Blip_SetScale(IntPtr blipPointer, float scale);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern IntPtr Blip_GetName(IntPtr blipPointer);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Blip_SetName(IntPtr blipPointer, IntPtr name);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Blip_RouteFor(IntPtr blipPointer, IntPtr[] players, int playerCount, uint color, float scale);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Blip_UnrouteFor(IntPtr blipPointer, IntPtr[] players, int playerCount);
        }
    }
}
