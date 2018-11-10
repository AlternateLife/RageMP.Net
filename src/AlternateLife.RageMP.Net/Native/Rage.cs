using System;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        private const string _dllName = "dotnet-wrapper";

        [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int FreeObject(IntPtr pointer);

        [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int FreeArray(IntPtr array);
    }
}
