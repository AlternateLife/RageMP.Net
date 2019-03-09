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
        public async Task SetCurrentWeaponAsync(uint value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetCurrentWeapon(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetCurrentWeaponAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Player.Player_GetCurrentWeapon(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetCurrentWeaponAmmoAsync(uint value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetCurrentWeaponAmmo(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetCurrentWeaponAmmoAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Player.Player_GetCurrentWeaponAmmo(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetWeaponAmmoAsync(WeaponHash weaponHash)
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Player.Player_GetWeaponAmmo(NativePointer, (uint) weaponHash))
                .ConfigureAwait(false);
        }

        public Task<uint> GetWeaponAmmoAsync(uint weapon)
        {
            return GetWeaponAmmoAsync((WeaponHash) weapon);
        }

        public async Task<int> GetWeaponAmmoAsync(int weapon)
        {
            return (int) await GetWeaponAmmoAsync((WeaponHash) weapon)
                .ConfigureAwait(false);
        }

        public async Task SetWeaponAmmoAsync(WeaponHash weaponHash, uint ammo)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_SetWeaponAmmo(NativePointer, (uint) weaponHash, ammo))
                .ConfigureAwait(false);
        }

        public Task SetWeaponAmmoAsync(WeaponHash weapon, int ammo)
        {
            return SetWeaponAmmoAsync(weapon, (uint) ammo);
        }

        public Task SetWeaponAmmoAsync(uint weapon, uint ammo)
        {
            return SetWeaponAmmoAsync((WeaponHash) weapon, ammo);
        }

        public Task SetWeaponAmmoAsync(int weapon, int ammo)
        {
            return SetWeaponAmmoAsync((WeaponHash) weapon, (uint) ammo);
        }

        public async Task GiveWeaponAsync(WeaponHash weaponHash, uint ammo)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_GiveWeapon(NativePointer, (uint) weaponHash, ammo))
                .ConfigureAwait(false);
        }

        public Task GiveWeaponAsync(WeaponHash weapon, int ammo)
        {
            return GiveWeaponAsync(weapon, (uint) ammo);
        }

        public Task GiveWeaponAsync(uint weapon, uint ammo)
        {
            return GiveWeaponAsync((WeaponHash) weapon, ammo);
        }

        public Task GiveWeaponAsync(int weapon, int ammo)
        {
            return GiveWeaponAsync((WeaponHash) weapon, (uint) ammo);
        }

        public async Task GiveWeaponsAsync(IDictionary<WeaponHash, uint> weapons)
        {
            Contract.NotNull(weapons, nameof(weapons));
            CheckExistence();

            var count = weapons.Count;

            var hashes = weapons.Keys.Select(x => (uint) x).ToArray();
            var ammo = weapons.Values.ToArray();

            await _plugin
                .Schedule(() => Rage.Player.Player_GiveWeapons(NativePointer, hashes, ammo, (ulong) count))
                .ConfigureAwait(false);
        }

        public Task GiveWeaponsAsync(IDictionary<WeaponHash, int> weapons)
        {
            return GiveWeaponsAsync(weapons.ToDictionary(x => x.Key, x => (uint) x.Value));
        }

        public Task GiveWeaponsAsync(IDictionary<uint, uint> weapons)
        {
            return GiveWeaponsAsync(weapons.ToDictionary(x => (WeaponHash) x.Key, x => x.Value));
        }

        public Task GiveWeaponsAsync(IDictionary<int, int> weapons)
        {
            return GiveWeaponsAsync(weapons.ToDictionary(x => (WeaponHash) x.Key, x => (uint) x.Value));
        }

        public async Task RemoveWeaponAsync(WeaponHash weaponHash)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_RemoveWeapon(NativePointer, (uint) weaponHash))
                .ConfigureAwait(false);
        }

        public Task RemoveWeaponAsync(uint weapon)
        {
            return RemoveWeaponAsync((WeaponHash) weapon);
        }

        public Task RemoveWeaponAsync(int weapon)
        {
            return RemoveWeaponAsync((WeaponHash) weapon);
        }

        public async Task RemoveWeaponsAsync(IEnumerable<uint> weaponHashes)
        {
            Contract.NotNull(weaponHashes, nameof(weaponHashes));
            CheckExistence();

            var weapons = weaponHashes.ToArray();

            await _plugin
                .Schedule(() => Rage.Player.Player_RemoveWeapons(NativePointer, weapons, (ulong) weapons.Length))
                .ConfigureAwait(false);
        }

        public Task RemoveWeaponsAsync(IEnumerable<WeaponHash> weaponHashes)
        {
            return RemoveWeaponsAsync(weaponHashes.Select(x => (uint) x));
        }

        public Task RemoveWeaponsAsync(IEnumerable<int> weaponHashes)
        {
            return RemoveWeaponsAsync(weaponHashes.Select(x => (uint) x));
        }

        public async Task RemoveAllWeaponsAsync()
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_RemoveAllWeapons(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<IReadOnlyDictionary<WeaponHash, uint>> GetWeaponsAsync()
        {
            CheckExistence();

            IntPtr weapons = IntPtr.Zero;
            IntPtr ammo = IntPtr.Zero;
            ulong count = 0;

            await _plugin
                .Schedule(() => Rage.Player.Player_GetWeapons(NativePointer, out weapons, out ammo, out count))
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
