using System;

namespace RageMP.Net.Data
{
    internal struct EntityData
    {
        public byte Type { get; }
        public ushort Id { get; }
        public IntPtr Pointer { get; }

        public EntityData(byte type, ushort id, IntPtr pointer)
        {
            Type = type;
            Id = id;
            Pointer = pointer;
        }
    }
}
