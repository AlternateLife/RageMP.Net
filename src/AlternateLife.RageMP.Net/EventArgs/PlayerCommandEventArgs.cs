using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerCommandEventArgs : PlayerEventArgs
    {
        public string Input { get; }
        public bool Cancelled { get; set; }

        internal PlayerCommandEventArgs(IPlayer player, string input) : base(player)
        {
            Input = input;
        }
    }
}
