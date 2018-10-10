using System;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Entity
        {
            [DllImport(_dllName)]
            internal static extern uint Entity_GetId(IntPtr entity);

        }
    }
}
