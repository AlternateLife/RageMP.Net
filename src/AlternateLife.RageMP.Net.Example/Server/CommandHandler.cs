using System;
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
        public async Task Vehicle(IPlayer player, string[] arguments)
        {
            var vehicle = await MP.Vehicles.NewAsync(VehicleHash.Elegy, player.Position);

            player.PutIntoVehicle(vehicle, -1);

            await player.OutputChatBoxAsync("Vehicle created");
        }

        [Command("weather")]
        public async Task Weather(IPlayer player, string[] arguments)
        {
            var weatherType = arguments[0];

            if (Enum.TryParse(weatherType, true, out WeatherType type) == false)
            {
                await player.OutputChatBoxAsync($"Weather {weatherType} is invalid!");

                return;
            }

            MP.World.Weather = type;
        }

        [Command("weapon")]
        public async Task Weapon(IPlayer player, string[] arguments)
        {
            var weaponName = arguments[0];

            if (Enum.TryParse(weaponName, true, out WeaponHash hash) == false)
            {
                await player.OutputChatBoxAsync($"Weapon {weaponName} is invalid!");

                return;
            }

            player.GiveWeapon(hash, 100);
        }
    }
}
