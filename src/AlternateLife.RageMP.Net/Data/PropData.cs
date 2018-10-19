namespace AlternateLife.RageMP.Net.Data
{
    public struct PropData
    {
        public readonly byte Drawable;
        public readonly byte Texture;

        public PropData(byte drawable, byte texture)
        {
            Drawable = drawable;
            Texture = texture;
        }
    }
}
