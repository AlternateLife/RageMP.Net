using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal partial class Player
    {
        public async Task<IReadOnlyCollection<IPlayer>> GetVoiceListenersAsync()
        {
            CheckExistence();

            var pointers = new IntPtr[0];
            ulong count = 0;

            await _plugin
                .Schedule(() => Rage.Player.Player_GetVoiceListeners(NativePointer, out pointers, out count))
                .ConfigureAwait(false);

            var players = new List<IPlayer>();
            for (ulong i = 0; i < count; i++)
            {
                players.Add(_plugin.PlayerPool[pointers[i]]);
            }

            return players;
        }

        public async Task EnableVoiceToAsync(IPlayer target)
        {
            Contract.NotNull(target, nameof(target));
            Contract.EntityValid(target, nameof(target));
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_EnableVoiceTo(NativePointer, target.NativePointer))
                .ConfigureAwait(false);
        }

        public async Task DisableVoiceToAsync(IPlayer target)
        {
            Contract.NotNull(target, nameof(target));
            Contract.EntityValid(target, nameof(target));
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_DisableVoiceTo(NativePointer, target.NativePointer))
                .ConfigureAwait(false);
        }
    }
}
