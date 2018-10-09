namespace RageMP.Net.Data
{
    public struct ClothData
    {
        public byte Drawable { get; }
        public byte Texture { get; }
        public byte Palette { get; }

        public ClothData(byte drawable, byte texture, byte palette)
        {
            Drawable = drawable;
            Texture = texture;
            Palette = palette;
        }
    }
}
