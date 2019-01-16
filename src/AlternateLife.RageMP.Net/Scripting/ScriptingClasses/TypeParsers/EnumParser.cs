using System;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses.TypeParsers
{
    internal class EnumParser : ITypeParser
    {
        public bool TryParse(string s, Type targetType, out object value)
        {
            value = default(object);
            if (!Enum.TryParse(targetType, s, true, out object val))
            {
                return false;
            }

            value = val;
            return true;
        }
    }
}