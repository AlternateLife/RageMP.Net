using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;
using Newtonsoft.Json;

namespace AlternateLife.RageMP.Net.Data
{
    [StructLayout(LayoutKind.Explicit, Size = 13, Pack = 1)]
    internal struct ArgumentData
    {
        [FieldOffset(0)]
        public bool BoolValue;

        [FieldOffset(0)]
        public int Int32Value;

        [FieldOffset(0)]
        public float FloatValue;

        [FieldOffset(0)]
        public IntPtr StringValue;

        [FieldOffset(0)]
        public Vector3 Vector3Value;

        [FieldOffset(0)]
        public EntityData EntityValue;

        [FieldOffset(12)]
        public byte ValueType;

        public static ArgumentData[] ConvertFromObjects(IEnumerable<object> arguments)
        {
            return arguments.Select(ConvertFromObject).ToArray();
        }

        public static ArgumentData ConvertFromObject(object element)
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
                        MP.Logger.Warn($"Provided entity \"{entity}\" is not valid, replacing with NULL.");

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

        public object ToObject()
        {
            switch ((ArgumentValueType)ValueType)
            {
                case ArgumentValueType.Int:
                    return Int32Value;

                case ArgumentValueType.Float:
                    return FloatValue;

                case ArgumentValueType.String:
                    return StringConverter.PointerToString(StringValue);

                case ArgumentValueType.Boolean:
                    return BoolValue;

                case ArgumentValueType.Vector3:
                    return Vector3Value;

                case ArgumentValueType.Object:
                    return StringValue;

                case ArgumentValueType.Null:
                    return null;

                case ArgumentValueType.Entity:
                    return EntityValue.ToEntity();

                default:
                    MP.Logger.Warn($"Conversion not implemented for {((ArgumentValueType)ValueType).ToString()}");

                    return null;
            }
        }

        private static bool IsValueInteger(object value)
        {
            return value is sbyte
                   || value is byte
                   || value is short
                   || value is ushort
                   || value is int
                   || value is uint
                   || value is long
                   || value is ulong;
        }

        private static bool IsValueFloat(object value)
        {
            return value is float
                   || value is double
                   || value is decimal;
        }

        internal static void Dispose(ArgumentData[] data)
        {
            foreach (var argumentData in data)
            {
                switch ((ArgumentValueType) argumentData.ValueType)
                {
                    case ArgumentValueType.String:
                    case ArgumentValueType.Object:
                        Marshal.FreeHGlobal(argumentData.StringValue);

                        break;
                }
            }
        }
    }
}
