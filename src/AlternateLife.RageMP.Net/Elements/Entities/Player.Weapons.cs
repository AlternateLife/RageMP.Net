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
        public void SetCurrentWeapon(uint value)
        {
            CheckExistence();

            Rage.Player.Player_SetCurrentWeapon(NativePointer, value);
        }

        public Task SetCurrentWeaponAsync(uint value)
        {
            return _plugin.Schedule(() => SetCurrentWeapon(value));
        }

        public uint GetCurrentWeapon()
        {
            CheckExistence();

            return Rage.Player.Player_GetCurrentWeapon(NativePointer);
        }

        public Task<uint> GetCurrentWeaponAsync()
        {
            return _plugin.Schedule(GetCurrentWeapon);
        }

        public void SetCurrentWeaponAmmo(uint value)
        {
            CheckExistence();

            Rage.Player.Player_SetCurrentWeaponAmmo(NativePointer, value);
        }

        public Task SetCurrentWeaponAmmoAsync(uint value)
        {
            return _plugin.Schedule(() => SetCurrentWeaponAmmo(value));
        }

        public uint GetCurrentWeaponAmmo()
        {
            CheckExistence();

            return Rage.Player.Player_GetCurrentWeaponAmmo(NativePointer);
        }

        public Task<uint> GetCurrentWeaponAmmoAsync()
        {
            return _plugin.Schedule(GetCurrentWeaponAmmo);
        }

        public uint GetWeaponAmmo(WeaponHash weaponHash)
        {
            CheckExistence();

            return Rage.Player.Player_GetWeaponAmmo(NativePointer, (uint) weaponHash);
        }

        public Task<uint> GetWeaponAmmoAsync(WeaponHash weaponHash)
        {
            return _plugin.Schedule(() => GetWeaponAmmo(weaponHash));
        }

        public uint GetWeaponAmmo(uint weapon)
        {
            return GetWeaponAmmo((WeaponHash) weapon);
        }

        public Task<uint> GetWeaponAmmoAsync(uint weapon)
        {
            return GetWeaponAmmoAsync((WeaponHash) weapon);
        }

        public int GetWeaponAmmo(int weapon)
        {
            return (int) GetWeaponAmmo((WeaponHash) weapon);
        }

        public Task<int> GetWeaponAmmoAsync(int weapon)
        {
            return _plugin.Schedule(() => GetWeaponAmmo(weapon));
        }

        public void SetWeaponAmmo(WeaponHash weaponHash, uint ammo)
        {
            CheckExistence();

            Rage.Player.Player_SetWeaponAmmo(NativePointer, (uint) weaponHash, ammo);
        }

        public Task SetWeaponAmmoAsync(WeaponHash weaponHash, uint ammo)
        {
            return _plugin.Schedule(() => SetWeaponAmmo(weaponHash, ammo));
        }

        public void SetWeaponAmmo(WeaponHash weapon, int ammo)
        {
            SetWeaponAmmo(weapon, (uint) ammo);
        }

        public Task SetWeaponAmmoAsync(WeaponHash weapon, int ammo)
        {
            return SetWeaponAmmoAsync(weapon, (uint) ammo);
        }

        public void SetWeaponAmmo(uint weapon, uint ammo)
        {
            SetWeaponAmmo((WeaponHash) weapon, ammo);
        }

        public Task SetWeaponAmmoAsync(uint weapon, uint ammo)
        {
            return SetWeaponAmmoAsync((WeaponHash) weapon, ammo);
        }

        public void SetWeaponAmmo(int weapon, int ammo)
        {
            SetWeaponAmmo((WeaponHash) weapon, (uint) ammo);
        }

        public Task SetWeaponAmmoAsync(int weapon, int ammo)
        {
            return SetWeaponAmmoAsync((WeaponHash) weapon, (uint) ammo);
        }

        public void GiveWeapon(WeaponHash weaponHash, uint ammo)
        {
            CheckExistence();

            Rage.Player.Player_GiveWeapon(NativePointer, (uint) weaponHash, ammo);
        }

        public Task GiveWeaponAsync(WeaponHash weaponHash, uint ammo)
        {
            return _plugin.Schedule(() => GiveWeapon(weaponHash, ammo));
        }

        public void GiveWeapon(WeaponHash weapon, int ammo)
        {
            GiveWeapon(weapon, (uint) ammo);
        }

        public Task GiveWeaponAsync(WeaponHash weapon, int ammo)
        {
            return GiveWeaponAsync(weapon, (uint) ammo);
        }

        public void GiveWeapon(uint weapon, uint ammo)
        {
            GiveWeapon((WeaponHash) weapon, ammo);
        }

        public Task GiveWeaponAsync(uint weapon, uint ammo)
        {
            return GiveWeaponAsync((WeaponHash) weapon, ammo);
        }

        public void GiveWeapon(int weapon, int ammo)
        {
            GiveWeapon((WeaponHash) weapon, (uint) ammo);
        }

        public Task GiveWeaponAsync(int weapon, int ammo)
        {
            return GiveWeaponAsync((WeaponHash) weapon, (uint) ammo);
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

        public Task GiveWeaponsAsync(IDictionary<WeaponHash, uint> weapons)
        {
            return _plugin.Schedule(() => GiveWeapons(weapons));
        }

        public void GiveWeapons(IDictionary<WeaponHash, int> weapons)
        {
            GiveWeapons(weapons.ToDictionary(x => x.Key, x => (uint) x.Value));
        }

        public Task GiveWeaponsAsync(IDictionary<WeaponHash, int> weapons)
        {
            return GiveWeaponsAsync(weapons.ToDictionary(x => x.Key, x => (uint) x.Value));
        }

        public void GiveWeapons(IDictionary<uint, uint> weapons)
        {
            GiveWeapons(weapons.ToDictionary(x => (WeaponHash) x.Key, x => x.Value));
        }

        public Task GiveWeaponsAsync(IDictionary<uint, uint> weapons)
        {
            return GiveWeaponsAsync(weapons.ToDictionary(x => (WeaponHash) x.Key, x => x.Value));
        }

        public void GiveWeapons(IDictionary<int, int> weapons)
        {
            GiveWeapons(weapons.ToDictionary(x => (WeaponHash) x.Key, x => (uint) x.Value));
        }

        public Task GiveWeaponsAsync(IDictionary<int, int> weapons)
        {
            return GiveWeaponsAsync(weapons.ToDictionary(x => (WeaponHash) x.Key, x => (uint) x.Value));
        }

        public void RemoveWeapon(WeaponHash weaponHash)
        {
            CheckExistence();

            Rage.Player.Player_RemoveWeapon(NativePointer, (uint) weaponHash);
        }

        public Task RemoveWeaponAsync(WeaponHash weaponHash)
        {
            return _plugin.Schedule(() => RemoveWeapon(weaponHash));
        }

        public void RemoveWeapon(uint weapon)
        {
            RemoveWeapon((WeaponHash) weapon);
        }

        public Task RemoveWeaponAsync(uint weapon)
        {
            return RemoveWeaponAsync((WeaponHash) weapon);
        }

        public void RemoveWeapon(int weapon)
        {
            RemoveWeapon((WeaponHash) weapon);
        }

        public Task RemoveWeaponAsync(int weapon)
        {
            return RemoveWeaponAsync((WeaponHash) weapon);
        }

        public void RemoveWeapons(IEnumerable<uint> weaponHashes)
        {
            Contract.NotNull(weaponHashes, nameof(weaponHashes));
            CheckExistence();

            var weapons = weaponHashes.ToArray();

            Rage.Player.Player_RemoveWeapons(NativePointer, weapons, (ulong) weapons.LongLength);
        }
        
        public Task RemoveWeaponsAsync(IEnumerable<uint> weaponHashes)
        {
            return _plugin.Schedule(() => RemoveWeapons(weaponHashes));
        }

        public void RemoveWeapons(IEnumerable<WeaponHash> weaponHashes)
        {
            RemoveWeapons(weaponHashes.Select(x => (uint) x));
        }
        
        public Task RemoveWeaponsAsync(IEnumerable<WeaponHash> weaponHashes)
        {
            return RemoveWeaponsAsync(weaponHashes.Select(x => (uint) x));
        }

        public void RemoveWeapons(IEnumerable<int> weaponHashes)
        {
            RemoveWeapons(weaponHashes.Select(x => (uint) x));
        }
        
        public Task RemoveWeaponsAsync(IEnumerable<int> weaponHashes)
        {
            return RemoveWeaponsAsync(weaponHashes.Select(x => (uint) x));
        }

        public void RemoveAllWeapons()
        {
            CheckExistence();

            Rage.Player.Player_RemoveAllWeapons(NativePointer);
        }
        
        public Task RemoveAllWeaponsAsync()
        {
            return _plugin.Schedule(RemoveAllWeapons);
        }

        public IReadOnlyDictionary<WeaponHash, uint> GetWeapons()
        {
            CheckExistence();

            Rage.Player.Player_GetWeapons(NativePointer, out var weapons, out var ammo, out var count);

            var allWeapons = new Dictionary<WeaponHash, uint>();

            for (ulong i = 0; i < count; i++)
            {
                var weaponHash = (uint) Marshal.ReadInt32(weapons, (int) i);
                var weaponAmmo = (uint) Marshal.ReadInt32(ammo, (int) i);

                allWeapons[(WeaponHash) weaponHash] = weaponAmmo;
            }

            return allWeapons;
        }
        
        public Task<IReadOnlyDictionary<WeaponHash, uint>> GetWeaponsAsync()
        {
            return _plugin.Schedule(GetWeapons);
        }
    }
}
