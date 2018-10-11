using System;
using System.Numerics;
using RageMP.Net.Data;
using RageMP.Net.Interfaces;
using RageMP.Net.Scripting;

namespace RageMP.Net
{
    internal class Plugin
    {
        internal IntPtr NativeMultiplayer { get; }

        public Plugin(IntPtr multiplayer)
        {
            NativeMultiplayer = multiplayer;

            MP.Setup(this);

            MP.Events.PlayerJoin += OnPlayerJoin;
            MP.Events.PlayerReady += OnPlayerReady;
            MP.Events.PlayerChat += OnPlayerChat;
            MP.Events.PlayerDeath += OnPlayerDeath;
            MP.Events.PlayerDamage += OnPlayerDamage;
            MP.Events.PlayerQuit += OnPlayerQuit;
        }

        private void OnPlayerChat(IPlayer player, string text)
        {
            Console.WriteLine($"{nameof(OnPlayerChat)}: {player.Name}, {text}, {player.Position}");

            player.GiveWeapon(0x97EA20B8, 100);

            player.Call("TEST", "cello", 1, 1.2, new Vector3(-1388.594f, -586.711f, 30.219f));
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
