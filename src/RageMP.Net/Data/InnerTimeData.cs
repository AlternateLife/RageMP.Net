namespace AlternateLife.RageMP.Net.Data
{
    internal struct InnerTimeData
    {
        public readonly byte Hour;
        public readonly byte Minute;
        public readonly byte Second;

        public InnerTimeData(byte hour, byte minute, byte second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
    }
}
