using System;
using System.Runtime.InteropServices;
using RageMP.Net.Interfaces;

namespace RageMP.Net.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct EntityData
    {
        public byte Type;
        public ushort Id;
        public IntPtr Pointer;

        public EntityData(IEntity entity)
        {
            Type = (byte) entity.Type;
            Id = (ushort) entity.Id;
            Pointer = entity.NativePointer;
        }
    }
}
