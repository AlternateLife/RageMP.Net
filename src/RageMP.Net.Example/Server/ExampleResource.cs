using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using RageMP.Net.Data;
using RageMP.Net.Enums;
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
            MP.Events.PlayerChat += LongPlayerChat;
            MP.Events.PlayerChat += LongerPlayerChat;
            MP.Events.PlayerChat += NormalPlayerChat;
            MP.Events.PlayerChat += FailingPlayerchat;

            MP.Events.PlayerDeath += OnPlayerDeath;
            MP.Events.PlayerCommand += OnPlayerCommand;
        }

        private async Task LongerPlayerChat(IPlayer player, string text)
        {
            MP.Logger.Info($"Start {nameof(LongerPlayerChat)} - {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(TimeSpan.FromSeconds(10));

            MP.Logger.Info($"End {nameof(LongerPlayerChat)} - {Thread.CurrentThread.ManagedThreadId}");
        }

        private async Task LongPlayerChat(IPlayer player, string text)
        {
            MP.Logger.Info($"Start {nameof(LongPlayerChat)} - {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(TimeSpan.FromSeconds(5));

            MP.Logger.Info($"End {nameof(LongPlayerChat)} - {Thread.CurrentThread.ManagedThreadId}");
        }

        private async Task NormalPlayerChat(IPlayer player, string text)
        {
            MP.Logger.Info($"Start {nameof(NormalPlayerChat)} - {Thread.CurrentThread.ManagedThreadId}");

            await player.OutputChatBoxAsync("TEST");

            MP.Logger.Info($"End {nameof(NormalPlayerChat)} - {Thread.CurrentThread.ManagedThreadId}");
        }

        private async Task FailingPlayerchat(IPlayer player, string text)
        {
            MP.Logger.Info($"Start {nameof(FailingPlayerchat)} - {Thread.CurrentThread.ManagedThreadId}");

            throw new Exception("FAILED!");

            MP.Logger.Info($"End {nameof(FailingPlayerchat)} - {Thread.CurrentThread.ManagedThreadId}");
        }

        private async Task OnPlayerCommand(IPlayer player, string text)
        {
            if (text == "v")
            {
                var vehicle = await MP.Vehicles.NewAsync(VehicleHash.T20, player.Position, 0, "", 255, false, true);

                player.PutIntoVehicle(vehicle, -1);

                return;
            }

            if (text == "e")
            {
                throw new Exception("TEST");

                return;
            }

            if (text == "g")
            {
                var vehicle = player.Vehicle;
                if (vehicle == null)
                {
                    player.OutputChatBoxAsync("Vehicle not found");

                    return;
                }

                var occupant = vehicle.GetOccupant(-1);
                if (occupant == null)
                {
                    player.OutputChatBoxAsync("Occupant not found");

                    return;
                }

                player.OutputChatBoxAsync($"Occupant {occupant.SocialClubName} found");

                return;
            }

            if (text == "o")
            {
                var vehicle = player.Vehicle;
                if (vehicle == null)
                {
                    player.OutputChatBoxAsync("Vehicle not found");

                    return;
                }

                foreach (var occupant in vehicle.Occupants)
                {
                    MP.Logger.Info($"Occupant: {occupant.SocialClubName}");
                }

                return;
            }

            if (text == "d")
            {
                MP.Logger.Debug($"HasData: {player.HasSharedData("TEST")}");

                player.SetSharedData("TEST", 12345);

                player.SetSharedData(new Dictionary<string, object>
                {
                    { "KEY1", 123.45 },
                    { "KEY2", player },
                    { "KEY3", player.Position },
                    { "KEY4", "LEL" },
                });

                return;
            }

            if (text == "r")
            {
                player.ResetSharedData("TEST");

                return;
            }

            if (text == "w")
            {
                foreach (var weapon in player.Weapons)
                {
                    MP.Logger.Debug($"Weapon: {weapon.Key} -> {weapon.Value}");
                }

                player.GiveWeapons(new Dictionary<uint, uint>
                {
                    { 0xD8DF3C3C, 20 },
                    { 0x5EF9FEC4, 123 },
                    { 0xE284C527, 500 }
                });

                return;
            }

            if (text == "c")
            {
                player.SetCustomization(false, new HeadBlendData(10, 34, 0, 42, 23, 0, 0.8f, 0.7f, 0.1f), 2, 3, 4, new float[0], new Dictionary<int, HeadOverlayData>(), new Dictionary<uint, uint>());

                return;
            }

            if (text == "l")
            {
                player.OutputChatBoxAsync("TRAFFIC: " + MP.World.TrafficLightsState);
            }

            if (text == "m")
            {
                MP.Logger.Info("Create vehicles");

                player.Dimension = MP.GlobalDimension;

                var stopWatch = new Stopwatch();
                stopWatch.Start();

                for (int j = 0; j < 10; j++)
                {
                    Task.Run(() =>
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            MP.Markers.NewAsync(2, player.Position, player.Rotation, Vector3.One, 1, new ColorRgba(255, 0, 0, 255), true);
                        }
                    });

                    Task.Run(() =>
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            MP.Markers.NewAsync(2, player.Position, player.Rotation, Vector3.One, 1, new ColorRgba(255, 0, 0, 255), true);
                        }
                    });

                    Task.Run(() =>
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            MP.Markers.NewAsync(2, player.Position, player.Rotation, Vector3.One, 1, new ColorRgba(255, 0, 0, 255), true);
                        }
                    });
                }

                stopWatch.Stop();

                MP.Logger.Info("Elapsed Time: " + stopWatch.ElapsedMilliseconds);
            }
        }

        private Task OnPlayerDeath(IPlayer player, uint reason, IPlayer killerplayer)
        {
            player.Spawn(player.Position, player.Heading);

            return Task.CompletedTask;
        }

        private Task OnPlayerChat(IPlayer player, string text)
        {
            MP.Markers.NewAsync(0, player.Position, Vector3.Zero, Vector3.UnitZ, 1, new ColorRgba(255, 255, 0, 255), true, 0);

            MP.Objects.NewAsync(212137959, player.Position, Vector3.One, 0);

            MP.TextLabels.NewAsync(player.Position, "HÖHÖ, höhö", 0, new ColorRgba(255, 255, 0, 255), 20, true, 0);

            return Task.CompletedTask;
        }

        public void OnStop()
        {
            MP.Logger.Info($"{nameof(ExampleResource)}: {nameof(OnStop)}");
        }
    }
}
