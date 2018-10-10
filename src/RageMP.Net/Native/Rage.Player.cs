using System;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Player
        {
            [DllImport(_dllName)]
            internal static extern void Player_Kick(IntPtr player, string reason);

            [DllImport(_dllName)]
            internal static extern void Player_Ban(IntPtr player, string reason);

            [DllImport(_dllName)]
            internal static extern void Player_OutputChatBox(IntPtr player, string text);

            [DllImport(_dllName)]
            internal static extern void Player_Notify(IntPtr player, string text);

            [DllImport(_dllName)]
            internal static extern string Player_GetName(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_SetName(IntPtr player, string name);

            [DllImport(_dllName)]
            internal static extern string Player_GetSocialClubName(IntPtr player);
        }
    }
}
