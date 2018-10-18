using System;

namespace RageMP.Net.Interfaces
{
    public interface IConfig
    {
        /// <summary>
        /// Get number value from the server config.
        /// </summary>
        /// <param name="key">Key of the value</param>
        /// <param name="defaultValue">Default value if key was not found</param>
        /// <returns>Actual value if the key was found, otherwise the default value</returns>
        /// <exception cref="ArgumentNullException">Key is null or empty</exception>
        int GetInt(string key, int defaultValue = default(int));

        /// <summary>
        /// Get string value from the server config.
        /// </summary>
        /// <param name="key">Key of the value</param>
        /// <param name="defaultValue">Default value if key was not found</param>
        /// <returns>Actual value if the key was found, otherwise the default value</returns>
        /// <exception cref="ArgumentNullException">Key is null or empty</exception>
        string GetString(string key, string defaultValue = "");
    }
}
