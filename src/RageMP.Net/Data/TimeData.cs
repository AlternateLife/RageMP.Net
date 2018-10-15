using System.Runtime.InteropServices;

namespace RageMP.Net.Data
{
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct TimeData
    {
        [FieldOffset(0)]
        private readonly InnerTimeData Time;

        public TimeData(byte hour, byte minute, byte second)
        {
            Time = new InnerTimeData(hour, minute, second);
        }

        public byte GetHour()
        {
            return Time.Hour;
        }

        public byte GetMinute()
        {
            return Time.Minute;
        }

        public byte GetSecond()
        {
            return Time.Second;
        }
    }
}
