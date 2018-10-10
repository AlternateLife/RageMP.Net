using System.Collections.Generic;
using RageMP.Net.Native;

namespace RageMP.Net.Entities
{
    public partial class Player
    {
        public uint CurrentWeapon { get; set; }
        public uint CurrentWeaponAmmo { get; set; }

        public uint GetWeaponAmmo(uint weaponHash)
        {
            return Rage.Player.Player_GetWeaponAmmo(NativePointer, weaponHash);
        }

        public void SetWeaponAmmo(uint weaponHash, uint ammo)
        {
            Rage.Player.Player_SetWeaponAmmo(NativePointer, weaponHash, ammo);
        }

        public IReadOnlyDictionary<uint, uint> GetWeapons()
        {
            throw new System.NotImplementedException();
        }

        public void GiveWeapon(uint weaponHash, uint ammo)
        {
            Rage.Player.Player_GiveWeapon(NativePointer, weaponHash, ammo);
        }

        public void GiveWeapons(IDictionary<uint, uint> weapons)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveWeapon(uint weaponHash)
        {
            Rage.Player.Player_RemoveWeapon(NativePointer, weaponHash);
        }

        public void RemoveWeapons(IEnumerable<uint> weaponHashes)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAllWeapons()
        {
            Rage.Player.Player_RemoveAllWeapons(NativePointer);
        }

    }
}
