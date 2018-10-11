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

        public static IEventScripting Events => InternalEvents;
        public static IVehiclePool Vehicles => InternalVehicles;
        public static IPlayerPool Players => InternalPlayers;

        internal static void Setup(Plugin plugin)
        {
            _plugin = plugin;

            InternalEvents = new EventScripting(_plugin);
        }

    }
}
