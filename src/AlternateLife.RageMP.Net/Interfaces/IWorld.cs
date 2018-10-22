using System;
using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IWorld
    {
        /// <summary>
        /// Get or set the time of the world.
        /// </summary>
        TimeData Time { get; set; }

        /// <summary>
        /// Get or set the weather of the world.
        /// </summary>
        string Weather { get; set; }

        /// <summary>
        /// Get or set the traffic lights lock state of the world.
        /// </summary>
        bool AreTrafficLightsLocked { get; set; }

        /// <summary>
        /// Get or set the traffic light state of the world.
        /// </summary>
        int TrafficLightsState { get; set; }

        /// <summary>
        /// Start a weather transition on the world.
        /// </summary>
        /// <param name="weather">New weather to transit to </param>
        /// <param name="time">Duration of the transition</param>
        /// <exception cref="ArgumentNullException"><paramref name="weather" /> is null or empty</exception>
        void SetWeatherTransition(string weather, float time = 0.5f);

        /// <summary>
        /// Request an ipl in the world.
        /// </summary>
        /// <param name="ipl">Name of the ipl to load</param>
        /// <exception cref="ArgumentNullException"><paramref name="ipl" /> is null or empty</exception>
        void RequestIpl(string ipl);

        /// <summary>
        /// Remove an ipl from the world.
        /// </summary>
        /// <param name="ipl">Name of the ipl to unload</param>
        /// <exception cref="ArgumentNullException"><paramref name="ipl" /> is null or empty</exception>
        void RemoveIpl(string ipl);
    }
}
