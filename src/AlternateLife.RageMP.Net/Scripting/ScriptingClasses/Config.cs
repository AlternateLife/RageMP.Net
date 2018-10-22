using System;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses
{
    internal class Config : IConfig
    {
        private readonly IntPtr _nativePointer;
        private readonly Plugin _plugin;

        internal Config(IntPtr nativePointer, Plugin plugin)
        {
            _nativePointer = nativePointer;
            _plugin = plugin;
        }

        public int GetInt(string key, int defaultValue)
        {
            Contract.NotEmpty(key, nameof(key));

            using (var converter = new StringConverter())
            {
                return Rage.Config.Config_GetInt(_nativePointer, converter.StringToPointer(key), defaultValue);
            }
        }

        public string GetString(string key, string defaultValue)
        {
            Contract.NotEmpty(key, nameof(key));

            using (var converter = new StringConverter())
            {
                var result = Rage.Config.Config_GetString(_nativePointer, converter.StringToPointer(key), converter.StringToPointer(defaultValue));

                return StringConverter.PointerToString(result);
            }
        }
    }
}
