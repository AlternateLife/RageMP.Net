using System;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Config
        {
            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern int Config_GetInt(IntPtr config, IntPtr key, int defaultValue);

            [DllImport(_dllName, CallingConvention = _callingConvention)]
            internal static extern IntPtr Config_GetString(IntPtr config, IntPtr key, IntPtr defaultValue);
        }
    }
}
