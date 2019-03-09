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

        protected Entity(IntPtr nativePointer, Plugin plugin, EntityType type)
        {
            NativePointer = nativePointer;
            _plugin = plugin;

            Id = Rage.Entity.Entity_GetId(NativePointer);
            Type = type;
            Exists = true;
        }

        public async Task SetModelAsync(uint value)
        {
            CheckExistence();

            await _plugin.Schedule(() => Rage.Entity.Entity_SetModel(NativePointer, value)).ConfigureAwait(false);
        }

        public async Task<uint> GetModelAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => Rage.Entity.Entity_GetModel(NativePointer)).ConfigureAwait(false);
        }

        public async Task SetAlphaAsync(uint value)
        {
            CheckExistence();

            await _plugin.Schedule(() => Rage.Entity.Entity_SetAlpha(NativePointer, value)).ConfigureAwait(false);
        }

        public async Task<uint> GetAlphaAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => Rage.Entity.Entity_GetAlpha(NativePointer)).ConfigureAwait(false);
        }

        public async Task SetDimensionAsync(uint value)
        {
            CheckExistence();

            await _plugin.Schedule(() => Rage.Entity.Entity_SetDimension(NativePointer, value)).ConfigureAwait(false);
        }

        public async Task<uint> GetDimensionAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => Rage.Entity.Entity_GetDimension(NativePointer)).ConfigureAwait(false);
        }

        public async Task SetPositionAsync(Vector3 value)
        {
            CheckExistence();

            await _plugin.Schedule(() => Rage.Entity.Entity_SetPosition(NativePointer, value)).ConfigureAwait(false);
        }

        public async Task<Vector3> GetPositionAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => StructConverter.PointerToStruct<Vector3>(Rage.Entity.Entity_GetPosition(NativePointer))).ConfigureAwait(false);
        }

        public virtual async Task SetRotationAsync(Vector3 value)
        {
            CheckExistence();

            await _plugin.Schedule(() => Rage.Entity.Entity_SetRotation(NativePointer, value)).ConfigureAwait(false);
        }

        public virtual async Task<Vector3> GetRotationAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => StructConverter.PointerToStruct<Vector3>(Rage.Entity.Entity_GetRotation(NativePointer))).ConfigureAwait(false);
        }

        public async Task<Vector3> GetVelocityAsync()
        {
            CheckExistence();

            return await _plugin.Schedule(() => StructConverter.PointerToStruct<Vector3>(Rage.Entity.Entity_GetVelocity(NativePointer))).ConfigureAwait(false);
        }

        public Task DestroyAsync()
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
