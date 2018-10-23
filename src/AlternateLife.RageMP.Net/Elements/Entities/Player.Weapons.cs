using System.Collections.Generic;
using System.Linq;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
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

        public IReadOnlyDictionary<WeaponHash, uint> Weapons
        {
            get
            {
                Rage.Player.Player_GetWeapons(NativePointer, out var weapons, out var ammo, out var count);

                var allWeapons = new Dictionary<WeaponHash, uint>();

                for (ulong i = 0; i < count; i++)
                {
                    allWeapons[(WeaponHash) weapons[i]] = ammo[i];
                }

                return allWeapons;
            }
        }

        public uint GetWeaponAmmo(WeaponHash weaponHash)
        {
            return Rage.Player.Player_GetWeaponAmmo(NativePointer, (uint) weaponHash);
        }

        public void SetWeaponAmmo(WeaponHash weaponHash, uint ammo)
        {
            Rage.Player.Player_SetWeaponAmmo(NativePointer, (uint) weaponHash, ammo);
        }

        public void GiveWeapon(WeaponHash weaponHash, uint ammo)
        {
            Rage.Player.Player_GiveWeapon(NativePointer, (uint) weaponHash, ammo);
        }

        public void GiveWeapons(IDictionary<WeaponHash, uint> weapons)
        {
            Contract.NotNull(weapons, nameof(weapons));

            var count = weapons.Count;

            var hashes = weapons.Keys.Select(x => (uint) x).ToArray();
            var ammo = weapons.Values.ToArray();

            Rage.Player.Player_GiveWeapons(NativePointer, hashes, ammo, (ulong) count);
        }

        public void RemoveWeapon(WeaponHash weaponHash)
        {
            Rage.Player.Player_RemoveWeapon(NativePointer, (uint) weaponHash);
        }

        public void RemoveWeapons(IEnumerable<WeaponHash> weaponHashes)
        {
            Contract.NotNull(weaponHashes, nameof(weaponHashes));

            var weapons = weaponHashes.Select(x => (uint) x).ToArray();

            Rage.Player.Player_RemoveWeapons(NativePointer, weapons, (ulong) weapons.Length);
        }

        public void RemoveAllWeapons()
        {
            Rage.Player.Player_RemoveAllWeapons(NativePointer);
        }

    }
}
