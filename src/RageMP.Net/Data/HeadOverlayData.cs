namespace RageMP.Net.Data
{
    public struct HeadOverlayData
    {
        public uint Index { get; set; }
        public float Opacity { get; set; }
        public uint ColorId { get; set; }
        public uint SecondaryColorId { get; set; }

        public HeadOverlayData(uint index, float opacity, uint colorId, uint secondaryColorId)
        {
            Index = index;
            Opacity = opacity;
            ColorId = colorId;
            SecondaryColorId = secondaryColorId;
        }
    }
}
