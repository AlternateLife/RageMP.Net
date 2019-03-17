using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.EventArgs;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Example
{
    public class ExampleResource : IResource
    {
        public ExampleResource()
        {
            MP.Events.PlayerJoin += OnPlayerJoin;
            MP.Events.PlayerReady += OnPlayerReady;

            MP.Events.PlayerDeath += OnPlayerDeath;
            MP.Events.PlayerCommandFailed += OnPlayerCommandFailed;

            MP.Commands.RegisterHandler(new CommandHandler());
        }

        public Task OnStartAsync()
        {
            return Task.CompletedTask;
        }

        public Task OnStopAsync()
        {
            return Task.CompletedTask;
        }

        private async Task OnPlayerJoin(object sender, PlayerEventArgs eventArgs)
        {
            var player = eventArgs.Player;

            MP.Logger.Info($"Player {await player.GetSocialClubNameAsync()} ({await player.GetIpAsync()}) joined!");
        }

        private async Task OnPlayerReady(object sender, PlayerEventArgs eventArgs)
        {
            var player = eventArgs.Player;

            await player.SetDimensionAsync(MP.GlobalDimension);

            MP.Logger.Info($"Player {await player.GetSocialClubNameAsync()} ({await player.GetIpAsync()}) is ready now.");
        }

        private async Task OnPlayerDeath(object sender, PlayerDeathEventArgs eventArgs)
        {
            var player = eventArgs.Player;

            await player.SpawnAsync(await player.GetPositionAsync(), await player.GetHeadingAsync());
        }

        private Task OnPlayerCommandFailed(object sender, PlayerCommandFailedEventArgs eventArgs)
        {
            return eventArgs.Player.OutputChatBoxAsync(eventArgs.ErrorMessage);
        }
    }
}
