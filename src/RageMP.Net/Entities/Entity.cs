using System;
using System.Collections.Generic;
using System.Numerics;
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

        public uint Model { get; set; }
        public uint Alpha { get; set; }

        public uint Dimension { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Velocity { get; }

        public Entity(IntPtr native, EntityType type)
        {
            _native = native;

            Id = Rage.Entity.Entity_GetId(_native);
            //Rage.Player.Player_OutputChatBox(_native, "TEst");
            Type = type;
        }

        public void Destroy()
        {
            throw new System.NotImplementedException();
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
