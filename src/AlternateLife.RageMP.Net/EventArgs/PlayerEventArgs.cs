using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerEventArgs : System.EventArgs
    {
        public IPlayer Player { get; }

        internal PlayerEventArgs(IPlayer player)
        {
            Player = player;
        }
    }
}
