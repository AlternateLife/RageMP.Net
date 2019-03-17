using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerStreamEventArgs : PlayerEventArgs
    {
        public IPlayer ForPlayer { get; }

        internal PlayerStreamEventArgs(IPlayer player, IPlayer forPlayer) : base(player)
        {
            ForPlayer = forPlayer;
        }
    }
}
