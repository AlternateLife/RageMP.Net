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
        public async Task Vehicle(IPlayer player, VehicleHash vehicleName)
        {
            var vehicle = await MP.Vehicles.NewAsync(vehicleName, player.Position);

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
        public async Task Weapon(IPlayer player, WeaponHash weaponName)
        {
            player.GiveWeapon(weaponName, 100);
            await player.OutputChatBoxAsync("Weapon received");
        }

        [Command("skin")]
        public async Task PrintArguments(IPlayer player, string[] arguments)
        {
            if (arguments.Length <= 0)
            {
                return;
            }

            if (Enum.TryParse(arguments[0], out PedHash result) == false)
            {
                await player.OutputChatBoxAsync("The given model is not valid!");

                return;
            }

            player.Model = result;

            await player.OutputChatBoxAsync($"Skin changed to \"{result}\"!");
        }
    }
}
