using System;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ITypeParser
    {
        bool TryParse(string inputString, Type targetType, out object value);
    }
}