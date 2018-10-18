using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Pool
        {
            [DllImport(_dllName)]
            internal static extern IntPtr Pool_GetAt(IntPtr pool, uint id);

            [DllImport(_dllName)]
            internal static extern uint Pool_GetLength(IntPtr pool);

            [DllImport(_dllName)]
            internal static extern uint Pool_GetCount(IntPtr pool);

            [DllImport(_dllName)]
            internal static extern void Pool_GetInRange(IntPtr pool, Vector3 position, float range, uint dimension, out IntPtr[] entities, out ulong count);

            [DllImport(_dllName)]
            internal static extern void Pool_GetInDimension(IntPtr pool, uint dimension, out IntPtr[] entities, out ulong count);
        }
    }
}
