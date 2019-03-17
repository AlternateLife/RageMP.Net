using System.Collections.Generic;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal partial class Player
    {
        public IReadOnlyCollection<IPlayer> GetVoiceListeners()
        {
            CheckExistence();

            Rage.Player.Player_GetVoiceListeners(NativePointer, out var players, out var count);

            return ArrayHelper.ConvertFromIntPtr(players, count, x => _plugin.PlayerPool[x]);
        }

        public Task<IReadOnlyCollection<IPlayer>> GetVoiceListenersAsync()
        {
            return _plugin.Schedule(GetVoiceListeners);
        }

        public void EnableVoiceTo(IPlayer target)
        {
            Contract.NotNull(target, nameof(target));
            Contract.EntityValid(target, nameof(target));
            CheckExistence();

            Rage.Player.Player_EnableVoiceTo(NativePointer, target.NativePointer);
        }

        public Task EnableVoiceToAsync(IPlayer target)
        {
            return _plugin.Schedule(() => EnableVoiceTo(target));
        }

        public void DisableVoiceTo(IPlayer target)
        {
            Contract.NotNull(target, nameof(target));
            Contract.EntityValid(target, nameof(target));
            CheckExistence();

            Rage.Player.Player_DisableVoiceTo(NativePointer, target.NativePointer);
        }

        public Task DisableVoiceToAsync(IPlayer target)
        {
            return _plugin.Schedule(() => DisableVoiceTo(target));
        }
    }
}
