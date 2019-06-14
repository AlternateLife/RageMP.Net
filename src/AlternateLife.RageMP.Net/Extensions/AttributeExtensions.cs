using System;
using System.Linq;
using System.Reflection;

namespace AlternateLife.RageMP.Net.Extensions
{
    public static class AttributeExtensions
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(this ICustomAttributeProvider provider, Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            if (provider.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute att)
            {
                return valueSelector(att);
            }

            return default;
        }

        public static TAttribute GetCustomAttribute<TAttribute>(this ICustomAttributeProvider provider)
        {
            if (provider.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute attribute)
            {
                return attribute;
            }

            return default;
        }
    }
}