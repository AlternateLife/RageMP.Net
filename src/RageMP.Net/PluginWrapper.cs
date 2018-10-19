using System;

namespace AlternateLife.RageMP.Net
{
    internal static class PluginWrapper
    {
        public static void Main(IntPtr multiplayer)
        {
            var plugin = new Plugin(multiplayer);
        }
    }
}
