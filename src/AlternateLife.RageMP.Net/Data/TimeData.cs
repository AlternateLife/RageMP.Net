using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Data
{
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct TimeData
    {
        [FieldOffset(0)]
        internal readonly uint NumberValue;

        public TimeData(byte hour, byte minute, byte second)
        {
            NumberValue = ((uint) second << 16) + ((uint) minute << 8) + hour;
        }

        public byte GetHour()
        {
            return (byte) (NumberValue & 0xFF);
        }

        public byte GetMinute()
        {
            return (byte) ((NumberValue >> 8) & 0xFF);
        }

        public byte GetSecond()
        {
            return (byte) ((NumberValue >> 16) & 0xFF);
        }
    }
}
