using System.Collections.Generic;
using System.Text;
using RageMP.Net.Enums;
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

        public static IList<uint> Joaat(IList<string> input)
        {
            var result = new uint[input.Count];

            for (var i = 0; i < input.Count; i++)
            {
                result[i] = Joaat(input[i]);
            }

            return result;
        }

    }
}
