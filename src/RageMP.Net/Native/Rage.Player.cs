using System;
using System.Runtime.InteropServices;

namespace RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Player
        {
            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void Player_Kick(IntPtr player, string reason);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void Player_Ban(IntPtr player, string reason);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void Player_OutputChatBox(IntPtr player, string text);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void Player_Notify(IntPtr player, string text);

            [DllImport(_dllName)]
            internal static extern IntPtr Player_GetName(IntPtr player);

            [DllImport(_dllName, CharSet = CharSet.Ansi)]
            internal static extern void Player_SetName(IntPtr player, string name);

            [DllImport(_dllName)]
            internal static extern IntPtr Player_GetSocialClubName(IntPtr player);

            [DllImport(_dllName)]
            internal static extern IntPtr Player_GetSerial(IntPtr player);

            [DllImport(_dllName)]
            internal static extern float Player_GetHeading(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_SetHeading(IntPtr player, float heading);

            [DllImport(_dllName)]
            internal static extern float Player_GetMoveSpeed(IntPtr player);

            [DllImport(_dllName)]
            internal static extern float Player_GetHealth(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_SetHealth(IntPtr player, float health);

            [DllImport(_dllName)]
            internal static extern float Player_GetArmor(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_SetArmor(IntPtr player, float armor);

            [DllImport(_dllName)]
            internal static extern int Player_GetPing(IntPtr player);

            [DllImport(_dllName)]
            internal static extern float Player_GetPacketLoss(IntPtr player);

            [DllImport(_dllName)]
            internal static extern IntPtr Player_GetKickReason(IntPtr player);

            [DllImport(_dllName)]
            internal static extern IntPtr Player_GetIp(IntPtr player);

            [DllImport(_dllName)]
            internal static extern IntPtr Player_GetActionString(IntPtr player);

            [DllImport(_dllName)]
            internal static extern int Player_GetSeat(IntPtr player);

            [DllImport(_dllName)]
            internal static extern uint Player_GetEyeColor(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_SetEyeColor(IntPtr player, uint eyeColor);

            [DllImport(_dllName)]
            internal static extern uint Player_GetHairColor(IntPtr player);

            [DllImport(_dllName)]
            internal static extern uint Player_GetHairHighlightColor(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_SetHairColor(IntPtr player, uint color, uint highlightcolor);

            [DllImport(_dllName)]
            internal static extern float Player_GetFaceFeature(IntPtr player, uint id);

            [DllImport(_dllName)]
            internal static extern void Player_SetFaceFeature(IntPtr player, uint id, float scale);

            [DllImport(_dllName)]
            internal static extern void Player_SetHeadBlend(IntPtr player, int shapeFirst, int shapeSecond, int shapeThird, int skinFirst, int skinSecond, int skinThird,
                float shapeMix, float skinMix, float thirdMix);

            [DllImport(_dllName)]
            internal static extern void Player_UpdateHeadBlend(IntPtr player, float shapeMix, float skinMix, float thirdMix);

            [DllImport(_dllName)]
            internal static extern uint Player_GetDecoration(IntPtr player, uint collection);

            [DllImport(_dllName)]
            internal static extern void Player_RemoveDecoration(IntPtr player, uint collection, uint overlay);

            [DllImport(_dllName)]
            internal static extern void Player_SetDecoration(IntPtr player, uint collection, uint overlay);

            [DllImport(_dllName)]
            internal static extern uint Player_GetCurrentWeapon(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_SetCurrentWeapon(IntPtr player, uint weaponHash);

            [DllImport(_dllName)]
            internal static extern uint Player_GetCurrentWeaponAmmo(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_SetCurrentWeaponAmmo(IntPtr player, uint ammo);

            [DllImport(_dllName)]
            internal static extern uint Player_GetWeaponAmmo(IntPtr player, uint weaponHash);

            [DllImport(_dllName)]
            internal static extern void Player_SetWeaponAmmo(IntPtr player, uint weaponHash, uint ammo);

            [DllImport(_dllName)]
            internal static extern void Player_GiveWeapon(IntPtr player, uint weaponHash, uint ammo);

            [DllImport(_dllName)]
            internal static extern void Player_RemoveWeapon(IntPtr player, uint weaponHash);

            [DllImport(_dllName)]
            internal static extern void Player_RemoveAllWeapons(IntPtr player);

            [DllImport(_dllName)]
            internal static extern bool Player_IsStreamed(IntPtr player, IntPtr otherPlayer);

            [DllImport(_dllName)]
            internal static extern void Player_PlayAnimation(IntPtr player, string dictionary, string name, float speed, int flags);

            [DllImport(_dllName)]
            internal static extern void Player_StopAnimation(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_PlayScenario(IntPtr player, string scenario);

            [DllImport(_dllName)]
            internal static extern void Player_PutIntoVehicle(IntPtr player, IntPtr vehicle, int seat);

            [DllImport(_dllName)]
            internal static extern void Player_RemoveFromVehicle(IntPtr player);
        }
    }
}
