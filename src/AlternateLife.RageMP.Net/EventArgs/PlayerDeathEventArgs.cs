using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerDeathEventArgs : PlayerEventArgs
    {
        public uint Reason { get; }
        public IPlayer Killer { get; }

        internal PlayerDeathEventArgs(IPlayer player, uint reason, IPlayer killer) : base(player)
        {
            Reason = reason;
            Killer = killer;
        }
    }
}
