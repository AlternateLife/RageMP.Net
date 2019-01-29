using System;
using System.Collections.Generic;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting.ScriptingClasses.TypeParsers;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses
{
    internal static class TypeParserRegister
    {
        public static IEnumerable<KeyValuePair<Type, ITypeParser>> GetStringParsers()
        {
            KeyValuePair<Type, ITypeParser> AddParserDelegate<T>(ParserDelegate<T> parserDelegate)
            {
                return AddParser<T>(new PrimitiveParser<T>(parserDelegate));
            }

            KeyValuePair<Type, ITypeParser> AddParser<T>(ITypeParser parser)
            {
                return new KeyValuePair<Type, ITypeParser>(typeof(T), parser);
            }

            yield return AddParserDelegate<int>(int.TryParse);
            yield return AddParserDelegate<float>(float.TryParse);
            yield return AddParserDelegate<double>(double.TryParse);
            yield return AddParserDelegate<uint>(uint.TryParse);
            yield return AddParserDelegate<long>(long.TryParse);
            yield return AddParserDelegate<char>(char.TryParse);
            yield return AddParserDelegate<bool>(bool.TryParse);
            yield return AddParserDelegate<byte>(byte.TryParse);
            yield return AddParserDelegate<sbyte>(sbyte.TryParse);
            yield return AddParserDelegate<short>(short.TryParse);
            yield return AddParserDelegate<decimal>(decimal.TryParse);
            yield return AddParserDelegate<ushort>(ushort.TryParse);
            yield return AddParserDelegate<ulong>(ulong.TryParse);
            yield return AddParser<string>(new StringParser());
            yield return AddParser<Enum>(new EnumParser());
        }
    }
}
