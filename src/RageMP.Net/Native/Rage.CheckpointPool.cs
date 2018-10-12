using System;
using System.Numerics;
using System.Runtime.InteropServices;
using RageMP.Net.Data;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class CheckpointPool
        {
            [DllImport(_dllName)]
            internal static extern IntPtr CheckpointPool_New(IntPtr checkpointPool, uint type, Vector3 position, Vector3 nextPosition, float radius, ColorRgba color, bool visible,
                uint dimension);
        }
    }
}
