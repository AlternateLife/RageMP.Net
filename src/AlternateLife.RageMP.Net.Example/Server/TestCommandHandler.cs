using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Attributes;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Example
{
    public class TestCommandHandler : ICommandHandler
    {
        [Command("vehicle")]
        public async Task Vehicle(IPlayer player, string[] arguments)
        {
            var vehicle = await MP.Vehicles.NewAsync(VehicleHash.Elegy, player.Position);

            player.PutIntoVehicle(vehicle, -1);

            await player.OutputChatBoxAsync("Vehicle created");
        }

        [Command("kill")]
        public void Kill(IPlayer player, string[] arguments)
        {

        }
    }
}
