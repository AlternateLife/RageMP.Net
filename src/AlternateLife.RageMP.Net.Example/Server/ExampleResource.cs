using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Example
{
    public class ExampleResource : IResource
    {
        public async Task OnStartAsync()
        {
            MP.Logger.Info($"{nameof(ExampleResource)}: {nameof(OnStartAsync)}");

            MP.Events.PlayerChat += OnPlayerChat;
            MP.Events.PlayerJoin += OnPlayerJoin;
            MP.Events.PlayerReady += OnPlayerReady;

            MP.Events.PlayerDeath += OnPlayerDeath;

            var vehicle = await MP.Vehicles.NewAsync(VehicleHash.T20, Vector3.One);

            vehicle.SetColorRgb(new ColorRgba(255, 0, 255), new ColorRgba(0, 125, 25));

            MP.Commands.RegisterHandler(new CommandHandler());
        }

        private Task OnPlayerJoin(IPlayer player)
        {
            MP.Logger.Info($"Player {player.SocialClubName} ({player.Ip}) joined");

            return Task.CompletedTask;
        }

        private Task OnPlayerReady(IPlayer player)
        {
            player.Dimension = MP.GlobalDimension;

            return Task.CompletedTask;
        }

        public Task OnStopAsync()
        {
            MP.Logger.Info($"{nameof(ExampleResource)}: {nameof(OnStopAsync)}");

            return Task.CompletedTask;
        }

        private Task OnPlayerDeath(IPlayer player, uint reason, IPlayer killerplayer)
        {
            player.Spawn(player.Position, player.Heading);

            return Task.CompletedTask;
        }

        private Task OnPlayerChat(IPlayer player, string text)
        {
            MP.Markers.NewAsync(MarkerType.PlaneModel, player.Position, Vector3.Zero, Vector3.UnitZ, 1, new ColorRgba(255, 255, 0), true);

            MP.Objects.NewAsync(MP.Joaat("prop_coffin_01"), player.Position, Vector3.One);

            MP.TextLabels.NewAsync(player.Position, "HÖHÖ, höhö", 0, new ColorRgba(255, 255, 0), 20, true);

            return Task.CompletedTask;
        }
    }
}
