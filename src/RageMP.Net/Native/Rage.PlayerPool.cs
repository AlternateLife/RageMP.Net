using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class PlayerPool
        {
            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void PlayerPool_Broadcast(IntPtr playerPool, string message);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void PlayerPool_BroadcastInRange(IntPtr playerPool, string message, Vector3 position, float range, uint dimension);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void PlayerPool_BroadcastInDimension(IntPtr playerPool, string message, uint dimension);
        }
    }
}
