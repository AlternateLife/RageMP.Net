namespace RageMP.Net.Data
{
    public struct ClothData
    {
        public readonly byte Drawable;
        public readonly byte Texture;
        public readonly byte Palette;

        public ClothData(byte drawable, byte texture, byte palette)
        {
            Drawable = drawable;
            Texture = texture;
            Palette = palette;
        }
    }
}
