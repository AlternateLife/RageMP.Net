using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Exceptions;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal abstract class Entity : IInternalEntity, IEntity
    {
        private readonly ConcurrentDictionary<string, object> _data = new ConcurrentDictionary<string, object>();

        protected readonly Plugin _plugin;

        public IntPtr NativePointer { get; }
        public bool Exists { get; set; }

        public uint Id { get; }
        public EntityType Type { get; }

        public uint Model
        {
            get
            {
                CheckExistence();

                return Rage.Entity.Entity_GetModel(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Entity.Entity_SetModel(NativePointer, value);
            }
        }

        public uint Alpha
        {
            get
            {
                CheckExistence();

                return Rage.Entity.Entity_GetAlpha(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Entity.Entity_SetAlpha(NativePointer, value);
            }
        }

        public uint Dimension
        {
            get
            {
                CheckExistence();

                return Rage.Entity.Entity_GetDimension(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Entity.Entity_SetDimension(NativePointer, value);
            }
        }

        public Vector3 Position
        {
            get
            {
                CheckExistence();

                return StructConverter.PointerToStruct<Vector3>(Rage.Entity.Entity_GetPosition(NativePointer));
            }
            set
            {
                CheckExistence();

                Rage.Entity.Entity_SetPosition(NativePointer, value);
            }
        }

        public virtual Vector3 Rotation
        {
            get
            {
                CheckExistence();

                return StructConverter.PointerToStruct<Vector3>(Rage.Entity.Entity_GetRotation(NativePointer));
            }
            set
            {
                CheckExistence();

                Rage.Entity.Entity_SetRotation(NativePointer, value);
            }
        }

        public Vector3 Velocity
        {
            get
            {
                CheckExistence();

                return StructConverter.PointerToStruct<Vector3>(Rage.Entity.Entity_GetVelocity(NativePointer));
            }
        }

        protected Entity(IntPtr nativePointer, Plugin plugin, EntityType type)
        {
            NativePointer = nativePointer;
            _plugin = plugin;

            Id = Rage.Entity.Entity_GetId(NativePointer);
            Type = type;
            Exists = true;
        }

        public Task Destroy()
        {
            CheckExistence();

            return _plugin.Schedule(() => Rage.Entity.Entity_Destroy(NativePointer));
        }

        public bool TryGetSharedData(string key, out object data)
        {
            Contract.NotEmpty(key, nameof(key));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var argument = Rage.Entity.Entity_GetVariable(NativePointer, converter.StringToPointer(key));

                data = _plugin.ArgumentConverter.ConvertToObject(StructConverter.PointerToStruct<ArgumentData>(argument));

                return data != null;
            }
        }

        public void SetSharedData(string key, object data)
        {
            Contract.NotEmpty(key, nameof(key));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                Rage.Entity.Entity_SetVariable(NativePointer, converter.StringToPointer(key), _plugin.ArgumentConverter.ConvertFromObject(data));
            }
        }

        public void SetSharedData(IDictionary<string, object> data)
        {
            Contract.NotNull(data, nameof(data));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var keys = new IntPtr[data.Count];
                var values = new ArgumentData[data.Count];

                var index = 0;
                foreach (var element in data)
                {
                    keys[index] = converter.StringToPointer(element.Key);
                    values[index] = _plugin.ArgumentConverter.ConvertFromObject(element.Value);

                    index++;
                }

                Rage.Entity.Entity_SetVariables(NativePointer, keys, values, (ulong) data.Count);
            }
        }

        public bool HasSharedData(string key)
        {
            Contract.NotEmpty(key, nameof(key));
            CheckExistence();

            return TryGetSharedData(key, out _);
        }

        public void ResetSharedData(string key)
        {
            Contract.NotEmpty(key, nameof(key));
            CheckExistence();

            SetSharedData(key, null);
        }

        public bool TryGetData(string key, out object data)
        {
            Contract.NotEmpty(key, nameof(key));

            return _data.TryGetValue(key, out data);
        }

        public void SetData(string key, object data)
        {
            Contract.NotEmpty(key, nameof(key));

            _data[key] = data;
        }

        public void SetData(IDictionary<string, object> values)
        {
            Contract.NotNull(values, nameof(values));

            foreach (var keyValue in values)
            {
                _data[keyValue.Key] = keyValue.Value;
            }
        }

        public bool HasData(string key)
        {
            Contract.NotEmpty(key, nameof(key));

            return _data.ContainsKey(key);
        }

        public void ResetData(string key)
        {
            Contract.NotEmpty(key, nameof(key));

            _data.Remove(key, out _);
        }

        public void ClearData()
        {
            _data.Clear();
        }

        protected void CheckExistence()
        {
            if (Exists)
            {
                return;
            }

            throw new EntityDeletedException(this);
        }

        public override string ToString()
        {
            return $"Entity {Type.ToString()}: Id {Id}, Exists: {Exists}";
        }
    }
}
