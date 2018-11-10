using System;
using System.Numerics;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class PlayerPool
        {
            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void PlayerPool_Broadcast(IntPtr playerPool, IntPtr message);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void PlayerPool_BroadcastInRange(IntPtr playerPool, IntPtr message, Vector3 position, float range, uint dimension);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void PlayerPool_BroadcastInDimension(IntPtr playerPool, IntPtr message, uint dimension);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void PlayerPool__Call(IntPtr playerPool, IntPtr eventName, ArgumentData[] arguments, ulong argumentCount);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void PlayerPool__CallInRange(IntPtr playerPool, Vector3 position, float range, uint dimension, IntPtr eventName, ArgumentData[] arguments,
                ulong argumentCount);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void PlayerPool__CallInDimension(IntPtr playerPool, uint dimension, IntPtr eventName, ArgumentData[] arguments, ulong argumentCount);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void PlayerPool__CallFor(IntPtr playerPool, IntPtr[] players, ulong playercount, IntPtr eventName, ArgumentData[] arguments, ulong argumentCount);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void PlayerPool__Invoke(IntPtr playerPool, ulong nativeHash, ArgumentData[] arguments, ulong argumentCount);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void PlayerPool__InvokeInRange(IntPtr playerPool, Vector3 position, float range, uint dimension, ulong nativeHash, ArgumentData[] arguments,
                ulong argumentCount);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void PlayerPool__InvokeInDimension(IntPtr playerPool, uint dimension, ulong nativeHash, ArgumentData[] arguments, ulong argumentCount);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void PlayerPool__InvokeFor(IntPtr playerPool, IntPtr[] players, ulong playercount, ulong nativeHash, ArgumentData[] arguments, ulong argumentCount);


        }
    }
}
