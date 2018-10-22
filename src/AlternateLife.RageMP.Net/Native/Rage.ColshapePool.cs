using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class ColshapePool
        {
            [DllImport(_dllName)]
            internal static extern IntPtr ColshapePool_NewCircle(IntPtr colshapePool, Vector2 position, float radius, uint dimension);

            [DllImport(_dllName)]
            internal static extern IntPtr ColshapePool_NewSphere(IntPtr colshapePool, Vector3 position, float radius, uint dimension);

            [DllImport(_dllName)]
            internal static extern IntPtr ColshapePool_NewTube(IntPtr colshapePool, Vector3 position, float radius, float height, uint dimension);

            [DllImport(_dllName)]
            internal static extern IntPtr ColshapePool_NewRectangle(IntPtr colshapePool, Vector2 position, Vector2 size, uint dimension);

            [DllImport(_dllName)]
            internal static extern IntPtr ColshapePool_NewCube(IntPtr colshapePool, Vector3 position, Vector3 size, uint dimension);
        }
    }
}
