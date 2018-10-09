using System.Collections.Generic;

namespace RageMP.Net.Entities
{
    public partial class Player
    {
        public uint CurrentWeapon { get; set; }
        public uint CurrentWeaponAmmo { get; set; }

        public uint GetWeaponAmmo(uint weaponHash)
        {
            throw new System.NotImplementedException();
        }

        public void SetWeaponAmmo(uint weaponHash, uint ammo)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyDictionary<uint, uint> GetWeapons()
        {
            throw new System.NotImplementedException();
        }

        public void GiveWeapon(uint weaponHash, uint ammo)
        {
            throw new System.NotImplementedException();
        }

        public void GiveWeapons(IDictionary<uint, uint> weapons)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveWeapon(uint weaponHash)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveWeapons(IEnumerable<uint> weaponHashes)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAllWeapons()
        {
            throw new System.NotImplementedException();
        }

    }
}
