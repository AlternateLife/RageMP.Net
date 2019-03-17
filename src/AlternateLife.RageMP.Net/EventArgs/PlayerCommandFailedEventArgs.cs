using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerCommandFailedEventArgs : PlayerEventArgs
    {
        public string Input { get; }
        public CommandError Error { get; }
        public string ErrorMessage { get; }

        internal PlayerCommandFailedEventArgs(IPlayer player, string input, CommandError error, string errorMessage) : base(player)
        {
            Input = input;
            Error = error;
            ErrorMessage = errorMessage;
        }
    }
}
