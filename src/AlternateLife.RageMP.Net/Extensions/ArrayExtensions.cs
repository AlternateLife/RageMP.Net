using System;

namespace AlternateLife.RageMP.Net.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] AppendArray<T>(this T[] array, T[] items)
        {
            int length = array.Length;
            Array.Resize(ref array, length + items.Length);
            Array.Copy(items, 0, array, length, items.Length);
            return array;
        }
    }
}