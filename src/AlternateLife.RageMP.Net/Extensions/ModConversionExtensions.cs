using System.Drawing;
using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Extensions
{
    internal static class ModConversionExtensions
    {
        internal static Color FromModColor(this ColorRgba color)
        {
            return Color.FromArgb(color.GetAlpha(), color.GetRed(), color.GetGreen(), color.GetBlue());
        }

        internal static ColorRgba ToModColor(this Color color)
        {
            return new ColorRgba(color.R, color.G, color.B, color.A);
        }

        internal static uint GetNumberValue(this Color color)
        {
            return (uint) ((color.A << 24) + (color.B << 16) + (color.G << 8) + color.R);
        }
    }
}
