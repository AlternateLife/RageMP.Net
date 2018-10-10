using System.Collections.Generic;
using RageMP.Net.Data;
using RageMP.Net.Native;

namespace RageMP.Net.Entities
{
    public partial class Player
    {
        public int EyeColor { get; set; }
        public int HairColor { get; }
        public int HairHighlightColor { get; }
        public HeadBlendData HeadBlend { get; set; }

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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public void SetHeadOverlay(uint overlayId, HeadOverlayData overlayData)
        {
            throw new System.NotImplementedException();
        }

    }
}
