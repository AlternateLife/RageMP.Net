using System;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Helpers
{
    internal class StructConverter
    {
        public static T PointerToStruct<T>(IntPtr pointer, bool freePointer = true)
        {
            var value = Marshal.PtrToStructure<T>(pointer);

            if (freePointer)
            {
                Rage.FreeObject(pointer);
            }

            return value;
        }
    }
}
