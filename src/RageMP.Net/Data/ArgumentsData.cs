using System.Runtime.InteropServices;

namespace RageMP.Net.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct ArgumentsData
    {
        public ulong Length;

        [MarshalAs(UnmanagedType.ByValArray)]
        public ArgumentData[] Arguments;
    }
}
