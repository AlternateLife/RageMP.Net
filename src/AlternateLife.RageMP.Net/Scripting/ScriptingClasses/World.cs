using System;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Data;
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
            set => Rage.World.World_SetTime(_nativePointer, value);
        }

        public string Weather
        {
            get => StringConverter.PointerToString(Rage.World.World_GetWeather(_nativePointer));
            set
            {
                using (var converter = new StringConverter())
                {
                    Rage.World.World_SetWeather(_nativePointer, converter.StringToPointer(value));
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

        internal World(IntPtr nativePointer, Plugin plugin)
        {
            _nativePointer = nativePointer;
            _plugin = plugin;
        }

        public void SetWeatherTransition(string weather, float time)
        {
            Contract.NotEmpty(weather, nameof(weather));

            using (var converter = new StringConverter())
            {
                Rage.World.World_SetWeatherTransition(_nativePointer, converter.StringToPointer(weather), time);
            }
        }

        public void RequestIpl(string ipl)
        {
            Contract.NotEmpty(ipl, nameof(ipl));

            using (var converter = new StringConverter())
            {
                Rage.World.World_RequestIpl(_nativePointer, converter.StringToPointer(ipl));
            }
        }

        public void RemoveIpl(string ipl)
        {
            Contract.NotEmpty(ipl, nameof(ipl));

            using (var converter = new StringConverter())
            {
                Rage.World.World_RemoveIpl(_nativePointer, converter.StringToPointer(ipl));
            }
        }
    }
}
