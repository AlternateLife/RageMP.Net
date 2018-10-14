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
            switch ((EntityType)Type)
            {
                case EntityType.Blip:
                    return MP.InternalBlips[Pointer];

                case EntityType.Checkpoint:
                    return MP.InternalCheckpoints[Pointer];

                case EntityType.Player:
                    return MP.InternalPlayers[Pointer];

                case EntityType.Vehicle:
                    return MP.InternalVehicles[Pointer];

                default:
                    MP.Logger.Warn($"Entity conversion not implemented for {((EntityType)Type).ToString()}");

                    return null;
            }
        }
    }
}
