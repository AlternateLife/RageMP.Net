using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AlternateLife.RageMP.Net.Helpers
{
    internal static class ArrayHelper
    {
        internal static List<T> ConvertIntPtr<T>(IntPtr arrayPointer, ulong size, Func<IntPtr, T> creator)
        {
            var elements = new List<T>();
            var pointerSize = Marshal.SizeOf<IntPtr>();

            for (var i = 0; i < (int) size; i++)
            {
                var targetPointer = Marshal.ReadIntPtr(arrayPointer + pointerSize * i);

                elements.Add(creator(targetPointer));
            }

            return elements;
        }
    }
}
