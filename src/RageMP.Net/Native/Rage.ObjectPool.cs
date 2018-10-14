using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class ObjectPool
        {
            [DllImport(_dllName)]
            internal static extern IntPtr ObjectPool_New(IntPtr objectPool, uint model, Vector3 position, Vector3 rotation, uint dimension);
        }
    }
}
