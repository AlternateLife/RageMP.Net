using System;

namespace RageMP.Net.Helpers
{
    internal static class Contract
    {
        public static void NotNull(object value, string parameterName)
        {
            if (value != null)
            {
                return;
            }

            throw new ArgumentNullException(parameterName);
        }

        public static void NotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value) == false)
            {
                return;
            }

            throw new ArgumentNullException(parameterName);
        }
    }
}
