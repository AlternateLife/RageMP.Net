namespace RageMP.Net.Data
{
    public struct ColorRgb
    {
        public uint Red { get; set; }
        public uint Green { get; set; }
        public uint Blue { get; set; }

        public ColorRgb(uint red, uint green, uint blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
