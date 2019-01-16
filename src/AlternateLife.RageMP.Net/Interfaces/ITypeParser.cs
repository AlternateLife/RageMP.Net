using System;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ITypeParser
    {
        bool TryParse(string s, Type targetType, out object value);
    }
}