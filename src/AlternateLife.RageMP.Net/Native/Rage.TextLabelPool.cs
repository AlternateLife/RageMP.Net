using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Native
{

    internal static partial class Rage
    {
        internal static class TextLabelPool
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr TextLabelPool_New(IntPtr pool, Vector3 position, IntPtr text, uint font, uint color, float drawDistance, bool los, uint dimension);
        }
    }
}
