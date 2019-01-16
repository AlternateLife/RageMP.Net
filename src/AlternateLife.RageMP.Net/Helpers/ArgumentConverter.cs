using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using Newtonsoft.Json;

namespace AlternateLife.RageMP.Net.Helpers
{
    internal class ArgumentConverter
    {
        private readonly Plugin _plugin;

        public ArgumentConverter(Plugin plugin)
        {
            _plugin = plugin;
        }

        public ArgumentData[] ConvertFromObjects(IEnumerable<object> arguments)
        {
            return arguments.Select(ConvertFromObject).ToArray();
        }

        public ArgumentData ConvertFromObject(object element)
        {
            switch (element)
            {
                case string text:
                {
                    return new ArgumentData
                    {
                        ValueType = (byte) ArgumentValueType.String,
                        StringValue = StringConverter.StringToPointerUnsafe(text)
                    };
                }

                case bool state:
                {
                    return new ArgumentData
                    {
                        ValueType = (byte) ArgumentValueType.Boolean,
                        BoolValue = state
                    };
                }

                case object number when IsValueInteger(number):
                {
                    return new ArgumentData
                    {
                        ValueType = (byte) ArgumentValueType.Int,
                        Int32Value = Convert.ToInt32(number)
                    };
                }

                case object number when IsValueUnsignedInteger(number):
                {
                    return new ArgumentData
                    {
                        ValueType = (byte) ArgumentValueType.Int,
                        UnsignedInt32Value = Convert.ToUInt32(number)
                    };
                }

                case object number when IsValueFloat(number):
                {
                    return new ArgumentData
                    {
                        ValueType = (byte) ArgumentValueType.Float,
                        FloatValue = Convert.ToSingle(number)
                    };
                }

                case Vector3 vector3:
                {
                    return new ArgumentData
                    {
                        ValueType = (byte) ArgumentValueType.Vector3,
                        Vector3Value = vector3
                    };
                }

                case IEntity entity:
                {
                    if (entity.Exists == false)
                    {
                        _plugin.Logger.Warn($"Provided entity \"{entity}\" is not valid, replacing with NULL.");

                        break;
                    }

                    return new ArgumentData
                    {
                        ValueType = (byte) ArgumentValueType.Entity,
                        EntityValue = new EntityData(entity)
                    };
                }

                default:
                {
                    if (element == default(object))
                    {
                        break;
                    }

                    return new ArgumentData
                    {
                        StringValue = StringConverter.StringToPointerUnsafe(JsonConvert.SerializeObject(element)),
                        ValueType = (byte) ArgumentValueType.Object
                    };
                }
            }

            return new ArgumentData
            {
                ValueType = (byte) ArgumentValueType.Null
            };
        }

        public object[] ConvertToObjects(ArgumentsData data)
        {
            var arguments = new object[data.Length];

            for (var i = 0; i < (int) data.Length; i++)
            {
                var address = data.Arguments + Marshal.SizeOf(typeof(ArgumentData)) * i;

                var argument = Marshal.PtrToStructure<ArgumentData>(address);

                arguments[i] = ConvertToObject(argument);
            }

            return arguments;
        }

        public object ConvertToObject(ArgumentData data)
        {
            switch ((ArgumentValueType) data.ValueType)
            {
                case ArgumentValueType.Int:
                    return data.Int32Value;

                case ArgumentValueType.Float:
                    return data.FloatValue;

                case ArgumentValueType.String:
                case ArgumentValueType.Object:
                    return StringConverter.PointerToString(data.StringValue, false);

                case ArgumentValueType.Boolean:
                    return data.BoolValue;

                case ArgumentValueType.Vector3:
                    return data.Vector3Value;

                case ArgumentValueType.Null:
                    return null;

                case ArgumentValueType.Entity:
                    return ConvertToEntity(data.EntityValue);

                default:
                    _plugin.Logger.Warn($"Conversion not implemented for ValueType {data.ValueType}");

                    return null;
            }
        }

        private bool IsValueInteger(object value)
        {
            return value is sbyte
                   || value is short
                   || value is int
                   || value is long;
        }

        private bool IsValueUnsignedInteger(object value)
        {
            return value is byte
                   || value is ushort
                   || value is uint
                   || value is ulong;
        }

        private bool IsValueFloat(object value)
        {
            return value is float
                   || value is double
                   || value is decimal;
        }

        public IEntity ConvertToEntity(EntityData data)
        {
            var entityType = (EntityType) data.Type;

            if (_plugin.TryGetPool(entityType, out var pool) == false)
            {
                _plugin.Logger.Warn($"Entity conversion not implemented for {entityType.ToString()}");

                return null;
            }

            return pool.GetEntity(data.Pointer);
        }
    }
}
