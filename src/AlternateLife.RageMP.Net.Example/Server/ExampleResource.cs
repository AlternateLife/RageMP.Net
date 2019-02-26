using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
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

        private Task OnPlayerCommandFailed(IPlayer player, string input, CommandError error, string errormessage)
        {
            return player.OutputChatBoxAsync(errormessage);
        }

        public Task OnStartAsync()
        {
            return Task.CompletedTask;
        }

        public Task OnStopAsync()
        {
            return Task.CompletedTask;
        }

        private Task OnPlayerJoin(IPlayer player)
        {
            MP.Logger.Info($"Player {player.SocialClubName} ({player.Ip}) joined!");

            return Task.CompletedTask;
        }

        private Task OnPlayerReady(IPlayer player)
        {
            player.Dimension = MP.GlobalDimension;

            MP.Logger.Info($"Player {player.SocialClubName} ({player.Ip}) is ready now.");

            return Task.CompletedTask;
        }

        private Task OnPlayerDeath(IPlayer player, uint reason, IPlayer killerplayer)
        {
            player.Spawn(player.Position, player.Heading);

            return Task.CompletedTask;
        }
    }
}
