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
            yield return new KeyValuePair<Type, ITypeParser>(typeof(int), new PrimitiveParser<int>(int.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(float), new PrimitiveParser<float>(float.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(double), new PrimitiveParser<double>(double.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(uint),    new PrimitiveParser<uint>(uint.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(long), new PrimitiveParser<long>(long.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(char), new PrimitiveParser<char>(char.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(bool), new PrimitiveParser<bool>(bool.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(byte), new PrimitiveParser<byte>(byte.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(sbyte), new PrimitiveParser<sbyte>(sbyte.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(short), new PrimitiveParser<short>(short.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(decimal), new PrimitiveParser<decimal>(decimal.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(ushort), new PrimitiveParser<ushort>(ushort.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(ulong), new PrimitiveParser<ulong>(ulong.TryParse));
            yield return new KeyValuePair<Type, ITypeParser>(typeof(string), new StringParser());
            yield return new KeyValuePair<Type, ITypeParser>(typeof(Enum), new EnumParser());
        }
    }
}