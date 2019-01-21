using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Attributes;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Example
{
    public class CommandHandler : ICommandHandler
    {
        [Command("vehicle")]
        public async Task Vehicle(IPlayer player, VehicleHash hash)
        {
            var vehicle = await MP.Vehicles.NewAsync(hash, player.Position);

            player.PutIntoVehicle(vehicle, -1);

            await player.OutputChatBoxAsync("Vehicle created");
        }

        [Command("weather")]
        public async Task Weather(IPlayer player, WeatherType weatherType)
        {
            MP.World.Weather = weatherType;
            await player.OutputChatBoxAsync("Weather changed");
        }

        [Command("weapon")]
        public async Task Weapon(IPlayer player, WeaponHash hash)
        {
            player.GiveWeapon(hash, 100);
            await player.OutputChatBoxAsync("Weapon received");
        }
    }
}
