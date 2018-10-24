using System;
using System.Threading.Tasks;

namespace AlternateLife.RageMP.Net
{
    internal static class PluginWrapper
    {
        public static void Main(IntPtr multiplayer)
        {
            var plugin = new Plugin(multiplayer);

            plugin.Logger.Info($"Starting Rage.NET Version {typeof(Plugin).Assembly.GetName().Version}...");

            plugin.Prepare();

            Task.Run(() => plugin.Start());

            plugin.Logger.Info("Rage.NET startup finished");
        }
    }
}
