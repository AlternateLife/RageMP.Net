using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using RageMP.Net.Enums;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Entities
{
    public class Entity : IEntity
    {
        public IntPtr NativePointer { get; }

        public uint Id { get; }
        public EntityType Type { get; }

        public uint Model
        {
            get => Rage.Entity.Entity_GetModel(NativePointer);
            set => Rage.Entity.Entity_SetModel(NativePointer, value);
        }

        public uint Alpha
        {
            get => Rage.Entity.Entity_GetAlpha(NativePointer);
            set => Rage.Entity.Entity_SetAlpha(NativePointer, value);
        }

        public uint Dimension
        {
            get => Rage.Entity.Entity_GetDimension(NativePointer);
            set => Rage.Entity.Entity_SetDimension(NativePointer, value);
        }

        public Vector3 Position
        {
            get => Marshal.PtrToStructure<Vector3>(Rage.Entity.Entity_GetPosition(NativePointer));
            set => Rage.Entity.Entity_SetPosition(NativePointer, value);
        }

        public Vector3 Rotation
        {
            get => Marshal.PtrToStructure<Vector3>(Rage.Entity.Entity_GetRotation(NativePointer));
            set => Rage.Entity.Entity_SetRotation(NativePointer, value);
        }

        public Vector3 Velocity => Marshal.PtrToStructure<Vector3>(Rage.Entity.Entity_GetVelocity(NativePointer));

        public Entity(IntPtr nativePointer, EntityType type)
        {
            NativePointer = nativePointer;

            Id = Rage.Entity.Entity_GetId(NativePointer);
            Type = type;
        }

        public void Destroy()
        {
            Rage.Entity.Entity_Destroy(NativePointer);
        }

        public object GetVariable(string key)
        {
            throw new System.NotImplementedException();
        }

        public void SetVariable(string key, object data)
        {
            throw new System.NotImplementedException();
        }

        public void SetVariables(Dictionary<string, object> values)
        {
            throw new System.NotImplementedException();
        }

        public bool HasVariable(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
