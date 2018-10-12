using RageMP.Net.Interfaces;
using RageMP.Net.Scripting;

namespace RageMP.Net.Example
{
    public class ExampleResource : IResource
    {
        public void OnStart()
        {
            MP.Logger.Info($"{nameof(ExampleResource)}: {nameof(OnStart)}");

            MP.Events.PlayerChat += OnPlayerChat;
        }

        private void OnPlayerChat(IPlayer player, string text)
        {
            MP.Blips.New(102, player.Position, 1, 59, "TOMTE", 255, 100, true, 0, 0);
        }

        public void OnStop()
        {
            MP.Logger.Info($"{nameof(ExampleResource)}: {nameof(OnStop)}");
        }
    }
}
