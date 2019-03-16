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

        public World(IntPtr nativePointer, Plugin plugin)
        {
            _nativePointer = nativePointer;
            _plugin = plugin;
        }

        public void SetTime(TimeData time)
        {
            Rage.World.World_SetTime(_nativePointer, time);
        }

        public Task SetTimeAsync(TimeData time)
        {
            return _plugin.Schedule(() => SetTime(time));
        }

        public TimeData GetTime()
        {
            return StructConverter.PointerToStruct<TimeData>(Rage.World.World_GetTime(_nativePointer));
        }

        public Task<TimeData> GetTimeAsync()
        {
            return _plugin.Schedule(GetTime);
        }

        public void SetWeather(WeatherType type)
        {
            var weatherName = ConvertWeatherTypeToName(type);

            Contract.NotEmpty(weatherName, nameof(type));

            using (var converter = new StringConverter())
            {
                Rage.World.World_SetWeather(_nativePointer, converter.StringToPointer(weatherName));
            }
        }

        public Task SetWeatherAsync(WeatherType type)
        {
            return _plugin.Schedule(() => SetWeather(type));
        }

        public WeatherType GetWeather()
        {
            var weatherPointer = Rage.World.World_GetWeather(_nativePointer);

            return ConvertWeatherNameToType(StringConverter.PointerToString(weatherPointer));
        }

        public Task<WeatherType> GetWeatherAsync()
        {
            return _plugin.Schedule(GetWeather);
        }

        public void SetTrafficLightsLocked(bool locked)
        {
            Rage.World.World_LockTrafficLights(_nativePointer, locked);
        }

        public Task SetTrafficLightsLockedAsync(bool locked)
        {
            return _plugin.Schedule(() => SetTrafficLightsLocked(locked));
        }

        public bool AreTrafficLightsLocked()
        {
            return Rage.World.World_AreTrafficLightsLocked(_nativePointer);
        }

        public Task<bool> AreTrafficLightsLockedAsync()
        {
            return _plugin.Schedule(AreTrafficLightsLocked);
        }

        public void SetTrafficLightsState(int state)
        {
            Rage.World.World_SetTrafficLightsState(_nativePointer, state);
        }

        public Task SetTrafficLightsStateAsync(int state)
        {
            return _plugin.Schedule(() => SetTrafficLightsState(state));
        }

        public int GetTrafficLightsState()
        {
            return Rage.World.World_GetTrafficLightsState(_nativePointer);
        }

        public Task<int> GetTrafficLightsStateAsync()
        {
            return _plugin.Schedule(GetTrafficLightsState);
        }

        public void SetWeatherTransition(WeatherType weather, float time)
        {
            var weatherName = ConvertWeatherTypeToName(weather);

            Contract.NotEmpty(weatherName, nameof(weather));

            using (var converter = new StringConverter())
            {
                Rage.World.World_SetWeatherTransition(_nativePointer, converter.StringToPointer(weatherName), time);
            }
        }

        public Task SetWeatherTransitionAsync(WeatherType weather, float time)
        {
            return _plugin.Schedule(() => SetWeatherTransition(weather, time));
        }

        public void RequestIpl(string ipl)
        {
            Contract.NotEmpty(ipl, nameof(ipl));

            using (var converter = new StringConverter())
            {
                Rage.World.World_RequestIpl(_nativePointer, converter.StringToPointer(ipl));
            }
        }

        public Task RequestIplAsync(string ipl)
        {
            return _plugin.Schedule(() => RequestIpl(ipl));
        }

        public void RemoveIpl(string ipl)
        {
            Contract.NotEmpty(ipl, nameof(ipl));

            using (var converter = new StringConverter())
            {
                Rage.World.World_RemoveIpl(_nativePointer, converter.StringToPointer(ipl));
            }
        }

        public Task RemoveIplAsync(string ipl)
        {
            return _plugin.Schedule(() => RemoveIpl(ipl));
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
