using System;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IWorld
    {
        /// <summary>
        /// Set the time of the world.
        /// </summary>
        /// <param name="time">New time to set the world to</param>
        void SetTime(TimeData time);

        /// <summary>
        /// Set the time of the world.
        /// </summary>
        /// <param name="time">New time to set the world to</param>
        Task SetTimeAsync(TimeData time);

        /// <summary>
        /// Get the time of the world.
        /// </summary>
        /// <returns>Current time of the world</returns>
        TimeData GetTime();

        /// <summary>
        /// Get the time of the world.
        /// </summary>
        /// <returns>Current time of the world</returns>
        Task<TimeData> GetTimeAsync();

        /// <summary>
        /// Set the weather of the world.
        ///
        /// If value is set to WeatherType.XMAS, snow will lay on the ground.
        /// </summary>
        /// <param name="type">New weather of the world</param>
        void SetWeather(WeatherType type);

        /// <summary>
        /// Set the weather of the world.
        ///
        /// If value is set to WeatherType.XMAS, snow will lay on the ground.
        /// </summary>
        /// <param name="type">New weather of the world</param>
        Task SetWeatherAsync(WeatherType type);

        /// <summary>
        /// Get the weather of the world.
        ///
        /// If value is set to WeatherType.XMAS, snow will lay on the ground.
        /// </summary>
        /// <returns>The current weather of the world</returns>
        WeatherType GetWeather();

        /// <summary>
        /// Get the weather of the world.
        ///
        /// If value is set to WeatherType.XMAS, snow will lay on the ground.
        /// </summary>
        /// <returns>The current weather of the world</returns>
        Task<WeatherType> GetWeatherAsync();

        /// <summary>
        /// Set the traffic lights lock state of the world.
        /// </summary>
        /// <param name="locked">true if traffic lights should keep the current status</param>
        void SetTrafficLightsLocked(bool locked);

        /// <summary>
        /// Set the traffic lights lock state of the world.
        /// </summary>
        /// <param name="locked">true if traffic lights should keep the current status</param>
        Task SetTrafficLightsLockedAsync(bool locked);

        /// <summary>
        /// Get the traffic lights lock state of the world.
        /// </summary>
        /// <returns>true if the traffic lights are frozen, false otherwise</returns>
        bool AreTrafficLightsLocked();

        /// <summary>
        /// Get the traffic lights lock state of the world.
        /// </summary>
        /// <returns>true if the traffic lights are frozen, false otherwise</returns>
        Task<bool> AreTrafficLightsLockedAsync();

        /// <summary>
        /// Set the traffic light state of the world.
        /// </summary>
        /// <param name="state">State of all traffic lights</param>
        void SetTrafficLightsState(int state);

        /// <summary>
        /// Set the traffic light state of the world.
        /// </summary>
        /// <param name="state">State of all traffic lights</param>
        Task SetTrafficLightsStateAsync(int state);

        /// <summary>
        /// Get the traffic light state of the world.
        /// </summary>
        /// <returns>Current state of all traffic lights</returns>
        int GetTrafficLightsState();

        /// <summary>
        /// Get the traffic light state of the world.
        /// </summary>
        /// <returns>Current state of all traffic lights</returns>
        Task<int> GetTrafficLightsStateAsync();

        /// <summary>
        /// Start a weather transition on the world.
        /// </summary>
        /// <param name="weather">New weather to transit to</param>
        /// <param name="time">Duration of the transition</param>
        void SetWeatherTransition(WeatherType weather, float time = 0.5f);

        /// <summary>
        /// Start a weather transition on the world.
        /// </summary>
        /// <param name="weather">New weather to transit to</param>
        /// <param name="time">Duration of the transition</param>
        Task SetWeatherTransitionAsync(WeatherType weather, float time = 0.5f);

        /// <summary>
        /// Request an ipl in the world.
        /// </summary>
        /// <param name="ipl">Name of the ipl to load</param>
        /// <exception cref="ArgumentNullException"><paramref name="ipl" /> is null or empty</exception>
        void RequestIpl(string ipl);

        /// <summary>
        /// Request an ipl in the world.
        /// </summary>
        /// <param name="ipl">Name of the ipl to load</param>
        /// <exception cref="ArgumentNullException"><paramref name="ipl" /> is null or empty</exception>
        Task RequestIplAsync(string ipl);

        /// <summary>
        /// Remove an ipl from the world.
        /// </summary>
        /// <param name="ipl">Name of the ipl to unload</param>
        /// <exception cref="ArgumentNullException"><paramref name="ipl" /> is null or empty</exception>
        void RemoveIpl(string ipl);

        /// <summary>
        /// Remove an ipl from the world.
        /// </summary>
        /// <param name="ipl">Name of the ipl to unload</param>
        /// <exception cref="ArgumentNullException"><paramref name="ipl" /> is null or empty</exception>
        Task RemoveIplAsync(string ipl);
    }
}
