using System;
using System.Runtime.InteropServices;

namespace RageMP.Net.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct EntityData
    {
        public byte Type;
        public ushort Id;
        public IntPtr Pointer;

        public EntityData(byte type, ushort id, IntPtr pointer)
        {
            Type = type;
            Id = id;
            Pointer = pointer;
        }
    }
}
