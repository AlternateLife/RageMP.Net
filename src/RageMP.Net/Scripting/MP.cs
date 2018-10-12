using RageMP.Net.Interfaces;
using RageMP.Net.Native;
using RageMP.Net.Scripting.ScriptingClasses;

namespace RageMP.Net.Scripting
{
    public static class MP
    {
        private static Plugin _plugin;

        internal static EventScripting InternalEvents { get; private set; }
        internal static VehiclePool InternalVehicles => _plugin.VehiclePool;
        internal static PlayerPool InternalPlayers => _plugin.PlayerPool;
        internal static BlipPool InternalBlips => _plugin.BlipPool;

        public static IEventScripting Events => InternalEvents;
        public static IVehiclePool Vehicles => InternalVehicles;
        public static IPlayerPool Players => InternalPlayers;
        public static IBlipPool Blips => InternalBlips;

        public static ILogger Logger => _plugin.Logger;

        internal static void Setup(Plugin plugin)
        {
            _plugin = plugin;

            InternalEvents = new EventScripting(_plugin);
        }

    }
}
