using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal partial class Player
    {
        public void SetModel(PedHash value)
        {
            CheckExistence();

            base.SetModel((uint) value);
        }

        public Task SetModelAsync(PedHash value)
        {
            return base.SetModelAsync((uint) value);
        }

        public new PedHash GetModel()
        {
            CheckExistence();

            return (PedHash) base.GetModel();
        }

        public new async Task<PedHash> GetModelAsync()
        {
            CheckExistence();

            return (PedHash) await base.GetModelAsync().ConfigureAwait(false);
        }

        public void SetEyeColor(uint value)
        {
            CheckExistence();

            Rage.Player.Player_SetEyeColor(NativePointer, value);
        }

        public Task SetEyeColorAsync(uint value)
        {
            return _plugin.Schedule(() => SetEyeColor(value));
        }

        public uint GetEyeColor()
        {
            CheckExistence();

            return Rage.Player.Player_GetEyeColor(NativePointer);
        }

        public Task<uint> GetEyeColorAsync()
        {
            return _plugin.Schedule(GetEyeColor);
        }

        public uint GetHairColor()
        {
            CheckExistence();

            return Rage.Player.Player_GetHairColor(NativePointer);
        }

        public Task<uint> GetHairColorAsync()
        {
            return _plugin.Schedule(GetHairColor);
        }

        public uint GetHairHighlightColor()
        {
            CheckExistence();

            return Rage.Player.Player_GetHairHighlightColor(NativePointer);
        }

        public Task<uint> GetHairHighlightColorAsync()
        {
            return _plugin.Schedule(GetHairHighlightColor);
        }

        public void SetHeadBlend(HeadBlendData value)
        {
            CheckExistence();

            Rage.Player.Player_SetHeadBlend(NativePointer, value.Shape[0], value.Shape[1], value.Shape[2],
                value.Skin[0], value.Skin[1], value.Skin[2], value.ShapeMix, value.SkinMix, value.ThirdMix);
        }

        public Task SetHeadBlendAsync(HeadBlendData value)
        {
            return _plugin.Schedule(() => SetHeadBlend(value));
        }

        public HeadBlendData GetHeadBlend()
        {
            CheckExistence();

            var headBlendPointer = Rage.Player.Player_GetHeadBlend(NativePointer);

            return StructConverter.PointerToStruct<HeadBlendData>(headBlendPointer);
        }

        public Task<HeadBlendData> GetHeadBlendAsync()
        {
            return _plugin.Schedule(GetHeadBlend);
        }

        public ClothData GetCloth(ClothSlot slot)
        {
            CheckExistence();

            return StructConverter.PointerToStruct<ClothData>(Rage.Player.Player_GetClothes(NativePointer, (uint) slot));
        }

        public Task<ClothData> GetClothAsync(ClothSlot slot)
        {
            return _plugin.Schedule(() => GetCloth(slot));
        }

        public ClothData GetCloth(int slot)
        {
            return GetCloth((ClothSlot) slot);
        }

        public Task<ClothData> GetClothAsync(int slot)
        {
            return GetClothAsync((ClothSlot) slot);
        }

        public void SetCloth(ClothSlot slot, ClothData data)
        {
            CheckExistence();

            Rage.Player.Player_SetCloth(NativePointer, (uint) slot, data);
        }

        public Task SetClothAsync(ClothSlot slot, ClothData data)
        {
            return _plugin.Schedule(() => SetCloth(slot, data));
        }

        public void SetCloth(ClothSlot slot, byte drawable, byte texture, byte palette)
        {
            SetCloth(slot, new ClothData(drawable, texture, palette));
        }

        public Task SetClothAsync(ClothSlot slot, byte drawable, byte texture, byte palette)
        {
            return SetClothAsync(slot, new ClothData(drawable, texture, palette));
        }

        public void SetClothes(IDictionary<ClothSlot, ClothData> clothes)
        {
            Contract.NotNull(clothes, nameof(clothes));
            CheckExistence();

            var keys = clothes.Keys.Select(x => (uint) x).ToArray();
            var values = clothes.Values.ToArray();

            Rage.Player.Player_SetClothes(NativePointer, keys, values, (ulong) keys.LongLength);
        }

        public Task SetClothesAsync(IDictionary<ClothSlot, ClothData> clothes)
        {
            return _plugin.Schedule(() => SetClothes(clothes));
        }

        public PropData GetProp(PropSlot slot)
        {
            CheckExistence();

            var prop = Rage.Player.Player_GetProp(NativePointer, (uint) slot);

            return StructConverter.PointerToStruct<PropData>(prop);
        }

        public Task<PropData> GetPropAsync(PropSlot slot)
        {
            return _plugin.Schedule(() => GetProp(slot));
        }

        public PropData GetProp(int slot)
        {
            return GetProp((PropSlot) slot);
        }

        public Task<PropData> GetPropAsync(int slot)
        {
            return GetPropAsync((PropSlot) slot);
        }

        public void SetProp(PropSlot slot, PropData data)
        {
            CheckExistence();

            Rage.Player.Player_SetProp(NativePointer, (uint) slot, data);
        }

        public Task SetPropAsync(PropSlot slot, PropData data)
        {
            return _plugin.Schedule(() => SetProp(slot, data));
        }

        public void SetProp(PropSlot slot, byte drawable, byte texture)
        {
            SetProp(slot, new PropData(drawable, texture));
        }

        public Task SetPropAsync(PropSlot slot, byte drawable, byte texture)
        {
            return SetPropAsync(slot, new PropData(drawable, texture));
        }

        public void SetProps(IDictionary<PropSlot, PropData> props)
        {
            Contract.NotNull(props, nameof(props));
            CheckExistence();

            var keys = props.Keys.Select(x => (uint) x).ToArray();
            var values = props.Values.ToArray();

            Rage.Player.Player_SetProps(NativePointer, keys, values, (ulong) keys.LongLength);
        }

        public Task SetPropsAsync(IDictionary<PropSlot, PropData> props)
        {
            return _plugin.Schedule(() => SetProps(props));
        }

        public uint GetDecoration(uint collection)
        {
            CheckExistence();

            return Rage.Player.Player_GetDecoration(NativePointer, collection);
        }

        public Task<uint> GetDecorationAsync(uint collection)
        {
            return _plugin.Schedule(() => GetDecoration(collection));
        }

        public int GetDecoration(int collection)
        {
            return (int) GetDecoration((uint) collection);
        }

        public Task<int> GetDecorationAsync(int collection)
        {
            return _plugin.Schedule(() => GetDecoration(collection));
        }

        public void RemoveDecoration(uint collection, uint overlay)
        {
            CheckExistence();

            Rage.Player.Player_RemoveDecoration(NativePointer, collection, overlay);
        }

        public Task RemoveDecorationAsync(uint collection, uint overlay)
        {
            return _plugin.Schedule(() => RemoveDecoration(collection, overlay));
        }

        public void RemoveDecoration(int collection, int overlay)
        {
            RemoveDecoration((uint) collection, (uint) overlay);
        }

        public Task RemoveDecorationAsync(int collection, int overlay)
        {
            return RemoveDecorationAsync((uint) collection, (uint) overlay);
        }

        public void SetDecoration(uint collection, uint overlay)
        {
            CheckExistence();

            Rage.Player.Player_SetDecoration(NativePointer, collection, overlay);
        }

        public Task SetDecorationAsync(uint collection, uint overlay)
        {
            return _plugin.Schedule(() => SetDecoration(collection, overlay));
        }

        public void SetDecoration(int collection, int overlay)
        {
            SetDecoration((uint) collection, (uint) overlay);
        }

        public Task SetDecorationAsync(int collection, int overlay)
        {
            return SetDecorationAsync((uint) collection, (uint) overlay);
        }

        public void SetDecorations(IDictionary<uint, uint> decorations)
        {
            Contract.NotNull(decorations, nameof(decorations));
            CheckExistence();

            var keys = decorations.Keys.ToArray();
            var values = decorations.Values.ToArray();

            Rage.Player.Player_SetDecorations(NativePointer, keys, values, (ulong) keys.LongLength);
        }

        public Task SetDecorationsAsync(IDictionary<uint, uint> decorations)
        {
            return _plugin.Schedule(() => SetDecorations(decorations));
        }

        public void SetDecorations(IDictionary<int, int> decorations)
        {
            SetDecorations(decorations.ToDictionary(x => (uint) x.Key, x => (uint) x.Value));
        }

        public Task SetDecorationsAsync(IDictionary<int, int> decorations)
        {
            return SetDecorationsAsync(decorations.ToDictionary(x => (uint) x.Key, x => (uint) x.Value));
        }

        public void ClearDecorations()
        {
            CheckExistence();

            Rage.Player.Player_ClearDecorations(NativePointer);
        }

        public Task ClearDecorationsAsync()
        {
            return _plugin.Schedule(ClearDecorations);
        }

        public void SetHairColor(uint color, uint highlightColor)
        {
            CheckExistence();

            Rage.Player.Player_SetHairColor(NativePointer, color, highlightColor);
        }

        public Task SetHairColorAsync(uint color, uint highlightColor)
        {
            return _plugin.Schedule(() => SetHairColor(color, highlightColor));
        }

        public void SetHairColor(int color, int highlightColor)
        {
            SetHairColor((uint) color, (uint) highlightColor);
        }

        public Task SetHairColorAsync(int color, int highlightColor)
        {
            return SetHairColorAsync((uint) color, (uint) highlightColor);
        }

        public float GetFaceFeature(uint id)
        {
            CheckExistence();

            return Rage.Player.Player_GetFaceFeature(NativePointer, id);
        }

        public Task<float> GetFaceFeatureAsync(uint id)
        {
            return _plugin.Schedule(() => GetFaceFeature(id));
        }

        public float GetFaceFeature(int id)
        {
            return GetFaceFeature((uint) id);
        }

        public Task<float> GetFaceFeatureAsync(int id)
        {
            return GetFaceFeatureAsync((uint) id);
        }

        public void SetFaceFeature(uint id, float scale)
        {
            CheckExistence();

            Rage.Player.Player_SetFaceFeature(NativePointer, id, scale);
        }

        public Task SetFaceFeatureAsync(uint id, float scale)
        {
            return _plugin.Schedule(() => SetFaceFeature(id, scale));
        }

        public void SetFaceFeature(int id, float scale)
        {
            SetFaceFeature((uint) id, scale);
        }

        public Task SetFaceFeatureAsync(int id, float scale)
        {
            return SetFaceFeatureAsync((uint) id, scale);
        }

        public void UpdateHeadBlend(float shapeMix, float skinMix, float thirdMix)
        {
            CheckExistence();

            Rage.Player.Player_UpdateHeadBlend(NativePointer, shapeMix, skinMix, thirdMix);
        }

        public Task UpdateHeadBlendAsync(float shapeMix, float skinMix, float thirdMix)
        {
            return _plugin.Schedule(() => UpdateHeadBlend(shapeMix, skinMix, thirdMix));
        }

        public HeadOverlayData GetHeadOverlay(uint overlayId)
        {
            CheckExistence();

            var headOverlayPointer = Rage.Player.Player_GetHeadOverlay(NativePointer, overlayId);

            return StructConverter.PointerToStruct<HeadOverlayData>(headOverlayPointer);
        }

        public Task<HeadOverlayData> GetHeadOverlayAsync(uint overlayId)
        {
            return _plugin.Schedule(() => GetHeadOverlay(overlayId));
        }

        public HeadOverlayData GetHeadOverlay(int overlayId)
        {
            return GetHeadOverlay((uint) overlayId);
        }

        public Task<HeadOverlayData> GetHeadOverlayAsync(int overlayId)
        {
            return GetHeadOverlayAsync((uint) overlayId);
        }

        public void SetHeadOverlay(uint overlayId, HeadOverlayData overlayData)
        {
            CheckExistence();

            Rage.Player.Player_SetHeadOverlay(NativePointer, overlayId, overlayData);
        }

        public Task SetHeadOverlayAsync(uint overlayId, HeadOverlayData overlayData)
        {
            return _plugin.Schedule(() => SetHeadOverlay(overlayId, overlayData));
        }

        public void SetHeadOverlay(int overlayId, HeadOverlayData overlayData)
        {
            SetHeadOverlay((uint) overlayId, overlayData);
        }

        public Task SetHeadOverlayAsync(int overlayId, HeadOverlayData overlayData)
        {
            return SetHeadOverlayAsync((uint) overlayId, overlayData);
        }

        public void SetCustomization(bool isMale, HeadBlendData headBlend, uint eyeColor, uint hairColor, uint highlightColor, float[] faceFeatures,
            IDictionary<int, HeadOverlayData> headOverlays, IDictionary<uint, uint> decorations)
        {
            Contract.NotNull(headOverlays, nameof(headOverlays));
            Contract.NotNull(decorations, nameof(decorations));
            CheckExistence();

            var headOverlayKeys = headOverlays.Keys.ToArray();
            var headOverlayValues = headOverlays.Values.ToArray();

            var decorationKeys = decorations.Keys.ToArray();
            var decorationValues = decorations.Values.ToArray();

            Rage.Player.Player_SetCustomization(NativePointer, isMale, headBlend, eyeColor, hairColor, highlightColor, faceFeatures,
                (ulong) faceFeatures.LongLength, headOverlayKeys,
                headOverlayValues, (ulong) headOverlayKeys.LongLength, decorationKeys, decorationValues, (ulong) decorationKeys.LongLength);
        }

        public Task SetCustomizationAsync(bool isMale, HeadBlendData headBlend, uint eyeColor, uint hairColor, uint highlightColor, float[] faceFeatures,
            IDictionary<int, HeadOverlayData> headOverlays, IDictionary<uint, uint> decorations)
        {
            return _plugin.Schedule(() =>
                SetCustomization(isMale, headBlend, eyeColor, hairColor, highlightColor, faceFeatures, headOverlays, decorations));
        }

        public void SetCustomization(bool isMale, HeadBlendData headBlend, int eyeColor, int hairColor, int highlightColor, float[] faceFeatures,
            IDictionary<int, HeadOverlayData> headOverlays, IDictionary<int, int> decorations)
        {
            SetCustomization(isMale, headBlend, (uint) eyeColor, (uint) hairColor, (uint) highlightColor, faceFeatures, headOverlays,
                decorations.ToDictionary(x => (uint) x.Key, x => (uint) x.Value));
        }

        public Task SetCustomizationAsync(bool isMale, HeadBlendData headBlend, int eyeColor, int hairColor, int highlightColor, float[] faceFeatures,
            IDictionary<int, HeadOverlayData> headOverlays, IDictionary<int, int> decorations)
        {
            return SetCustomizationAsync(isMale, headBlend, (uint) eyeColor, (uint) hairColor, (uint) highlightColor, faceFeatures, headOverlays,
                decorations.ToDictionary(x => (uint) x.Key, x => (uint) x.Value));
        }
    }
}
