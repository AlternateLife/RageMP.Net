using RageMP.Net.Interfaces;
using RageMP.Net.Scripting.ScriptingClasses;

namespace RageMP.Net.Scripting
{
    public static class MP
    {
        private static Plugin _plugin;

        public static IEventScripting Events { get; private set; }

        internal static void Setup(Plugin plugin)
        {
            _plugin = plugin;

            Events = new EventScripting();
        }

    }
}
