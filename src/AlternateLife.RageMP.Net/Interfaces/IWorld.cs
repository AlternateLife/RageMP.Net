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
        Task SetTimeAsync(TimeData time);

        /// <summary>
        /// Get the time of the world.
        /// </summary>
        Task<TimeData> GetTimeAsync();

        /// <summary>
        /// Set the weather of the world.
        ///
        /// If value is set to WeatherType.XMAS, snow will lay on the ground.
        /// </summary>
        Task SetWeatherAsync(WeatherType type);

        /// <summary>
        /// Get the weather of the world.
        ///
        /// If value is set to WeatherType.XMAS, snow will lay on the ground.
        /// </summary>
        Task<WeatherType> GetWeatherAsync();

        /// <summary>
        /// Set the traffic lights lock state of the world.
        /// </summary>
        Task SetTrafficLightsLockedAsync(bool locked);

        /// <summary>
        /// Get the traffic lights lock state of the world.
        /// </summary>
        Task<bool> AreTrafficLightsLockedAsync();

        /// <summary>
        /// Set the traffic light state of the world.
        /// </summary>
        Task SetTrafficLightsStateAsync(int state);

        /// <summary>
        /// Get the traffic light state of the world.
        /// </summary>
        Task<int> GetTrafficLightsStateAsync();

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
        Task RequestIplAsync(string ipl);

        /// <summary>
        /// Remove an ipl from the world.
        /// </summary>
        /// <param name="ipl">Name of the ipl to unload</param>
        /// <exception cref="ArgumentNullException"><paramref name="ipl" /> is null or empty</exception>
        Task RemoveIplAsync(string ipl);
    }
}
