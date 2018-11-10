using System;
using System.Numerics;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Entity
        {
            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern uint Entity_GetId(IntPtr entity);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern uint Entity_GetType(IntPtr entity);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Entity_Destroy(IntPtr entity);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern uint Entity_GetDimension(IntPtr entity);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Entity_SetDimension(IntPtr entity, uint dimension);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern IntPtr Entity_GetPosition(IntPtr entity);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Entity_SetPosition(IntPtr entity, Vector3 position);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern IntPtr Entity_GetRotation(IntPtr entity);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Entity_SetRotation(IntPtr entity, Vector3 position);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern uint Entity_GetModel(IntPtr entity);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Entity_SetModel(IntPtr entity, uint model);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern IntPtr Entity_GetVelocity(IntPtr entity);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern uint Entity_GetAlpha(IntPtr entity);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Entity_SetAlpha(IntPtr entity, uint alpha);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern IntPtr Entity_GetVariable(IntPtr entity, IntPtr key);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Entity_SetVariable(IntPtr entity, IntPtr key, ArgumentData value);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Entity_SetVariables(IntPtr entity, IntPtr[] keys, ArgumentData[] values, ulong count);

            [DllImport(_dllName, CallingConvention = CallingConvention.Cdecl)]
            internal static extern bool Entity_HasVariable(IntPtr entity, IntPtr key);
        }
    }
}
