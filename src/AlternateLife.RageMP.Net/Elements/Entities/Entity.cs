using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
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
            return _plugin.Schedule(() => Rage.Entity.Entity_Destroy(NativePointer));
        }

        public bool TryGetSharedData(string key, out object data)
        {
            Contract.NotEmpty(key, nameof(key));

            using (var converter = new StringConverter())
            {
                var argument = Rage.Entity.Entity_GetVariable(NativePointer, converter.StringToPointer(key));

                data = Marshal.PtrToStructure<ArgumentData>(argument).ToObject();

                return data != null;
            }
        }

        public void SetSharedData(string key, object data)
        {
            Contract.NotEmpty(key, nameof(key));

            using (var converter = new StringConverter())
            {
                Rage.Entity.Entity_SetVariable(NativePointer, converter.StringToPointer(key), ArgumentData.ConvertFromObject(data));
            }
        }

        public void SetSharedData(IDictionary<string, object> data)
        {
            Contract.NotNull(data, nameof(data));

            using (var converter = new StringConverter())
            {
                var keys = new IntPtr[data.Count];
                var values = new ArgumentData[data.Count];

                var index = 0;
                foreach (var element in data)
                {
                    keys[index] = converter.StringToPointer(element.Key);
                    values[index] = ArgumentData.ConvertFromObject(element.Value);

                    index++;
                }

                Rage.Entity.Entity_SetVariables(NativePointer, keys, values, (ulong) data.Count);
            }
        }

        public bool HasSharedData(string key)
        {
            Contract.NotEmpty(key, nameof(key));

            return TryGetSharedData(key, out _);
        }

        public void ResetSharedData(string key)
        {
            Contract.NotEmpty(key, nameof(key));

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
    }
}
