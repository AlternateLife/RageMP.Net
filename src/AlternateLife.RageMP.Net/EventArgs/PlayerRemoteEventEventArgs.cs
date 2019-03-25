using System.Collections.Generic;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerRemoteEventEventArgs : PlayerEventArgs
    {
        public string EventName { get; }
        public IReadOnlyList<object> Arguments { get; }

        internal PlayerRemoteEventEventArgs(IPlayer player, string eventName, object[] arguments) : base(player)
        {
            EventName = eventName;
            Arguments = arguments;
        }
    }
}
