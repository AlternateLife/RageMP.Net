using System.Collections.Generic;
using System.Linq;
using RageMP.Net.Native;

namespace RageMP.Net.Elements.Entities
{
    internal partial class Player
    {
        public uint CurrentWeapon
        {
            get => Rage.Player.Player_GetCurrentWeapon(NativePointer);
            set => Rage.Player.Player_SetCurrentWeapon(NativePointer, value);
        }

        public uint CurrentWeaponAmmo
        {
            get => Rage.Player.Player_GetCurrentWeaponAmmo(NativePointer);
            set => Rage.Player.Player_SetCurrentWeaponAmmo(NativePointer, value);
        }

        public IReadOnlyDictionary<uint, uint> Weapons
        {
            get
            {
                Rage.Player.Player_GetWeapons(NativePointer, out var weapons, out var ammo, out var count);

                var allWeapons = new Dictionary<uint, uint>();

                for (ulong i = 0; i < count; i++)
                {
                    allWeapons[weapons[i]] = ammo[i];
                }

                return allWeapons;
            }
        }

        public uint GetWeaponAmmo(uint weaponHash)
        {
            return Rage.Player.Player_GetWeaponAmmo(NativePointer, weaponHash);
        }

        public void SetWeaponAmmo(uint weaponHash, uint ammo)
        {
            Rage.Player.Player_SetWeaponAmmo(NativePointer, weaponHash, ammo);
        }

        public void GiveWeapon(uint weaponHash, uint ammo)
        {
            Rage.Player.Player_GiveWeapon(NativePointer, weaponHash, ammo);
        }

        public void GiveWeapons(IDictionary<uint, uint> weapons)
        {
            var count = weapons.Count;

            var hashes = weapons.Keys.ToArray();
            var ammo = weapons.Values.ToArray();

            Rage.Player.Player_GiveWeapons(NativePointer, hashes, ammo, (ulong) count);
        }

        public void RemoveWeapon(uint weaponHash)
        {
            Rage.Player.Player_RemoveWeapon(NativePointer, weaponHash);
        }

        public void RemoveWeapons(IEnumerable<uint> weaponHashes)
        {
            var weapons = weaponHashes.ToArray();

            Rage.Player.Player_RemoveWeapons(NativePointer, weapons, (ulong) weapons.Length);
        }

        public void RemoveAllWeapons()
        {
            Rage.Player.Player_RemoveAllWeapons(NativePointer);
        }

    }
}
