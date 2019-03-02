using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting
{
    public static class MP
    {
        public const uint GlobalDimension = uint.MaxValue;

        private static Plugin _plugin;

        public static IEventScripting Events => _plugin.EventScripting;
        public static IVehiclePool Vehicles => _plugin.VehiclePool;
        public static IPlayerPool Players => _plugin.PlayerPool;
        public static IBlipPool Blips => _plugin.BlipPool;
        public static ICheckpointPool Checkpoints => _plugin.CheckpointPool;
        public static IColshapePool Colshapes => _plugin.ColshapePool;
        public static IMarkerPool Markers => _plugin.MarkerPool;
        public static IObjectPool Objects => _plugin.ObjectPool;
        public static ITextLabelPool TextLabels => _plugin.TextLabelPool;
        public static IConfig Config => _plugin.Config;
        public static IWorld World => _plugin.World;
        public static ICommands Commands => _plugin.Commands;
        public static IUtility Utility => _plugin.Utility;

        public static ILogger Logger => _plugin.Logger;

        internal static void Setup(Plugin plugin)
        {
            _plugin = plugin;
        }

        /// <summary>
        /// Converts given string to the equivalent Jenkins-One-At-A-Time value.
        ///
        /// https://en.wikipedia.org/wiki/Jenkins_hash_function#one_at_a_time
        /// </summary>
        /// <param name="data">text to convert</param>
        /// <returns>Integer that represents given string data</returns>
        public static uint Joaat(string data)
        {
            return _plugin.Utility.Joaat(data);
        }

        /// <summary>
        /// Converts given collection of strings to Jenkins-One-At-A-Time values.
        ///
        /// https://en.wikipedia.org/wiki/Jenkins_hash_function#one_at_a_time
        /// </summary>
        /// <param name="input">texts to convert</param>
        /// <returns>Collection of converted values</returns>
        public static IList<uint> Joaat(IList<string> input)
        {
            return _plugin.Utility.Joaat(input);
        }

        /// <summary>
        /// Schedules given <see cref="Action"/> in RageMP's main thread.
        ///
        /// WARNING: Avoid long procedures, because this could harm general event performance.
        /// </summary>
        /// <param name="action"><paramref name="action"/> to schedule</param>
        /// <param name="forceSchedule">If true, main thread check will be ignored and action will be scheduled</param>
        public static Task Schedule(Action action, bool forceSchedule = false)
        {
            return _plugin.Utility.Schedule(action, forceSchedule);
        }

        /// <summary>
        /// Schedules given <see cref="Func{TResult}"/> in RageMP's main thread.
        ///
        /// WARNING: Avoid long procedures, because this could harm general event performance.
        /// </summary>
        /// <param name="action"><paramref name="action"/> to schedule</param>
        /// <param name="forceSchedule">If true, main thread check will be ignored and action will be scheduled</param>
        public static Task<T> Schedule<T>(Func<T> action, bool forceSchedule = false)
        {
            return _plugin.Utility.Schedule(action, forceSchedule);
        }

    }
}
