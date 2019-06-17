using System.Linq;
using System.Reflection;

namespace AlternateLife.RageMP.Net.Extensions
{
    public static class CustomAttributeProviderExtensions
    {
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