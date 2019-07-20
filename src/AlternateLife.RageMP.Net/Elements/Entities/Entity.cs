using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.EventArgs;
using AlternateLife.RageMP.Net.Exceptions;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Helpers.EventDispatcher;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal abstract class Entity : IInternalEntity, IEntity
    {
        private readonly ConcurrentDictionary<string, object> _data = new ConcurrentDictionary<string, object>();

        protected readonly Plugin _plugin;

        private readonly AsyncChildEventDispatcher<EntityModelEventArgs> _modelChangeDispatcher;
        public event AsyncEventHandler<EntityModelEventArgs> ModelChange;

        public IntPtr NativePointer { get; }
        public bool Exists { get; set; }

        public uint Id { get; }
        public EntityType Type { get; }

        protected Entity(IntPtr nativePointer, Plugin plugin, EntityType type)
        {
            _modelChangeDispatcher = new AsyncChildEventDispatcher<EntityModelEventArgs>(plugin, EventType.EntityModelChanged,
                _plugin.EventScripting.EntityModelChangeDispatcher, eventArgs => Task.FromResult(eventArgs.Entity == this));

            NativePointer = nativePointer;
            _plugin = plugin;

            Id = Rage.Entity.Entity_GetId(NativePointer);
            Type = type;
            Exists = true;
        }

        public void SetModel(uint value)
        {
            CheckExistence();

            Rage.Entity.Entity_SetModel(NativePointer, value);
        }

        public Task SetModelAsync(uint value)
        {
            return _plugin.Schedule(() => SetModel(value));
        }

        public uint GetModel()
        {
            CheckExistence();

            return Rage.Entity.Entity_GetModel(NativePointer);
        }

        public Task<uint> GetModelAsync()
        {
            return _plugin.Schedule(GetModel);
        }

        public void SetAlpha(uint value)
        {
            CheckExistence();

            Rage.Entity.Entity_SetAlpha(NativePointer, value);
        }

        public Task SetAlphaAsync(uint value)
        {
            return _plugin.Schedule(() => SetAlpha(value));
        }

        public uint GetAlpha()
        {
            CheckExistence();

            return Rage.Entity.Entity_GetAlpha(NativePointer);
        }

        public Task<uint> GetAlphaAsync()
        {
            return _plugin.Schedule(GetAlpha);
        }

        public void SetDimension(uint value)
        {
            CheckExistence();

            Rage.Entity.Entity_SetDimension(NativePointer, value);
        }

        public Task SetDimensionAsync(uint value)
        {
            return _plugin.Schedule(() => SetDimension(value));
        }

        public uint GetDimension()
        {
            CheckExistence();

            return Rage.Entity.Entity_GetDimension(NativePointer);
        }

        public Task<uint> GetDimensionAsync()
        {
            return _plugin.Schedule(GetDimension);
        }

        public void SetPosition(Vector3 value)
        {
            CheckExistence();

            Rage.Entity.Entity_SetPosition(NativePointer, value);
        }

        public Task SetPositionAsync(Vector3 value)
        {
            return _plugin.Schedule(() => SetPosition(value));
        }

        public Vector3 GetPosition()
        {
            CheckExistence();

            return StructConverter.PointerToStruct<Vector3>(Rage.Entity.Entity_GetPosition(NativePointer));
        }

        public Task<Vector3> GetPositionAsync()
        {
            return _plugin.Schedule(GetPosition);
        }

        public virtual void SetRotation(Vector3 value)
        {
            CheckExistence();

            Rage.Entity.Entity_SetRotation(NativePointer, value);
        }

        public virtual Task SetRotationAsync(Vector3 value)
        {
            return _plugin.Schedule(() => SetRotation(value));
        }

        public virtual Vector3 GetRotation()
        {
            CheckExistence();

            return StructConverter.PointerToStruct<Vector3>(Rage.Entity.Entity_GetRotation(NativePointer));
        }

        public virtual Task<Vector3> GetRotationAsync()
        {
            return _plugin.Schedule(GetRotation);
        }

        public Vector3 GetVelocity()
        {
            return StructConverter.PointerToStruct<Vector3>(Rage.Entity.Entity_GetVelocity(NativePointer));
        }

        public Task<Vector3> GetVelocityAsync()
        {
            return _plugin.Schedule(GetVelocity);
        }

        public virtual void Destroy()
        {
            CheckExistence();

            Rage.Entity.Entity_Destroy(NativePointer);

            _modelChangeDispatcher.ClearSubscriptions();
        }

        public Task DestroyAsync()
        {
            return _plugin.Schedule(Destroy);
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
                var arg = _plugin.ArgumentConverter.ConvertFromObject(data);

                Rage.Entity.Entity_SetVariable(NativePointer, converter.StringToPointer(key), ref arg);
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
