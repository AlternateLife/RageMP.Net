using RageMP.Net.Interfaces;
using RageMP.Net.Scripting;

namespace RageMP.Net.Example
{
    public class ExampleResource : IResource
    {
        private uint _lastBlip = 100;

        public void OnStart()
        {
            MP.Logger.Info($"{nameof(ExampleResource)}: {nameof(OnStart)}");

            MP.Events.PlayerChat += OnPlayerChat;
        }

        private void OnPlayerChat(IPlayer player, string text)
        {
            MP.Blips.New(++_lastBlip, player.Position, 1, 59, text, 255, 100, true, 0, 0);
        }

        public void OnStop()
        {
            MP.Logger.Info($"{nameof(ExampleResource)}: {nameof(OnStop)}");
        }
    }
}
