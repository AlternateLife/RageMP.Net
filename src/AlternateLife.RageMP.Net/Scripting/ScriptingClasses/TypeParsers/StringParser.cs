using System;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses.TypeParsers
{
    internal class StringParser : ITypeParser
    {
        public bool TryParse(string s, Type targetType, out object value)
        {
            value = s;
            return true;
        }
    }
}