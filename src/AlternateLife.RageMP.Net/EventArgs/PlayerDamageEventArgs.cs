using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerDamageEventArgs : PlayerEventArgs
    {
        public float HealthLoss { get; }
        public float ArmorLoss { get; }

        internal PlayerDamageEventArgs(IPlayer player, float healthLoss, float armorLoss) : base(player)
        {
            HealthLoss = healthLoss;
            ArmorLoss = armorLoss;
        }
    }
}
