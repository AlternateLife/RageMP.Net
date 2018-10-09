using System.Collections.Generic;
using RageMP.Net.Data;

namespace RageMP.Net.Entities
{
    public partial class Player
    {
        public int EyeColor { get; set; }
        public int HairColor { get; }
        public int HairHighlightColor { get; }
        public HeadBlendData HeadBlend { get; set; }

        public void RemoveDecoration(uint collection, uint overlay)
        {
            throw new System.NotImplementedException();
        }

        public void SetDecoration(uint collection, uint overlay)
        {
            throw new System.NotImplementedException();
        }

        public void SetDecorations(Dictionary<uint, uint> decorations)
        {
            throw new System.NotImplementedException();
        }

        public void SetHairColor(uint color, uint highlightColor)
        {
            throw new System.NotImplementedException();
        }

        public float GetFaceFeature(uint id)
        {
            throw new System.NotImplementedException();
        }

        public void SetFaceFeature(uint id, float scale)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateHeadBlend(float shapeMix, float skinMix, float thirdMix)
        {
            throw new System.NotImplementedException();
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
