using System;
using System.Numerics;
using System.Runtime.InteropServices;
using RageMP.Net.Data;

namespace RageMP.Net.Native
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
