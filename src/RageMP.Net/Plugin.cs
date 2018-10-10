using System;
using System.Numerics;
using RageMP.Net.Interfaces;
using RageMP.Net.Scripting;

namespace RageMP.Net
{
    internal class Plugin
    {
        public Plugin()
        {
            MP.Events.PlayerJoin += OnPlayerJoin;
            MP.Events.PlayerReady += OnPlayerReady;
            MP.Events.PlayerChat += OnPlayerChat;
            MP.Events.PlayerDeath += OnPlayerDeath;
            MP.Events.PlayerDamage += OnPlayerDamage;
            MP.Events.PlayerQuit += OnPlayerQuit;
        }

        private void OnPlayerChat(IPlayer player, string text)
        {
            Console.WriteLine($"{nameof(OnPlayerChat)}: {player.Name}, {text}");
        }

        private void OnPlayerQuit(IPlayer player, uint type, string reason)
        {
            Console.WriteLine($"{nameof(OnPlayerQuit)}: {player.Name}, {type}, {reason}");
        }

        private void OnPlayerDamage(IPlayer player, float healthloss, float armorloss)
        {
            Console.WriteLine($"{nameof(OnPlayerDamage)}: {player.Name}, {healthloss}, {armorloss}");
        }

        private void OnPlayerDeath(IPlayer player, uint reason, IPlayer killerplayer)
        {
            Console.WriteLine($"{nameof(OnPlayerDeath)}: {player.Name}, {reason}, {killerplayer.Id}");
        }

        private void OnPlayerJoin(IPlayer player)
        {
            Console.WriteLine($"{nameof(OnPlayerJoin)}: {player.Name} {player.SocialClubName}");
        }

        private void OnPlayerReady(IPlayer player)
        {
            Console.WriteLine($"{nameof(OnPlayerReady)}: {player.Name}");
        }
    }
}
