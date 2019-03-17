using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerDisconnectEventArgs : PlayerEventArgs
    {
        public DisconnectReason Type { get; }
        public string Reason { get; }

        internal PlayerDisconnectEventArgs(IPlayer player, DisconnectReason type, string reason) : base(player)
        {
            Type = type;
            Reason = reason;
        }
    }
}
