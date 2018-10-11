using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class VehiclePool
        {
            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern IntPtr VehiclePool_New(IntPtr vehiclePool, uint model, Vector3 position, float heading, string numberPlate, uint alpha, bool locked,
                bool engine, uint dimension);
        }
    }
}
