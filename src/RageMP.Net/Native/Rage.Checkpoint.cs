using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Checkpoint
        {
            [DllImport(_dllName)]
            internal static extern IntPtr Checkpoint_GetColor(IntPtr checkpoint);

            [DllImport(_dllName)]
            internal static extern void Checkpoint_SetColor(IntPtr checkpoint, uint red, uint green, uint blue, uint alpha);

            [DllImport(_dllName)]
            internal static extern IntPtr Checkpoint_GetDirection(IntPtr checkpoint);

            [DllImport(_dllName)]
            internal static extern void Checkpoint_SetDirection(IntPtr checkpoint, Vector3 direction);

            [DllImport(_dllName)]
            internal static extern float Checkpoint_GetRadius(IntPtr checkpoint);

            [DllImport(_dllName)]
            internal static extern void Checkpoint_SetRadius(IntPtr checkpoint, float radius);

            [DllImport(_dllName)]
            internal static extern bool Checkpoint_IsVisible(IntPtr checkpoint);

            [DllImport(_dllName)]
            internal static extern void Checkpoint_SetVisible(IntPtr checkpoint, bool toggle);

            [DllImport(_dllName)]
            internal static extern void Checkpoint_ShowFor(IntPtr checkpoint, IntPtr[] players, ulong count);

            [DllImport(_dllName)]
            internal static extern void Checkpoint_HideFor(IntPtr checkpoint, IntPtr[] players, ulong count);
        }
    }
}
