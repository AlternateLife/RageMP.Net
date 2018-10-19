using System;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Multiplayer
        {
            [DllImport(_dllName)]
            internal static extern void Multiplayer_AddRemoteEventHandler(IntPtr multiplayer, string eventName, NativePlayerRemoteEventDelegate callback);

            [DllImport(_dllName)]
            internal static extern IntPtr Multiplayer_GetPlayerPool(IntPtr multiplayer);

            [DllImport(_dllName)]
            internal static extern IntPtr Multiplayer_GetVehiclePool(IntPtr multiplayer);

            [DllImport(_dllName)]
            internal static extern IntPtr Multiplayer_GetColshapePool(IntPtr multiplayer);

            [DllImport(_dllName)]
            internal static extern IntPtr Multiplayer_GetCheckpointPool(IntPtr multiplayer);

            [DllImport(_dllName)]
            internal static extern IntPtr Multiplayer_GetMarkerPool(IntPtr multiplayer);

            [DllImport(_dllName)]
            internal static extern IntPtr Multiplayer_GetBlipPool(IntPtr multiplayer);

            [DllImport(_dllName)]
            internal static extern IntPtr Multiplayer_GetPickupPool(IntPtr multiplayer);

            [DllImport(_dllName)]
            internal static extern IntPtr Multiplayer_GetObjectPool(IntPtr multiplayer);

            [DllImport(_dllName)]
            internal static extern IntPtr Multiplayer_GetLabelPool(IntPtr multiplayer);

            [DllImport(_dllName)]
            internal static extern IntPtr Multiplayer_GetWorld(IntPtr multiplayer);

            [DllImport(_dllName)]
            internal static extern IntPtr Multiplayer_GetConfig(IntPtr multiplayer);
        }
    }
}
