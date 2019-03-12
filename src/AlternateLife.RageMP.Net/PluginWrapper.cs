using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly:RuntimeCompatibility(WrapNonExceptionThrows = true)]

namespace AlternateLife.RageMP.Net
{
    internal static class PluginWrapper
    {
        public static void Main()
        {
        }

        public static void PluginMain(IntPtr multiplayer)
        {
            var plugin = new Plugin(multiplayer);

            plugin.Logger.Info($"Starting Rage.NET Version {typeof(Plugin).Assembly.GetName().Version}...");

            plugin.Prepare();

            Task.Run(async () =>
            {
                await plugin.Start();

                plugin.Logger.Info("Rage.NET startup finished");
            });
        }
    }
}
