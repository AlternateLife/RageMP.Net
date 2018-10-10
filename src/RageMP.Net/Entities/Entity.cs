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
        protected readonly IntPtr _native;

        public uint Id { get; }
        public EntityType Type { get; }

        public uint Model
        {
            get => Rage.Entity.Entity_GetModel(_native);
            set => Rage.Entity.Entity_SetModel(_native, value);
        }

        public uint Alpha
        {
            get => Rage.Entity.Entity_GetAlpha(_native);
            set => Rage.Entity.Entity_SetAlpha(_native, value);
        }

        public uint Dimension
        {
            get => Rage.Entity.Entity_GetDimension(_native);
            set => Rage.Entity.Entity_SetDimension(_native, value);
        }

        public Vector3 Position
        {
            get => Marshal.PtrToStructure<Data.Vector3>(Rage.Entity.Entity_GetPosition(_native)).ToNumericsVector();
            set => Rage.Entity.Entity_SetPosition(_native, Data.Vector3.FromNumericsVector(value));
        }

        public Vector3 Rotation
        {
            get => Marshal.PtrToStructure<Data.Vector3>(Rage.Entity.Entity_GetRotation(_native)).ToNumericsVector();
            set => Rage.Entity.Entity_SetRotation(_native, Data.Vector3.FromNumericsVector(value));
        }

        public Vector3 Velocity => Marshal.PtrToStructure<Data.Vector3>(Rage.Entity.Entity_GetVelocity(_native)).ToNumericsVector();

        public Entity(IntPtr native, EntityType type)
        {
            _native = native;

            Id = Rage.Entity.Entity_GetId(_native);
            Type = type;
        }

        public void Destroy()
        {
            Rage.Entity.Entity_Destroy(_native);
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
