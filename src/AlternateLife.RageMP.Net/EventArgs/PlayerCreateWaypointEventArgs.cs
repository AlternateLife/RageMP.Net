using System.Numerics;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerCreateWaypointEventArgs : PlayerEventArgs
    {
        public Vector3 Position { get; }

        internal PlayerCreateWaypointEventArgs(IPlayer player, Vector3 position) : base(player)
        {
            Position = position;
        }
    }
}
