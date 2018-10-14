using System;
using System.Runtime.InteropServices;
using RageMP.Net.Enums;
using RageMP.Net.Interfaces;
using RageMP.Net.Scripting;

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

        public IEntity ToEntity()
        {
            if (MP.EntityPoolMapping.TryGetValue((EntityType) Type, out var pool) == false)
            {
                MP.Logger.Warn($"Entity conversion not implemented for {((EntityType)Type).ToString()}");

                return null;
            }

            return pool.GetEntity(Pointer);
        }
    }
}
