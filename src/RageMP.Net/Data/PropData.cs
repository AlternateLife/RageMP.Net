namespace RageMP.Net.Data
{
    public struct PropData
    {
        public byte Drawable { get; }
        public byte Texture { get; }

        public PropData(byte drawable, byte texture)
        {
            Drawable = drawable;
            Texture = texture;
        }
    }
}
