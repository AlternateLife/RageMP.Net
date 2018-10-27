using System;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Data
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
            var entityType = (EntityType) Type;

            if (MP.EntityPoolMapping.TryGetValue(entityType, out var pool) == false)
            {
                MP.Logger.Warn($"Entity conversion not implemented for {entityType.ToString()}");

                return null;
            }

            return pool.GetEntity(Pointer);
        }
    }
}
