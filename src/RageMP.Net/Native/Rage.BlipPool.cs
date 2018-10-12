using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class BlipPool
        {
            [DllImport(_dllName)]
            internal static extern IntPtr BlipPool_New(IntPtr blipPool, uint sprite, Vector3 position, float scale, uint color, IntPtr name, uint alpha, float drawDistance,
                bool shortRange, int rotation, uint dimension);
        }
    }
}
