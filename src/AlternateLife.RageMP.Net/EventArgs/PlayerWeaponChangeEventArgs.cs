using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.EventArgs
{
    public class PlayerWeaponChangeEventArgs : PlayerEventArgs
    {
        public uint OldWeapon { get; }
        public uint NewWeapon { get; }

        internal PlayerWeaponChangeEventArgs(IPlayer player, uint oldWeapon, uint newWeapon) : base(player)
        {
            OldWeapon = oldWeapon;
            NewWeapon = newWeapon;
        }
    }
}
