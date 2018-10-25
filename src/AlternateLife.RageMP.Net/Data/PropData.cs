using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
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
