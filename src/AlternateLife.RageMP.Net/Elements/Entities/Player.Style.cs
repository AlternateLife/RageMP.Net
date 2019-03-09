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
        public async Task SetModelAsync(PedHash value)
        {
            CheckExistence();

            await base.SetModelAsync((uint) value).ConfigureAwait(false);
        }

        public new async Task<PedHash> GetModelAsync()
        {
            CheckExistence();

            return (PedHash) await base.GetModelAsync().ConfigureAwait(false);
        }

        public async Task SetEyeColorAsync(uint value)
        {
            CheckExistence();

            await _plugin.Schedule(() => Rage.Player.Player_SetEyeColor(NativePointer, value)).ConfigureAwait(false);
        }

        public async Task<uint> GetEyeColorAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => Rage.Player.Player_GetEyeColor(NativePointer)).ConfigureAwait(false);
        }

        public async Task<uint> GetHairColorAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => Rage.Player.Player_GetHairColor(NativePointer)).ConfigureAwait(false);
        }

        public async Task<uint> GetHairHighlightColorAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => Rage.Player.Player_GetHairHighlightColor(NativePointer)).ConfigureAwait(false);
        }

        public async Task SetHeadBlendAsync(HeadBlendData value)
        {
            CheckExistence();

            await _plugin.Schedule(() => Rage.Player.Player_SetHeadBlend(NativePointer, value.Shape[0], value.Shape[1], value.Shape[2],
                value.Skin[0], value.Skin[1], value.Skin[2], value.ShapeMix, value.SkinMix, value.ThirdMix)).ConfigureAwait(false);
        }

        public async Task<HeadBlendData> GetHeadBlendAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => StructConverter.PointerToStruct<HeadBlendData>(Rage.Player.Player_GetHeadBlend(NativePointer))).ConfigureAwait(false);
        }

        public async Task<ClothData> GetClothAsync(ClothSlot slot)
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => StructConverter.PointerToStruct<ClothData>(Rage.Player.Player_GetClothes(NativePointer, (uint) slot)))
                .ConfigureAwait(false);
        }

        public Task<ClothData> GetClothAsync(int slot)
        {
            return GetClothAsync((ClothSlot) slot);
        }

        public async Task SetClothAsync(ClothSlot slot, ClothData data)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetCloth(NativePointer, (uint) slot, data))
                .ConfigureAwait(false);
        }

        public Task SetClothAsync(ClothSlot slot, byte drawable, byte texture, byte palette)
        {
            return SetClothAsync(slot, new ClothData(drawable, texture, palette));
        }

        public async Task SetClothesAsync(IDictionary<ClothSlot, ClothData> clothes)
        {
            Contract.NotNull(clothes, nameof(clothes));
            CheckExistence();

            var keys = clothes.Keys.Select(x => (uint) x).ToArray();
            var values = clothes.Values.ToArray();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetClothes(NativePointer, keys, values, (ulong) keys.Length))
                .ConfigureAwait(false);
        }

        public async Task<PropData> GetPropAsync(PropSlot slot)
        {
            CheckExistence();

            var prop = await _plugin
                .Schedule(() => Rage.Player.Player_GetProp(NativePointer, (uint) slot))
                .ConfigureAwait(false);

            return StructConverter.PointerToStruct<PropData>(prop);
        }

        public Task<PropData> GetPropAsync(int slot)
        {
            return GetPropAsync((PropSlot) slot);
        }

        public async Task SetPropAsync(PropSlot slot, PropData data)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetProp(NativePointer, (uint) slot, data))
                .ConfigureAwait(false);
        }

        public Task SetPropAsync(PropSlot slot, byte drawable, byte texture)
        {
            return SetPropAsync(slot, new PropData(drawable, texture));
        }

        public async Task SetPropsAsync(IDictionary<PropSlot, PropData> props)
        {
            Contract.NotNull(props, nameof(props));
            CheckExistence();

            var keys = props.Keys.Select(x => (uint) x).ToArray();
            var values = props.Values.ToArray();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetProps(NativePointer, keys, values, (ulong) keys.Length))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetDecorationAsync(uint collection)
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Player.Player_GetDecoration(NativePointer, collection))
                .ConfigureAwait(false);
        }

        public async Task<int> GetDecorationAsync(int collection)
        {
            return (int) await GetDecorationAsync((uint) collection)
                .ConfigureAwait(false);
        }

        public async Task RemoveDecorationAsync(uint collection, uint overlay)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_RemoveDecoration(NativePointer, collection, overlay))
                .ConfigureAwait(false);
        }

        public Task RemoveDecorationAsync(int collection, int overlay)
        {
            return RemoveDecorationAsync((uint) collection, (uint) overlay);
        }

        public async Task SetDecorationAsync(uint collection, uint overlay)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetDecoration(NativePointer, collection, overlay))
                .ConfigureAwait(false);
        }

        public Task SetDecorationAsync(int collection, int overlay)
        {
            return SetDecorationAsync((uint) collection, (uint) overlay);
        }

        public async Task SetDecorationsAsync(IDictionary<uint, uint> decorations)
        {
            Contract.NotNull(decorations, nameof(decorations));
            CheckExistence();

            var keys = decorations.Keys.ToArray();
            var values = decorations.Values.ToArray();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetDecorations(NativePointer, keys, values, (ulong) keys.Length))
                .ConfigureAwait(false);
        }

        public Task SetDecorationsAsync(IDictionary<int, int> decorations)
        {
            return SetDecorationsAsync(decorations.ToDictionary(x => (uint) x.Key, x => (uint) x.Value));
        }

        public async Task ClearDecorationsAsync()
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_ClearDecorations(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetHairColorAsync(uint color, uint highlightColor)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetHairColor(NativePointer, color, highlightColor))
                .ConfigureAwait(false);
        }

        public Task SetHairColorAsync(int color, int highlightColor)
        {
            return SetHairColorAsync((uint) color, (uint) highlightColor);
        }

        public async Task<float> GetFaceFeatureAsync(uint id)
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Player.Player_GetFaceFeature(NativePointer, id))
                .ConfigureAwait(false);
        }

        public Task<float> GetFaceFeatureAsync(int id)
        {
            return GetFaceFeatureAsync((uint) id);
        }

        public async Task SetFaceFeatureAsync(uint id, float scale)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetFaceFeature(NativePointer, id, scale))
                .ConfigureAwait(false);
        }

        public Task SetFaceFeatureAsync(int id, float scale)
        {
            return SetFaceFeatureAsync((uint) id, scale);
        }

        public async Task UpdateHeadBlendAsync(float shapeMix, float skinMix, float thirdMix)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_UpdateHeadBlend(NativePointer, shapeMix, skinMix, thirdMix))
                .ConfigureAwait(false);
        }

        public async Task<HeadOverlayData> GetHeadOverlayAsync(uint overlayId)
        {
            CheckExistence();

            var headOverlayPointer = await _plugin
                .Schedule(() => Rage.Player.Player_GetHeadOverlay(NativePointer, overlayId))
                .ConfigureAwait(false);

            return StructConverter.PointerToStruct<HeadOverlayData>(headOverlayPointer);
        }

        public Task<HeadOverlayData> GetHeadOverlayAsync(int overlayId)
        {
            return GetHeadOverlayAsync((uint) overlayId);
        }

        public async Task SetHeadOverlayAsync(uint overlayId, HeadOverlayData overlayData)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetHeadOverlay(NativePointer, overlayId, overlayData))
                .ConfigureAwait(false);
        }

        public Task SetHeadOverlayAsync(int overlayId, HeadOverlayData overlayData)
        {
            return SetHeadOverlayAsync((uint) overlayId, overlayData);
        }

        public async Task SetCustomizationAsync(bool isMale, HeadBlendData headBlend, uint eyeColor, uint hairColor, uint highlightColor, float[] faceFeatures,
            IDictionary<int, HeadOverlayData> headOverlays, IDictionary<uint, uint> decorations)
        {
            Contract.NotNull(headOverlays, nameof(headOverlays));
            Contract.NotNull(decorations, nameof(decorations));
            CheckExistence();

            var headOverlayKeys = headOverlays.Keys.ToArray();
            var headOverlayValues = headOverlays.Values.ToArray();

            var decorationKeys = decorations.Keys.ToArray();
            var decorationValues = decorations.Values.ToArray();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetCustomization(NativePointer, isMale, headBlend, eyeColor, hairColor, highlightColor, faceFeatures, (ulong) faceFeatures.Length, headOverlayKeys,
                headOverlayValues, (ulong) headOverlayKeys.Length, decorationKeys, decorationValues, (ulong) decorationKeys.Length))
                .ConfigureAwait(false);
        }

        public Task SetCustomizationAsync(bool isMale, HeadBlendData headBlend, int eyeColor, int hairColor, int highlightColor, float[] faceFeatures,
            IDictionary<int, HeadOverlayData> headOverlays, IDictionary<int, int> decorations)
        {
            return SetCustomizationAsync(isMale, headBlend, (uint) eyeColor, (uint) hairColor, (uint) highlightColor, faceFeatures, headOverlays,
                decorations.ToDictionary(x => (uint) x.Key, x => (uint) x.Value));
        }
    }
}
