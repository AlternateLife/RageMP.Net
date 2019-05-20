using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Data
{
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct ColorRgba
    {
        [FieldOffset(0)]
        internal readonly uint NumberValue;

        public ColorRgba(byte red, byte green, byte blue, byte alpha = 255)
        {
            NumberValue = (uint) ((alpha << 24) + (blue << 16) + (green << 8) + red);
        }

        public byte GetRed()
        {
            return (byte) (NumberValue & 0xFF);
        }

        public byte GetGreen()
        {
            return (byte) ((NumberValue >> 8) & 0xFF);
        }

        public byte GetBlue()
        {
            return (byte) ((NumberValue >> 16) & 0xFF);
        }

        public byte GetAlpha()
        {
            return (byte) ((NumberValue >> 24) & 0xFF);
        }
    }
}
