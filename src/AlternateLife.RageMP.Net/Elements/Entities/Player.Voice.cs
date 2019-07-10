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
            IntPtr players = IntPtr.Zero;
            ulong count = 0;

            await _plugin
                .Schedule(() =>
                {
                    CheckExistence();

                    Rage.Player.Player_GetVoiceListeners(NativePointer, out players, out count);
                })
                .ConfigureAwait(false);

            return ArrayHelper.ConvertFromIntPtr(players, count, x => _plugin.PlayerPool[x]);
        }

        public async Task EnableVoiceToAsync(IPlayer target)
        {
            Contract.NotNull(target, nameof(target));
            Contract.EntityValid(target, nameof(target));

            await _plugin
                .Schedule(() =>
                {
                    CheckExistence();

                    Rage.Player.Player_EnableVoiceTo(NativePointer, target.NativePointer);
                })
                .ConfigureAwait(false);
        }

        public async Task DisableVoiceToAsync(IPlayer target)
        {
            Contract.NotNull(target, nameof(target));
            Contract.EntityValid(target, nameof(target));

            await _plugin
                .Schedule(() =>
                {
                    CheckExistence();

                    Rage.Player.Player_DisableVoiceTo(NativePointer, target.NativePointer);
                })
                .ConfigureAwait(false);
        }
    }
}
