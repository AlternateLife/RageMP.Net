using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using RageMP.Net.Data;
using RageMP.Net.Enums;
using RageMP.Net.Native;

namespace RageMP.Net.Entities
{
    internal partial class Player
    {
        public uint EyeColor
        {
            get => Rage.Player.Player_GetEyeColor(NativePointer);
            set => Rage.Player.Player_SetEyeColor(NativePointer, value);
        }

        public uint HairColor => Rage.Player.Player_GetHairColor(NativePointer);
        public uint HairHighlightColor => Rage.Player.Player_GetHairHighlightColor(NativePointer);

        public HeadBlendData HeadBlend
        {
            get => Marshal.PtrToStructure<HeadBlendData>(Rage.Player.Player_GetHeadBlend(NativePointer));
            set => Rage.Player.Player_SetHeadBlend(NativePointer, value.Shape[0], value.Shape[1], value.Shape[2], value.Skin[0], value.Skin[1], value.Skin[2], value.ShapeMix,
                value.SkinMix, value.ThirdMix);
        }

        public ClothData GetCloth(ClothSlot slot)
        {
            return Marshal.PtrToStructure<ClothData>(Rage.Player.Player_GetClothes(NativePointer, (uint) slot));
        }

        public void SetCloth(ClothSlot slot, ClothData data)
        {
            Rage.Player.Player_SetCloth(NativePointer, (uint) slot, data);
        }

        public void SetClothes(Dictionary<ClothSlot, ClothData> clothes)
        {
            var keys = clothes.Keys.Select(x => (uint) x).ToArray();
            var values = clothes.Values.ToArray();

            Rage.Player.Player_SetClothes(NativePointer, keys, values, (ulong) keys.Length);
        }

        public PropData GetProp(PropSlot slot)
        {
            return Marshal.PtrToStructure<PropData>(Rage.Player.Player_GetProp(NativePointer, (uint) slot));
        }

        public void SetProp(PropSlot slot, PropData data)
        {
            Rage.Player.Player_SetProp(NativePointer, (uint) slot, data);
        }

        public void SetProps(Dictionary<PropSlot, PropData> props)
        {
            var keys = props.Keys.Select(x => (uint) x).ToArray();
            var values = props.Values.ToArray();

            Rage.Player.Player_SetProps(NativePointer, keys, values, (ulong) keys.Length);
        }

        public uint GetDecoration(uint collection)
        {
            return Rage.Player.Player_GetDecoration(NativePointer, collection);
        }

        public void RemoveDecoration(uint collection, uint overlay)
        {
            Rage.Player.Player_RemoveDecoration(NativePointer, collection, overlay);
        }

        public void SetDecoration(uint collection, uint overlay)
        {
            Rage.Player.Player_SetDecoration(NativePointer, collection, overlay);
        }

        public void SetDecorations(Dictionary<uint, uint> decorations)
        {
            var keys = decorations.Keys.ToArray();
            var values = decorations.Values.ToArray();

            Rage.Player.Player_SetDecorations(NativePointer, keys, values, (ulong) keys.Length);
        }

        public void SetHairColor(uint color, uint highlightColor)
        {
            Rage.Player.Player_SetHairColor(NativePointer, color, highlightColor);
        }

        public float GetFaceFeature(uint id)
        {
            return Rage.Player.Player_GetFaceFeature(NativePointer, id);
        }

        public void SetFaceFeature(uint id, float scale)
        {
            Rage.Player.Player_SetFaceFeature(NativePointer, id, scale);
        }

        public void UpdateHeadBlend(float shapeMix, float skinMix, float thirdMix)
        {
            Rage.Player.Player_UpdateHeadBlend(NativePointer, shapeMix, skinMix, thirdMix);
        }

        public HeadOverlayData GetHeadOverlay(uint overlayId)
        {
            return Marshal.PtrToStructure<HeadOverlayData>(Rage.Player.Player_GetHeadOverlay(NativePointer, overlayId));
        }

        public void SetHeadOverlay(uint overlayId, HeadOverlayData overlayData)
        {
            Rage.Player.Player_SetHeadOverlay(NativePointer, overlayId, overlayData);
        }

        public void SetCustomization(bool isMale, HeadBlendData headBlend, uint eyeColor, uint hairColor, uint highlightColor, float[] faceFeatures,
            IDictionary<int, HeadOverlayData> headOverlays, IDictionary<uint, uint> decorations)
        {
            var headOverlayKeys = headOverlays.Keys.ToArray();
            var headOverlayValues = headOverlays.Values.ToArray();

            var decorationKeys = decorations.Keys.ToArray();
            var decorationValues = decorations.Values.ToArray();

            Rage.Player.Player_SetCustomization(NativePointer, isMale, headBlend, eyeColor, hairColor, highlightColor, faceFeatures, (ulong) faceFeatures.Length, headOverlayKeys,
                headOverlayValues, (ulong) headOverlayKeys.Length, decorationKeys, decorationValues, (ulong) decorationKeys.Length);
        }
    }
}
