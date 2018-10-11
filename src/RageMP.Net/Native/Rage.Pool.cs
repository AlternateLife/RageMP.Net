using System;
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
        }
    }
}
