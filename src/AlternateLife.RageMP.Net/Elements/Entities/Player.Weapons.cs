using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal partial class Player
    {
        public uint CurrentWeapon
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_GetCurrentWeapon(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Player.Player_SetCurrentWeapon(NativePointer, value);
            }
        }

        public uint CurrentWeaponAmmo
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_GetCurrentWeaponAmmo(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Player.Player_SetCurrentWeaponAmmo(NativePointer, value);
            }
        }


        public uint GetWeaponAmmo(WeaponHash weaponHash)
        {
            CheckExistence();

            return Rage.Player.Player_GetWeaponAmmo(NativePointer, (uint) weaponHash);
        }

        public uint GetWeaponAmmo(uint weapon)
        {
            return GetWeaponAmmo((WeaponHash) weapon);
        }

        public int GetWeaponAmmo(int weapon)
        {
            return (int) GetWeaponAmmo((WeaponHash) weapon);
        }

        public void SetWeaponAmmo(WeaponHash weaponHash, uint ammo)
        {
            CheckExistence();

            Rage.Player.Player_SetWeaponAmmo(NativePointer, (uint) weaponHash, ammo);
        }

        public void SetWeaponAmmo(WeaponHash weapon, int ammo)
        {
            SetWeaponAmmo(weapon, (uint) ammo);
        }

        public void SetWeaponAmmo(uint weapon, uint ammo)
        {
            SetWeaponAmmo((WeaponHash) weapon, ammo);
        }

        public void SetWeaponAmmo(int weapon, int ammo)
        {
            SetWeaponAmmo((WeaponHash) weapon, (uint) ammo);
        }

        public void GiveWeapon(WeaponHash weaponHash, uint ammo)
        {
            CheckExistence();

            Rage.Player.Player_GiveWeapon(NativePointer, (uint) weaponHash, ammo);
        }

        public void GiveWeapon(WeaponHash weapon, int ammo)
        {
            GiveWeapon(weapon, (uint) ammo);
        }

        public void GiveWeapon(uint weapon, uint ammo)
        {
            GiveWeapon((WeaponHash) weapon, ammo);
        }

        public void GiveWeapon(int weapon, int ammo)
        {
            GiveWeapon((WeaponHash) weapon, (uint) ammo);
        }

        public void GiveWeapons(IDictionary<WeaponHash, uint> weapons)
        {
            Contract.NotNull(weapons, nameof(weapons));
            CheckExistence();

            var count = weapons.Count;

            var hashes = weapons.Keys.Select(x => (uint) x).ToArray();
            var ammo = weapons.Values.ToArray();

            Rage.Player.Player_GiveWeapons(NativePointer, hashes, ammo, (ulong) count);
        }

        public void GiveWeapons(IDictionary<WeaponHash, int> weapons)
        {
            GiveWeapons(weapons.ToDictionary(x => x.Key, x => (uint) x.Value));
        }

        public void GiveWeapons(IDictionary<uint, uint> weapons)
        {
            GiveWeapons(weapons.ToDictionary(x => (WeaponHash) x.Key, x => x.Value));
        }

        public void GiveWeapons(IDictionary<int, int> weapons)
        {
            GiveWeapons(weapons.ToDictionary(x => (WeaponHash) x.Key, x => (uint) x.Value));
        }

        public void RemoveWeapon(WeaponHash weaponHash)
        {
            CheckExistence();

            Rage.Player.Player_RemoveWeapon(NativePointer, (uint) weaponHash);
        }

        public void RemoveWeapon(uint weapon)
        {
            RemoveWeapon((WeaponHash) weapon);
        }

        public void RemoveWeapon(int weapon)
        {
            RemoveWeapon((WeaponHash) weapon);
        }

        public void RemoveWeapons(IEnumerable<uint> weaponHashes)
        {
            Contract.NotNull(weaponHashes, nameof(weaponHashes));
            CheckExistence();

            var weapons = weaponHashes.ToArray();

            Rage.Player.Player_RemoveWeapons(NativePointer, weapons, (ulong) weapons.Length);
        }

        public void RemoveWeapons(IEnumerable<WeaponHash> weaponHashes)
        {
            RemoveWeapons(weaponHashes.Select(x => (uint) x));
        }

        public void RemoveWeapons(IEnumerable<int> weaponHashes)
        {
            RemoveWeapons(weaponHashes.Select(x => (uint) x));
        }

        public void RemoveAllWeapons()
        {
            CheckExistence();

            Rage.Player.Player_RemoveAllWeapons(NativePointer);
        }

        public async Task<IReadOnlyDictionary<WeaponHash, uint>> GetWeaponsAsync()
        {
            IntPtr weapons = IntPtr.Zero;
            IntPtr ammo = IntPtr.Zero;
            ulong count = 0;

            await _plugin
                .Schedule(() =>
                {
                    CheckExistence();

                    Rage.Player.Player_GetWeapons(NativePointer, out weapons, out ammo, out count);
                })
                .ConfigureAwait(false);

            var allWeapons = new Dictionary<WeaponHash, uint>();

            for (ulong i = 0; i < count; i++)
            {
                var weaponHash = (uint) Marshal.ReadInt32(weapons, (int) i);
                var weaponAmmo = (uint) Marshal.ReadInt32(ammo, (int) i);

                allWeapons[(WeaponHash) weaponHash] = weaponAmmo;
            }

            return allWeapons;
        }
    }
}
