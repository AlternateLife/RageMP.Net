using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerQuitEventArgs : PlayerEventArgs
    {
        public DisconnectReason Type { get; }
        public string Reason { get; }

        internal PlayerQuitEventArgs(IPlayer player, DisconnectReason type, string reason) : base(player)
        {
            Type = type;
            Reason = reason;
        }
    }
}
