using System.Linq;
using System.Reflection;

namespace AlternateLife.RageMP.Net.Extensions
{
    public static class CustomAttributeProviderExtensions
    {
        public static bool TryGetCustomAttribute<TAttribute>(this ICustomAttributeProvider provider, out TAttribute attribute)
        {
            attribute = default;
            if (provider.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute convertedAttribute)
            {
                attribute = convertedAttribute;
                return true;
            }

            return false;
        }
    }
}