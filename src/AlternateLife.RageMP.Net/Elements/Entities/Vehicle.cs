using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Extensions;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal class Vehicle : Entity, IVehicle
    {
        internal Vehicle(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Vehicle)
        {
        }

        public async Task<Quaternion> GetQuaternionAsync()
        {
            CheckExistence();

            var quaternionPointer = await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetQuaternion(NativePointer))
                .ConfigureAwait(false);

            return StructConverter.PointerToStruct<Quaternion>(quaternionPointer);
        }

        public async Task<float> GetHeadingAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetHeading(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<float> GetMovableStateAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetMovableState(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<IVehicle> GetTrailerAsync()
        {
            CheckExistence();

            var vehicle = await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetTrailer(NativePointer))
                .ConfigureAwait(false);

            return _plugin.VehiclePool[vehicle];
        }

        public async Task<IVehicle> GetTraileredByAsync()
        {
            CheckExistence();

            var vehicle = await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetTraileredBy(NativePointer))
                .ConfigureAwait(false);

            return _plugin.VehiclePool[vehicle];
        }

        public async Task SetSirenActiveAsync(bool value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetSirenActive(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<bool> IsSirenActiveAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_IsSirenActive(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetHighbeamsActiveAsync(bool value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetHighbeamsActive(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<bool> AreHighbeamsActiveAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_AreHighbeamsActive(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetLightsActiveAsync(bool value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetLightsActive(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<bool> AreLightsActiveAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_AreLightsActive(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetTaxiLightsActiveAsync(bool value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetTaxiLightsActive(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<bool> AreTaxiLightsActiveAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_AreTaxiLightsActive(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetEngineActiveAsync(bool value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetEngineActive(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<bool> IsEngineActiveAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_IsEngineActive(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetNeonsActiveAsync(bool value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_EnableNeons(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<bool> AreNeonsActiveAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_AreNeonsEnabled(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetLockedAsync(bool value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_Lock(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<bool> IsLockedAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_IsLocked(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<bool> IsHornActiveAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_IsHornActive(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<bool> IsRocketBoostActiveAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_IsRocketBoostActive(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<bool> IsBreakActiveAsync()
        {
            CheckExistence();

            return await _plugin.
                Schedule(() => Rage.Vehicle.Vehicle_IsBrakeActive(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<bool> IsDeadAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_IsDead(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<float> GetSteerAngleAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetSteerAngle(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<float> GetGasPedalStateAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetGasPedalState(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<float> GetEngineHealthAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetEngineHealth(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<float> GetBodyHealthAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetBodyHealth(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<MaterialType> GetMaterialTypeAsync()
        {
            CheckExistence();

            return (MaterialType) await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetMaterialType(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetNeonsColorAsync(Color value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetNeonsColor(NativePointer, value.R, value.G, value.B))
                .ConfigureAwait(false);
        }

        public async Task<Color> GetNeonsColorAsync()
        {
            CheckExistence();

            var colorPointer = await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetNeonsColor(NativePointer))
                .ConfigureAwait(false);

            return StructConverter.PointerToStruct<ColorRgba>(colorPointer).FromModColor();
        }

        public async Task SetNumberPlateAsync(string value)
        {
            Contract.NotNull(value, nameof(value));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var numberPlate = converter.StringToPointer(value);

                await _plugin
                    .Schedule(() => Rage.Vehicle.Vehicle_SetNumberPlate(NativePointer, numberPlate))
                    .ConfigureAwait(false);
            }
        }

        public async Task<string> GetNumberPlateAsync()
        {
            CheckExistence();

            var numberPlatePointer = await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetNumberPlate(NativePointer))
                .ConfigureAwait(false);

            return StringConverter.PointerToString(numberPlatePointer);
        }

        public async Task SetLiveryAsync(uint value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetLivery(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetLiveryAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetLivery(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetWheelColorAsync(uint value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetWheelColor(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetWheelColorAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetWheelColor(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetWheelTypeAsync(uint value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetWheelType(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetWheelTypeAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetWheelType(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetNumberPlateTypeAsync(uint value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetNumberPlateType(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetNumberPlateTypeAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetNumberPlateType(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetPearlescentColorAsync(uint value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetPearlescentColor(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetPearlescentColorAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetPearlescentColor(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetWindowTintAsync(uint value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetWindowTint(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetWindowTintAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetWindowTint(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetDashboardColorAsync(uint value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetDashboardColor(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetDashboardColorAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetDashboardColor(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SetTrimColorAsync(uint value)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetTrimColor(NativePointer, value))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetTrimColorAsync()
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetTrimColor(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task ExplodeAsync()
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_Explode(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task RepairAsync()
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_Repair(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task SpawnAsync(Vector3 position, float heading)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_Spawn(NativePointer, position, heading))
                .ConfigureAwait(false);
        }

        public async Task<uint> GetModAsync(uint id)
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetMod(NativePointer, id))
                .ConfigureAwait(false);
        }

        public async Task<int> GetModAsync(int id)
        {
            return (int) await GetModAsync((uint) id).ConfigureAwait(false);
        }

        public async Task SetModAsync(uint id, uint mod)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetMod(NativePointer, id, mod))
                .ConfigureAwait(false);
        }

        public Task SetModAsync(int id, int mod)
        {
            return SetModAsync((uint) id, (uint) mod);
        }

        public async Task<uint> GetColorAsync(uint id)
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetColor(NativePointer, id))
                .ConfigureAwait(false);
        }

        public async Task<int> GetColorAsync(int id)
        {
            return (int) await GetColorAsync((uint) id)
                .ConfigureAwait(false);
        }

        public async Task<uint> GetPaintAsync(uint id)
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetPaint(NativePointer, id))
                .ConfigureAwait(false);
        }

        public async Task<int> GetPaintAsync(int id)
        {
            return (int) await GetPaintAsync((uint) id)
                .ConfigureAwait(false);
        }

        public async Task SetColorRgbAsync(Color primaryColor, Color secondaryColor)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetColorRGB(NativePointer, primaryColor.ToModColor(), secondaryColor.ToModColor()))
                .ConfigureAwait(false);
        }

        public async Task<Color> GetColorRgbAsync(uint colorSlot)
        {
            CheckExistence();

            var colorPointer = await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetColorRGB(NativePointer, colorSlot))
                .ConfigureAwait(false);

            return StructConverter.PointerToStruct<ColorRgba>(colorPointer).FromModColor();
        }

        public Task<Color> GetColorRgbAsync(int colorSlot)
        {
            return GetColorRgbAsync((uint) colorSlot);
        }

        public async Task SetColorAsync(uint primary, uint secondary)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetColor(NativePointer, primary, secondary))
                .ConfigureAwait(false);
        }

        public Task SetColorAsync(int primary, int secondary)
        {
            return SetColorAsync((uint) primary, (uint) secondary);
        }

        public async Task SetPaintAsync(PaintData primary, PaintData secondary)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetPaint(NativePointer, primary, secondary))
                .ConfigureAwait(false);
        }

        public async Task<bool> GetExtraAsync(uint id)
        {
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetExtra(NativePointer, id))
                .ConfigureAwait(false);
        }

        public Task<bool> GetExtraAsync(int id)
        {
            return GetExtraAsync((uint) id);
        }

        public async Task SetExtraAsync(uint id, bool state)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetExtra(NativePointer, id, state))
                .ConfigureAwait(false);
        }

        public Task SetExtraAsync(int id, bool state)
        {
            return SetExtraAsync((uint) id, state);
        }

        public async Task<IReadOnlyCollection<IPlayer>> GetOccupantsAsync()
        {
            CheckExistence();

            IntPtr playerPointers = IntPtr.Zero;
            ulong size = 0;

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetOccupants(NativePointer, out playerPointers, out size))
                .ConfigureAwait(false);

            return ArrayHelper.ConvertFromIntPtr(playerPointers, size, p => _plugin.PlayerPool[p]);
        }

        public async Task<IPlayer> GetOccupantAsync(int seat)
        {
            CheckExistence();

            var pointer = await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetOccupant(NativePointer, seat))
                .ConfigureAwait(false);

            return _plugin.PlayerPool[pointer];
        }

        public async Task SetOccupantAsync(int seat, IPlayer player)
        {
            Contract.NotNull(player, nameof(player));
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_SetOccupant(NativePointer, seat, player.NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<bool> IsStreamedAsync(IPlayer forPlayer)
        {
            Contract.NotNull(forPlayer, nameof(forPlayer));
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_IsStreamed(NativePointer, forPlayer.NativePointer))
                .ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<IPlayer>> GetStreamedPlayersAsync()
        {
            CheckExistence();

            IntPtr playerPointers = IntPtr.Zero;
            ulong size = 0;

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetStreamed(NativePointer, out playerPointers, out size))
                .ConfigureAwait(false);

            return ArrayHelper.ConvertFromIntPtr(playerPointers, size, x => _plugin.PlayerPool[x]);
        }
    }
}
