using System;
using AlternateLife.RageMP.Net.Exceptions;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Helpers
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

        public static void EntityValid(IEntity value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (value.Exists)
            {
                return;
            }

            throw new EntityDeletedException(value, parameterName);
        }
    }
}
