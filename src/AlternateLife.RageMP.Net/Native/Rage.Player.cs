using System;
using System.Numerics;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Native
{
    internal static partial class Rage
    {
        internal static class Player
        {
            [DllImport(_dllName)]
            internal static extern void Player_Kick(IntPtr player, IntPtr reason);

            [DllImport(_dllName)]
            internal static extern void Player_Ban(IntPtr player, IntPtr reason);

            [DllImport(_dllName)]
            internal static extern void Player_OutputChatBox(IntPtr player, IntPtr text);

            [DllImport(_dllName)]
            internal static extern void Player_Notify(IntPtr player, IntPtr text);

            [DllImport(_dllName)]
            internal static extern void Player_Spawn(IntPtr player, Vector3 position, float heading);

            [DllImport(_dllName)]
            internal static extern IntPtr Player_GetName(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_SetName(IntPtr player, IntPtr name);

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
            internal static extern IntPtr Player_GetClothes(IntPtr player, uint id);

            [DllImport(_dllName)]
            internal static extern void Player_SetCloth(IntPtr player, uint id, ClothData clothes);

            [DllImport(_dllName)]
            internal static extern void Player_SetClothes(IntPtr player, uint[] keys, ClothData[] clothes, ulong count);

            [DllImport(_dllName)]
            internal static extern IntPtr Player_GetProp(IntPtr player, uint id);

            [DllImport(_dllName)]
            internal static extern void Player_SetProp(IntPtr player, uint id, PropData props);

            [DllImport(_dllName)]
            internal static extern void Player_SetProps(IntPtr player, uint[] keys, PropData[] props, ulong count);

            [DllImport(_dllName)]
            internal static extern void Player_SetCustomization(IntPtr player, bool gender, HeadBlendData headBlend, uint eyeColor, uint hairColor, uint highlightColor,
                float[] faceFeatures, ulong faceFeatureCount, int[] headOverlayKeys, HeadOverlayData[] headOverlayValues, ulong headOverlayCount, uint[] decorationKeys,
                uint[] decorationValues, ulong decorationCount);

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
            internal static extern IntPtr Player_GetHeadBlend(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_UpdateHeadBlend(IntPtr player, float shapeMix, float skinMix, float thirdMix);

            [DllImport(_dllName)]
            internal static extern uint Player_GetDecoration(IntPtr player, uint collection);

            [DllImport(_dllName)]
            internal static extern void Player_RemoveDecoration(IntPtr player, uint collection, uint overlay);

            [DllImport(_dllName)]
            internal static extern void Player_SetDecoration(IntPtr player, uint collection, uint overlay);

            [DllImport(_dllName)]
            internal static extern void Player_SetDecorations(IntPtr player, uint[] collection, uint[] overlay, ulong count);

            [DllImport(_dllName)]
            internal static extern void Player_ClearDecorations(IntPtr player);

            [DllImport(_dllName)]
            internal static extern IntPtr Player_GetHeadOverlay(IntPtr player, uint overlayId);

            [DllImport(_dllName)]
            internal static extern void Player_SetHeadOverlay(IntPtr player, uint overlayId, HeadOverlayData overlay);

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
            internal static extern void Player_GetWeapons(IntPtr player, out IntPtr weapons, out IntPtr ammo, out ulong count);

            [DllImport(_dllName)]
            internal static extern void Player_GiveWeapon(IntPtr player, uint weaponHash, uint ammo);

            [DllImport(_dllName)]
            internal static extern void Player_GiveWeapons(IntPtr player, uint[] weapons, uint[] ammo, ulong count);

            [DllImport(_dllName)]
            internal static extern void Player_RemoveWeapon(IntPtr player, uint weaponHash);

            [DllImport(_dllName)]
            internal static extern void Player_RemoveWeapons(IntPtr player, uint[] weapons, ulong count);

            [DllImport(_dllName)]
            internal static extern void Player_RemoveAllWeapons(IntPtr player);

            [DllImport(_dllName)]
            internal static extern bool Player_IsStreamed(IntPtr player, IntPtr otherPlayer);

            [DllImport(_dllName)]
            internal static extern void Player_GetStreamed(IntPtr player, out IntPtr players, out ulong count);

            [DllImport(_dllName)]
            internal static extern void Player_PlayAnimation(IntPtr player, IntPtr dictionary, IntPtr name, float speed, int flags);

            [DllImport(_dllName)]
            internal static extern void Player_StopAnimation(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_PlayScenario(IntPtr player, IntPtr scenario);

            [DllImport(_dllName)]
            internal static extern IntPtr Player_GetVehicle(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_PutIntoVehicle(IntPtr player, IntPtr vehicle, int seat);

            [DllImport(_dllName)]
            internal static extern void Player_RemoveFromVehicle(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player__Call(IntPtr player, IntPtr eventName, ArgumentData[] data, ulong count);

            [DllImport(_dllName)]
            internal static extern void Player__CallHash(IntPtr player, ulong eventHash, ArgumentData[] data, ulong count);

            [DllImport(_dllName)]
            internal static extern IntPtr Player__Invoke(IntPtr player, ulong nativeHash, ArgumentData[] arguments, ulong count);

            [DllImport(_dllName)]
            internal static extern bool Player_IsJumping(IntPtr player);

            [DllImport(_dllName)]
            internal static extern bool Player_IsInCover(IntPtr player);

            [DllImport(_dllName)]
            internal static extern bool Player_IsEnteringVehicle(IntPtr player);

            [DllImport(_dllName)]
            internal static extern bool Player_IsLeavingVehicle(IntPtr player);

            [DllImport(_dllName)]
            internal static extern bool Player_IsClimbing(IntPtr player);

            [DllImport(_dllName)]
            internal static extern bool Player_IsOnLadder(IntPtr player);

            [DllImport(_dllName)]
            internal static extern bool Player_IsReloading(IntPtr player);

            [DllImport(_dllName)]
            internal static extern bool Player_IsInMelee(IntPtr player);

            [DllImport(_dllName)]
            internal static extern bool Player_IsAiming(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_RemoveObject(IntPtr player, uint model, Vector3 position, float radius);

            [DllImport(_dllName)]
            internal static extern IntPtr Player_GetAminingAt(IntPtr player);

            [DllImport(_dllName)]
            internal static extern void Player_Eval(IntPtr player, IntPtr code);

            [DllImport(_dllName)]
            internal static extern void Player_EnableVoiceTo(IntPtr player, IntPtr target);

            [DllImport(_dllName)]
            internal static extern void Player_DisableVoiceTo(IntPtr player, IntPtr target);

            [DllImport(_dllName)]
            internal static extern void Player_GetVoiceListeners(IntPtr player, out IntPtr players, out ulong count);
        }
    }
}
