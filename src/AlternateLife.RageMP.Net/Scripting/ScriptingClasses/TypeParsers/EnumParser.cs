using System;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses.TypeParsers
{
    internal class EnumParser : ITypeParser
    {
        public bool TryParse(string inputString, Type targetType, out object value)
        {
            return Enum.TryParse(targetType, inputString, true, out value);
        }
    }
}