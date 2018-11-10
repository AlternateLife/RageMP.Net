using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Colshape
        {
            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern bool Colshape_IsPointWithin(IntPtr colshape, Vector3 position);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern uint Colshape_GetShapeType(IntPtr colshape);
        }
    }
}
