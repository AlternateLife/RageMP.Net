using System;
using System.Numerics;
using System.Runtime.InteropServices;
using RageMP.Net.Data;

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

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void PlayerPool__Call(IntPtr playerPool, string eventName, ArgumentData[] arguments, ulong argumentCount);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void PlayerPool__CallInRange(IntPtr playerPool, Vector3 position, float range, uint dimension, string eventName, ArgumentData[] arguments,
                ulong argumentCount);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void PlayerPool__CallInDimension(IntPtr playerPool, uint dimension, string eventName, ArgumentData[] arguments, ulong argumentCount);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void PlayerPool__CallFor(IntPtr playerPool, IntPtr[] players, ulong playercount, string eventName, ArgumentData[] arguments, ulong argumentCount);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void PlayerPool__Invoke(IntPtr playerPool, ulong nativeHash, ArgumentData[] arguments, ulong argumentCount);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void PlayerPool__InvokeInRange(IntPtr playerPool, Vector3 position, float range, uint dimension, ulong nativeHash, ArgumentData[] arguments,
                ulong argumentCount);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void PlayerPool__InvokeInDimension(IntPtr playerPool, uint dimension, ulong nativeHash, ArgumentData[] arguments, ulong argumentCount);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void PlayerPool__InvokeFor(IntPtr playerPool, IntPtr[] players, ulong playercount, ulong nativeHash, ArgumentData[] arguments, ulong argumentCount);


        }
    }
}
