using System;
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
            Console.WriteLine($"{nameof(OnPlayerChat)}: {player.Id}, {text}");
        }

        private void OnPlayerQuit(IPlayer player, uint type, string reason)
        {
            Console.WriteLine($"{nameof(OnPlayerQuit)}: {player.Id}, {type}, {reason}");
        }

        private void OnPlayerDamage(IPlayer player, float healthloss, float armorloss)
        {
            Console.WriteLine($"{nameof(OnPlayerDamage)}: {player.Id}, {healthloss}, {armorloss}");
        }

        private void OnPlayerDeath(IPlayer player, uint reason, IPlayer killerplayer)
        {
            Console.WriteLine($"{nameof(OnPlayerDeath)}: {player.Id}, {reason}, {killerplayer.Id}");
        }

        private void OnPlayerJoin(IPlayer player)
        {
            Console.WriteLine($"{nameof(OnPlayerJoin)}: {player.Id} {player.SocialClubName}");
        }

        private void OnPlayerReady(IPlayer player)
        {
            Console.WriteLine($"{nameof(OnPlayerReady)}: {player.Id}");
        }
    }
}
