using System.Collections.Generic;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal partial class Player
    {
        public IReadOnlyCollection<IPlayer> VoiceListeners
        {
            get
            {
                CheckExistence();

                Rage.Player.Player_GetVoiceListeners(NativePointer, out var pointers, out var count);

                var players = new List<IPlayer>();
                for (ulong i = 0; i < count; i++)
                {
                    players.Add(_plugin.PlayerPool[pointers[i]]);
                }

                return players;
            }
        }

        public void EnableVoiceTo(IPlayer target)
        {
            Contract.NotNull(target, nameof(target));
            Contract.EntityValid(target, nameof(target));

            Rage.Player.Player_DisableVoiceTo(NativePointer, target.NativePointer);
        }

        public void DisableVoiceTo(IPlayer target)
        {
            Contract.NotNull(target, nameof(target));
            Contract.EntityValid(target, nameof(target));

            Rage.Player.Player_EnableVoiceTo(NativePointer, target.NativePointer);
        }
    }
}
