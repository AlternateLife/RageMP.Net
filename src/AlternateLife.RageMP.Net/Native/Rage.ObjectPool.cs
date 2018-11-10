using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class ObjectPool
        {
            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern IntPtr ObjectPool_New(IntPtr objectPool, uint model, Vector3 position, Vector3 rotation, uint dimension);
        }
    }
}
