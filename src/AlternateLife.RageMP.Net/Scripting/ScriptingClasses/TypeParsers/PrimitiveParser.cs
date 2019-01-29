using System;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses.TypeParsers
{
    internal class PrimitiveParser<T> : ITypeParser
    {
        private readonly ParserDelegate<T> _parser;

        public PrimitiveParser(ParserDelegate<T> parser)
        {
            _parser = parser;
        }

        public bool TryParse(string inputString, Type targetType, out object value)
        {
            if (_parser(inputString, out T val) == false)
            {
                value = default(object);
                return false;
            }

            value = val;
            return true;
        }
    }
}
