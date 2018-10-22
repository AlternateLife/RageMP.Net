using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class VehiclePool
        {
            [DllImport(_dllName)]
            internal static extern IntPtr VehiclePool_New(IntPtr vehiclePool, uint model, Vector3 position, float heading, IntPtr numberPlate, uint alpha, bool locked,
                bool engine, uint dimension);
        }
    }
}
