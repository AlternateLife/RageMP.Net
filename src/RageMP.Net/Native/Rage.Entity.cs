using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Entity
        {
            [DllImport(_dllName)]
            internal static extern uint Entity_GetId(IntPtr entity);

            [DllImport(_dllName)]
            internal static extern uint Entity_GetType(IntPtr entity);

            [DllImport(_dllName)]
            internal static extern void Entity_Destroy(IntPtr entity);

            [DllImport(_dllName)]
            internal static extern uint Entity_GetDimension(IntPtr entity);

            [DllImport(_dllName)]
            internal static extern void Entity_SetDimension(IntPtr entity, uint dimension);

            [DllImport(_dllName)]
            internal static extern IntPtr Entity_GetPosition(IntPtr entity);

            [DllImport(_dllName)]
            internal static extern void Entity_SetPosition(IntPtr entity, Vector3 position);

            [DllImport(_dllName)]
            internal static extern IntPtr Entity_GetRotation(IntPtr entity);

            [DllImport(_dllName)]
            internal static extern void Entity_SetRotation(IntPtr entity, Vector3 position);

            [DllImport(_dllName)]
            internal static extern uint Entity_GetModel(IntPtr entity);

            [DllImport(_dllName)]
            internal static extern void Entity_SetModel(IntPtr entity, uint model);

            [DllImport(_dllName)]
            internal static extern IntPtr Entity_GetVelocity(IntPtr entity);

            [DllImport(_dllName)]
            internal static extern uint Entity_GetAlpha(IntPtr entity);

            [DllImport(_dllName)]
            internal static extern void Entity_SetAlpha(IntPtr entity, uint alpha);
        }
    }
}
