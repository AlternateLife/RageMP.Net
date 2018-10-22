using System;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Events
        {
            [DllImport(_dllName)]
            internal static extern void RegisterEventHandler(int type, IntPtr callback);

            [DllImport(_dllName)]
            internal static extern void UnregisterEventHandler(int type);
        }
    }
}
