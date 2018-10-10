using System;
using System.Numerics;
using System.Runtime.InteropServices;
using RageMP.Net.Enums;

namespace RageMP.Net.Data
{
    [StructLayout(LayoutKind.Explicit, Size = 13)]
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
        public IntPtr Vector3Value;

        [FieldOffset(0)]
        public EntityData EntityValue;

        [FieldOffset(12)]
        public byte ValueType;

        public static ArgumentData[] ConvertFromArguments(object[] arguments)
        {
            var data = new ArgumentData[arguments.Length];

            for (int i = 0; i < arguments.Length; i++)
            {
                var element = arguments[i];

                switch (element)
                {
                    case string text:
                    {
                        data[i] = new ArgumentData
                        {
                            ValueType = (byte) ArgumentValueType.String,
                            StringValue = Marshal.StringToCoTaskMemAnsi(text)
                        };

                        break;
                    }

                    case bool state:
                    {
                        data[i] = new ArgumentData
                        {
                            ValueType = (byte) ArgumentValueType.Boolean,
                            BoolValue = state
                        };

                        break;
                    }

                    case object number when IsValueInteger(number):
                    {
                        data[i] = new ArgumentData
                        {
                            ValueType = (byte) ArgumentValueType.Int,
                            Int32Value = Convert.ToInt32(number)
                        };

                        break;
                    }

                    case object number when IsValueFloat(number):
                    {
                        data[i] = new ArgumentData
                        {
                            ValueType = (byte) ArgumentValueType.Float,
                            FloatValue = Convert.ToSingle(number)
                        };

                        break;
                    }

                    case Vector3 vector3:
                    {
                        Console.Write("VECTOR: " + vector3 + " -> " + Marshal.SizeOf(typeof(Vector3)));

                        IntPtr buffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Vector3)));

                        Marshal.StructureToPtr(vector3, buffer, true);

                        data[i] = new ArgumentData
                        {
                            ValueType = (byte) ArgumentValueType.Vector3,
                            Vector3Value = buffer
                        };

                        break;
                    }
                }
            }


            return data;
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
    }
}
