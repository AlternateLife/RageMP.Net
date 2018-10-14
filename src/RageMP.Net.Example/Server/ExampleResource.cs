using System.Numerics;
using RageMP.Net.Data;
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
            MP.Checkpoints.New(0, player.Position + Vector3.UnitY * 3, player.Position + Vector3.UnitY * 20, 5, new ColorRgba(0, 0, 255, 255), true, 0);

            MP.Markers.New(0, player.Position, Vector3.Zero, Vector3.UnitZ, 1, new ColorRgba(255, 255, 0, 255), true, 0);
        }

        public void OnStop()
        {
            MP.Logger.Info($"{nameof(ExampleResource)}: {nameof(OnStop)}");
        }
    }
}
