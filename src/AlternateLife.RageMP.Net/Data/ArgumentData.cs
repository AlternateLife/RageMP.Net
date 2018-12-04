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
        public uint UnsignedInt32Value;

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
