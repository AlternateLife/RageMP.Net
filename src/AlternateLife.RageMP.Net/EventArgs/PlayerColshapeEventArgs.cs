using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerColshapeEventArgs : PlayerEventArgs
    {
        public IColshape Colshape { get; }

        internal PlayerColshapeEventArgs(IPlayer player, IColshape colshape) : base(player)
        {
            Colshape = colshape;
        }
    }
}
