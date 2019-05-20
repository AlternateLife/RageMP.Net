using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class CheckpointPool
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr CheckpointPool_New(IntPtr checkpointPool, uint type, Vector3 position, Vector3 nextPosition, float radius, uint color, bool visible,
                uint dimension);
        }
    }
}
