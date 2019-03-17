using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerChatEventArgs : PlayerEventArgs
    {
        public string Text { get; }

        internal PlayerChatEventArgs(IPlayer player, string text) : base(player)
        {
            Text = text;
        }
    }
}
