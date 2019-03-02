using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IUtility
    {
        /// <summary>
        /// Converts given string to the equivalent Jenkins-One-At-A-Time value.
        ///
        /// https://en.wikipedia.org/wiki/Jenkins_hash_function#one_at_a_time
        /// </summary>
        /// <param name="data">text to convert</param>
        /// <returns>Integer that represents given string data</returns>
        uint Joaat(string data);

        /// <summary>
        /// Converts given collection of strings to Jenkins-One-At-A-Time values.
        ///
        /// https://en.wikipedia.org/wiki/Jenkins_hash_function#one_at_a_time
        /// </summary>
        /// <param name="input">texts to convert</param>
        /// <returns>Collection of converted values</returns>
        IList<uint> Joaat(IList<string> input);

        /// <summary>
        /// Schedules given <see cref="Action"/> in RageMP's main thread.
        ///
        /// WARNING: Avoid long procedures, because this could harm general event performance.
        /// </summary>
        /// <param name="action"><paramref name="action"/> to schedule</param>
        /// <param name="forceSchedule">If true, main thread check will be ignored and action will be scheduled</param>
        Task Schedule(Action action, bool forceSchedule = false);

        /// <summary>
        /// Schedules given <see cref="Func{TResult}"/> in RageMP's main thread.
        ///
        /// WARNING: Avoid long procedures, because this could harm general event performance.
        /// </summary>
        /// <param name="action"><paramref name="action"/> to schedule</param>
        /// <param name="forceSchedule">If true, main thread check will be ignored and action will be scheduled</param>
        Task<T> Schedule<T>(Func<T> action, bool forceSchedule = false);
    }
}
