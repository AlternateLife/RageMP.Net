using System;
using System.Numerics;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Native
{

    internal static partial class Rage
    {
        internal static class TextLabelPool
        {
            [DllImport(_dllName)]
            internal static extern IntPtr TextLabelPool_New(IntPtr pool, Vector3 position, IntPtr text, uint font, ColorRgba color, float drawDistance, bool los, uint dimension);
        }
    }
}
