using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerCheckpointEventArgs : PlayerEventArgs
    {
        public ICheckpoint Checkpoint { get; }

        internal PlayerCheckpointEventArgs(IPlayer player, ICheckpoint checkpoint) : base(player)
        {
            Checkpoint = checkpoint;
        }
    }
}
