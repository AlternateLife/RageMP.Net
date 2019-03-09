using System;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Scripting.ScriptingClasses
{
    internal class World : IWorld
    {
        private readonly IntPtr _nativePointer;
        private readonly Plugin _plugin;

        public TimeData Time
        {
            get => StructConverter.PointerToStruct<TimeData>(Rage.World.World_GetTime(_nativePointer));
            set => Rage.World.World_SetTime(_nativePointer, value.NumberValue);
        }

        public WeatherType Weather
        {
            get => ConvertWeatherNameToType(StringConverter.PointerToString(Rage.World.World_GetWeather(_nativePointer)));
            set
            {
                var weatherName = ConvertWeatherTypeToName(value);
                if (string.IsNullOrEmpty(weatherName))
                {
                    return;
                }

                using (var converter = new StringConverter())
                {
                    Rage.World.World_SetWeather(_nativePointer, converter.StringToPointer(weatherName));
                }
            }
        }

        public bool AreTrafficLightsLocked
        {
            get => Rage.World.World_AreTrafficLightsLocked(_nativePointer);
            set => Rage.World.World_LockTrafficLights(_nativePointer, value);
        }

        public int TrafficLightsState
        {
            get => Rage.World.World_GetTrafficLightsState(_nativePointer);
            set => Rage.World.World_SetTrafficLightsState(_nativePointer, value);
        }

        public World(IntPtr nativePointer, Plugin plugin)
        {
            _nativePointer = nativePointer;
            _plugin = plugin;
        }

        public async Task SetWeatherTransitionAsync(WeatherType weather, float time)
        {
            var weatherName = ConvertWeatherTypeToName(weather);
            if (string.IsNullOrEmpty(weatherName))
            {
                return;
            }

            using (var converter = new StringConverter())
            {
                var namePointer = converter.StringToPointer(weatherName);

                await _plugin
                    .Schedule(() => Rage.World.World_SetWeatherTransition(_nativePointer, namePointer, time))
                    .ConfigureAwait(false);
            }
        }

        public async Task RequestIplAsync(string ipl)
        {
            Contract.NotEmpty(ipl, nameof(ipl));

            using (var converter = new StringConverter())
            {
                var iplPointer = converter.StringToPointer(ipl);

                await _plugin
                    .Schedule(() => Rage.World.World_RequestIpl(_nativePointer, iplPointer))
                    .ConfigureAwait(false);
            }
        }

        public async Task RemoveIplAsync(string ipl)
        {
            Contract.NotEmpty(ipl, nameof(ipl));

            using (var converter = new StringConverter())
            {
                var iplPointer = converter.StringToPointer(ipl);

                await _plugin
                    .Schedule(() => Rage.World.World_RemoveIpl(_nativePointer, iplPointer))
                    .ConfigureAwait(false);
            }
        }

        private string ConvertWeatherTypeToName(WeatherType type)
        {
            if (Enum.IsDefined(typeof(WeatherType), type) == false)
            {
                return null;
            }

            return type.ToString().ToUpperInvariant();
        }

        private WeatherType ConvertWeatherNameToType(string name)
        {
            if (Enum.TryParse(name, true, out WeatherType type) == false)
            {
                return WeatherType.Invalid;
            }

            return type;
        }
    }
}
