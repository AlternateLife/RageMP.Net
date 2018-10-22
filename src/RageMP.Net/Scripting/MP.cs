using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RageMP.Net.Elements.Pools;
using RageMP.Net.Enums;
using RageMP.Net.Helpers;
using RageMP.Net.Interfaces;
using RageMP.Net.Scripting.ScriptingClasses;

namespace RageMP.Net.Scripting
{
    public static class MP
    {
        public const uint GlobalDimension = uint.MaxValue;

        private static Plugin _plugin;

        internal static EventScripting InternalEvents => _plugin.EventScripting;

        internal static VehiclePool InternalVehicles => _plugin.VehiclePool;
        internal static PlayerPool InternalPlayers => _plugin.PlayerPool;
        internal static BlipPool InternalBlips => _plugin.BlipPool;
        internal static CheckpointPool InternalCheckpoints => _plugin.CheckpointPool;
        internal static ColshapePool InternalColshapes => _plugin.ColshapePool;
        internal static MarkerPool InternalMarkers => _plugin.MarkerPool;
        internal static ObjectPool InternalObjects => _plugin.ObjectPool;
        internal static TextLabelPool InternalTextLabels => _plugin.TextLabelPool;
        internal static Config InternalConfig => _plugin.Config;
        internal static World InternalWorld => _plugin.World;

        internal static IReadOnlyDictionary<EntityType, IInternalPool> EntityPoolMapping => _plugin.EntityPoolMapping;

        public static IEventScripting Events => InternalEvents;
        public static IVehiclePool Vehicles => InternalVehicles;
        public static IPlayerPool Players => InternalPlayers;
        public static IBlipPool Blips => InternalBlips;
        public static ICheckpointPool Checkpoints => InternalCheckpoints;
        public static IColshapePool Colshapes => InternalColshapes;
        public static IMarkerPool Markers => InternalMarkers;
        public static IObjectPool Objects => InternalObjects;
        public static ITextLabelPool TextLabels => InternalTextLabels;
        public static IConfig Config => InternalConfig;
        public static IWorld World => InternalWorld;

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
            if (string.IsNullOrEmpty(data))
            {
                return 0;
            }

            var characters = Encoding.UTF8.GetBytes(data.ToLower());

            uint hash = 0;

            foreach (var t in characters)
            {
                hash += t;
                hash += hash << 10;
                hash ^= hash >> 6;
            }

            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;

            return hash;
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
            Contract.NotNull(input, nameof(input));

            var result = new uint[input.Count];

            for (var i = 0; i < input.Count; i++)
            {
                result[i] = Joaat(input[i]);
            }

            return result;
        }

        /// <summary>
        /// Schedules given <see cref="Action"/> in RageMP's main thread.
        ///
        /// WARNING: Avoid long procedures, because this could harm general event performance.
        /// </summary>
        /// <param name="action"><paramref name="action"/> to schedule</param>
        public static Task Schedule(Action action)
        {
            return _plugin.Schedule(action);
        }

        /// <summary>
        /// Schedules given <see cref="Func{TResult}"/> in RageMP's main thread.
        ///
        /// WARNING: Avoid long procedures, because this could harm general event performance.
        /// </summary>
        /// <param name="action"><paramref name="action"/> to schedule</param>
        public static Task<T> Schedule<T>(Func<T> action)
        {
            return _plugin.Schedule(action);
        }

    }
}
