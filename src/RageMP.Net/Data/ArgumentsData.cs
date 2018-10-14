using System;
using System.Runtime.InteropServices;

namespace RageMP.Net.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct ArgumentsData
    {
        public ulong Length;
        public IntPtr Arguments;

        public object[] ToArguments()
        {
            var arguments = new object[Length];

            for (var i = 0; i < (int) Length; i++)
            {
                var address = Arguments + Marshal.SizeOf(typeof(ArgumentData)) * i;

                var argument = Marshal.PtrToStructure<ArgumentData>(address);

                arguments[i] = argument.ToObject();
            }

            return arguments;
        }
    }
}
