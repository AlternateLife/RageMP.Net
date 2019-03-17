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

        public Quaternion GetQuaternion()
        {
            CheckExistence();

            return StructConverter.PointerToStruct<Quaternion>(Rage.Vehicle.Vehicle_GetQuaternion(NativePointer));
        }

        public Task<Quaternion> GetQuaternionAsync()
        {
            return _plugin.Schedule(GetQuaternion);
        }

        public float GetHeading()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetHeading(NativePointer);
        }

        public Task<float> GetHeadingAsync()
        {
            return _plugin.Schedule(GetHeading);
        }

        public float GetMovableState()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetMovableState(NativePointer);
        }

        public Task<float> GetMovableStateAsync()
        {
            return _plugin.Schedule(GetMovableState);
        }

        public IVehicle GetTrailer()
        {
            CheckExistence();

            return _plugin.VehiclePool[Rage.Vehicle.Vehicle_GetTrailer(NativePointer)];
        }

        public Task<IVehicle> GetTrailerAsync()
        {
            return _plugin.Schedule(GetTrailer);
        }

        public IVehicle GetTraileredBy()
        {
            CheckExistence();

            return _plugin.VehiclePool[Rage.Vehicle.Vehicle_GetTraileredBy(NativePointer)];
        }

        public Task<IVehicle> GetTraileredByAsync()
        {
            return _plugin.Schedule(GetTraileredBy);
        }

        public void SetSirenActive(bool value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetSirenActive(NativePointer, value);
        }

        public Task SetSirenActiveAsync(bool value)
        {
            return _plugin.Schedule(() => SetSirenActive(value));
        }

        public bool IsSirenActive()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_IsSirenActive(NativePointer);
        }

        public Task<bool> IsSirenActiveAsync()
        {
            return _plugin.Schedule(IsSirenActive);
        }

        public void SetHighbeamsActive(bool value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetHighbeamsActive(NativePointer, value);
        }

        public Task SetHighbeamsActiveAsync(bool value)
        {
            return _plugin.Schedule(() => SetHighbeamsActive(value));
        }

        public bool AreHighbeamsActive()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_AreHighbeamsActive(NativePointer);
        }

        public Task<bool> AreHighbeamsActiveAsync()
        {
            return _plugin.Schedule(AreHighbeamsActive);
        }

        public void SetLightsActive(bool value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetLightsActive(NativePointer, value);
        }

        public Task SetLightsActiveAsync(bool value)
        {
            return _plugin.Schedule(() => SetLightsActive(value));
        }

        public bool AreLightsActive()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_AreLightsActive(NativePointer);
        }

        public Task<bool> AreLightsActiveAsync()
        {
            return _plugin.Schedule(AreLightsActive);
        }

        public void SetTaxiLightsActive(bool value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetTaxiLightsActive(NativePointer, value);
        }

        public Task SetTaxiLightsActiveAsync(bool value)
        {
            return _plugin.Schedule(() => SetTaxiLightsActive(value));
        }

        public bool AreTaxiLightsActive()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_AreTaxiLightsActive(NativePointer);
        }

        public Task<bool> AreTaxiLightsActiveAsync()
        {
            return _plugin.Schedule(AreTaxiLightsActive);
        }

        public void SetEngineActive(bool value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetEngineActive(NativePointer, value);
        }

        public Task SetEngineActiveAsync(bool value)
        {
            return _plugin.Schedule(() => SetEngineActive(value));
        }

        public bool IsEngineActive()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_IsEngineActive(NativePointer);
        }

        public Task<bool> IsEngineActiveAsync()
        {
            return _plugin.Schedule(IsEngineActive);
        }

        public void SetNeonsActive(bool value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_EnableNeons(NativePointer, value);
        }

        public Task SetNeonsActiveAsync(bool value)
        {
            return _plugin.Schedule(() => SetNeonsActive(value));
        }

        public bool AreNeonsActive()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_AreNeonsEnabled(NativePointer);
        }

        public Task<bool> AreNeonsActiveAsync()
        {
            return _plugin.Schedule(AreNeonsActive);
        }

        public void SetLocked(bool value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_Lock(NativePointer, value);
        }

        public Task SetLockedAsync(bool value)
        {
            return _plugin.Schedule(() => SetLocked(value));
        }

        public bool IsLocked()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_IsLocked(NativePointer);
        }

        public Task<bool> IsLockedAsync()
        {
            return _plugin.Schedule(IsLocked);
        }

        public bool IsHornActive()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_IsHornActive(NativePointer);
        }

        public Task<bool> IsHornActiveAsync()
        {
            return _plugin.Schedule(IsHornActive);
        }

        public bool IsRocketBoostActive()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_IsRocketBoostActive(NativePointer);
        }

        public Task<bool> IsRocketBoostActiveAsync()
        {
            return _plugin.Schedule(IsRocketBoostActive);
        }

        public bool IsBreakActive()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_IsBrakeActive(NativePointer);
        }

        public Task<bool> IsBreakActiveAsync()
        {
            return _plugin.Schedule(IsBreakActive);
        }

        public bool IsDead()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_IsDead(NativePointer);
        }

        public Task<bool> IsDeadAsync()
        {
            return _plugin.Schedule(IsDead);
        }

        public float GetSteerAngle()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetSteerAngle(NativePointer);
        }

        public Task<float> GetSteerAngleAsync()
        {
            return _plugin.Schedule(GetSteerAngle);
        }

        public float GetGasPedalState()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetGasPedalState(NativePointer);
        }

        public Task<float> GetGasPedalStateAsync()
        {
            return _plugin.Schedule(GetGasPedalState);
        }

        public float GetEngineHealth()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetEngineHealth(NativePointer);
        }

        public Task<float> GetEngineHealthAsync()
        {
            return _plugin.Schedule(GetEngineHealth);
        }

        public float GetBodyHealth()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetBodyHealth(NativePointer);
        }

        public Task<float> GetBodyHealthAsync()
        {
            return _plugin.Schedule(GetBodyHealth);
        }

        public MaterialType GetMaterialType()
        {
            CheckExistence();

            return (MaterialType) Rage.Vehicle.Vehicle_GetMaterialType(NativePointer);
        }

        public Task<MaterialType> GetMaterialTypeAsync()
        {
            return _plugin.Schedule(GetMaterialType);
        }

        public void SetNeonsColor(Color value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetNeonsColor(NativePointer, value.R, value.G, value.B);
        }

        public Task SetNeonsColorAsync(Color value)
        {
            return _plugin.Schedule(() => SetNeonsColor(value));
        }

        public Color GetNeonsColor()
        {
            CheckExistence();

            return StructConverter.PointerToStruct<ColorRgba>(Rage.Vehicle.Vehicle_GetNeonsColor(NativePointer)).FromModColor();
        }

        public Task<Color> GetNeonsColorAsync()
        {
            return _plugin.Schedule(GetNeonsColor);
        }

        public void SetNumberPlate(string value)
        {
            Contract.NotNull(value, nameof(value));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                Rage.Vehicle.Vehicle_SetNumberPlate(NativePointer, converter.StringToPointer(value));
            }
        }

        public Task SetNumberPlateAsync(string value)
        {
            return _plugin.Schedule(() => SetNumberPlate(value));
        }

        public string GetNumberPlate()
        {
            CheckExistence();

            return StringConverter.PointerToString(Rage.Vehicle.Vehicle_GetNumberPlate(NativePointer));
        }

        public Task<string> GetNumberPlateAsync()
        {
            return _plugin.Schedule(GetNumberPlate);
        }

        public void SetLivery(uint value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetLivery(NativePointer, value);
        }

        public Task SetLiveryAsync(uint value)
        {
            return _plugin.Schedule(() => SetLivery(value));
        }

        public uint GetLivery()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetLivery(NativePointer);
        }

        public Task<uint> GetLiveryAsync()
        {
            return _plugin.Schedule(GetLivery);
        }

        public void SetWheelColor(uint value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetWheelColor(NativePointer, value);
        }

        public Task SetWheelColorAsync(uint value)
        {
            return _plugin.Schedule(() => SetWheelColor(value));
        }

        public uint GetWheelColor()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetWheelColor(NativePointer);
        }

        public Task<uint> GetWheelColorAsync()
        {
            return _plugin.Schedule(GetWheelColor);
        }

        public void SetWheelType(uint value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetWheelType(NativePointer, value);
        }

        public Task SetWheelTypeAsync(uint value)
        {
            return _plugin.Schedule(() => SetWheelType(value));
        }

        public uint GetWheelType()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetWheelType(NativePointer);
        }

        public Task<uint> GetWheelTypeAsync()
        {
            return _plugin.Schedule(GetWheelType);
        }

        public void SetNumberPlateType(uint value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetNumberPlateType(NativePointer, value);
        }

        public Task SetNumberPlateTypeAsync(uint value)
        {
            return _plugin.Schedule(() => SetNumberPlateType(value));
        }

        public uint GetNumberPlateType()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetNumberPlateType(NativePointer);
        }

        public Task<uint> GetNumberPlateTypeAsync()
        {
            return _plugin.Schedule(GetNumberPlateType);
        }

        public void SetPearlescentColor(uint value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetPearlescentColor(NativePointer, value);
        }

        public Task SetPearlescentColorAsync(uint value)
        {
            return _plugin.Schedule(() => SetPearlescentColor(value));
        }

        public uint GetPearlescentColor()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetPearlescentColor(NativePointer);
        }

        public Task<uint> GetPearlescentColorAsync()
        {
            return _plugin.Schedule(GetPearlescentColor);
        }

        public void SetWindowTint(uint value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetWindowTint(NativePointer, value);
        }

        public Task SetWindowTintAsync(uint value)
        {
            return _plugin.Schedule(() => SetWindowTint(value));
        }

        public uint GetWindowTint()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetWindowTint(NativePointer);
        }

        public Task<uint> GetWindowTintAsync()
        {
            return _plugin.Schedule(GetWindowTint);
        }

        public void SetDashboardColor(uint value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetDashboardColor(NativePointer, value);
        }

        public Task SetDashboardColorAsync(uint value)
        {
            return _plugin.Schedule(() => SetDashboardColor(value));
        }

        public uint GetDashboardColor()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetDashboardColor(NativePointer);
        }

        public Task<uint> GetDashboardColorAsync()
        {
            return _plugin.Schedule(GetDashboardColor);
        }

        public void SetTrimColor(uint value)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetTrimColor(NativePointer, value);
        }

        public Task SetTrimColorAsync(uint value)
        {
            return _plugin.Schedule(() => SetTrimColor(value));
        }

        public uint GetTrimColor()
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetTrimColor(NativePointer);
        }

        public Task<uint> GetTrimColorAsync()
        {
            return _plugin.Schedule(GetTrimColor);
        }

        public void Explode()
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_Explode(NativePointer);
        }

        public Task ExplodeAsync()
        {
            return _plugin.Schedule(Explode);
        }

        public void Repair()
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_Repair(NativePointer);
        }

        public Task RepairAsync()
        {
            return _plugin.Schedule(Repair);
        }

        public void Spawn(Vector3 position, float heading)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_Spawn(NativePointer, position, heading);
        }

        public Task SpawnAsync(Vector3 position, float heading)
        {
            return _plugin.Schedule(() => Spawn(position, heading));
        }

        public uint GetMod(uint id)
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetMod(NativePointer, id);
        }

        public Task<uint> GetModAsync(uint id)
        {
            return _plugin.Schedule(() => GetMod(id));
        }

        public int GetMod(int id)
        {
            return (int) GetMod((uint) id);
        }

        public async Task<int> GetModAsync(int id)
        {
            return (int) await GetModAsync((uint) id).ConfigureAwait(false);
        }

        public void SetMod(uint id, uint mod)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetMod(NativePointer, id, mod);
        }

        public Task SetModAsync(uint id, uint mod)
        {
            return _plugin.Schedule(() => SetMod(id, mod));
        }

        public void SetMod(int id, int mod)
        {
            SetMod((uint) id, (uint) mod);
        }

        public Task SetModAsync(int id, int mod)
        {
            return SetModAsync((uint) id, (uint) mod);
        }

        public uint GetColor(uint id)
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetColor(NativePointer, id);
        }

        public Task<uint> GetColorAsync(uint id)
        {
            return _plugin.Schedule(() => GetColor(id));
        }

        public int GetColor(int id)
        {
            return (int) GetColor((uint) id);
        }

        public async Task<int> GetColorAsync(int id)
        {
            return (int) await GetColorAsync((uint) id)
                .ConfigureAwait(false);
        }

        public uint GetPaint(uint id)
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetPaint(NativePointer, id);
        }

        public Task<uint> GetPaintAsync(uint id)
        {
            return _plugin.Schedule(() => GetPaint(id));
        }

        public int GetPaint(int id)
        {
            return (int) GetPaint((uint) id);
        }

        public async Task<int> GetPaintAsync(int id)
        {
            return (int) await GetPaintAsync((uint) id)
                .ConfigureAwait(false);
        }

        public void SetColorRgb(Color primaryColor, Color secondaryColor)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetColorRGB(NativePointer, primaryColor.GetNumberValue(), secondaryColor.GetNumberValue());
        }

        public Task SetColorRgbAsync(Color primaryColor, Color secondaryColor)
        {
            return _plugin.Schedule(() => SetColorRgb(primaryColor, secondaryColor));
        }

        public Color GetColorRgb(uint colorSlot)
        {
            CheckExistence();

            return StructConverter.PointerToStruct<ColorRgba>(Rage.Vehicle.Vehicle_GetColorRGB(NativePointer, colorSlot)).FromModColor();
        }

        public Task<Color> GetColorRgbAsync(uint colorSlot)
        {
            return _plugin.Schedule(() => GetColorRgb(colorSlot));
        }

        public Color GetColorRgb(int colorSlot)
        {
            return GetColorRgb((uint) colorSlot);
        }

        public Task<Color> GetColorRgbAsync(int colorSlot)
        {
            return GetColorRgbAsync((uint) colorSlot);
        }

        public void SetColor(uint primary, uint secondary)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetColor(NativePointer, primary, secondary);
        }

        public Task SetColorAsync(uint primary, uint secondary)
        {
            return _plugin.Schedule(() => SetColor(primary, secondary));
        }

        public void SetColor(int primary, int secondary)
        {
            SetColor((uint) primary, (uint) secondary);
        }

        public Task SetColorAsync(int primary, int secondary)
        {
            return SetColorAsync((uint) primary, (uint) secondary);
        }

        public void SetPaint(PaintData primary, PaintData secondary)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetPaint(NativePointer, primary, secondary);
        }

        public Task SetPaintAsync(PaintData primary, PaintData secondary)
        {
            return _plugin.Schedule(() => Rage.Vehicle.Vehicle_SetPaint(NativePointer, primary, secondary));
        }

        public bool GetExtra(uint id)
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetExtra(NativePointer, id);
        }

        public Task<bool> GetExtraAsync(uint id)
        {
            return _plugin.Schedule(() => GetExtra(id));
        }

        public bool GetExtra(int id)
        {
            return GetExtra((uint) id);
        }

        public Task<bool> GetExtraAsync(int id)
        {
            return GetExtraAsync((uint) id);
        }

        public void SetExtra(uint id, bool state)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetExtra(NativePointer, id, state);
        }

        public Task SetExtraAsync(uint id, bool state)
        {
            return _plugin.Schedule(() => SetExtra(id, state));
        }

        public void SetExtra(int id, bool state)
        {
            SetExtra((uint) id, state);
        }

        public Task SetExtraAsync(int id, bool state)
        {
            return SetExtraAsync((uint) id, state);
        }

        public IReadOnlyCollection<IPlayer> GetOccupants()
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_GetOccupants(NativePointer, out var playerPointers, out var size);

            return ArrayHelper.ConvertFromIntPtr(playerPointers, size, p => _plugin.PlayerPool[p]);
        }

        public Task<IReadOnlyCollection<IPlayer>> GetOccupantsAsync()
        {
            return _plugin.Schedule(GetOccupants);
        }

        public IPlayer GetOccupant(int seat)
        {
            CheckExistence();

            return _plugin.PlayerPool[Rage.Vehicle.Vehicle_GetOccupant(NativePointer, seat)];
        }

        public Task<IPlayer> GetOccupantAsync(int seat)
        {
            return _plugin.Schedule(() => GetOccupant(seat));
        }

        public void SetOccupant(int seat, IPlayer player)
        {
            Contract.NotNull(player, nameof(player));
            CheckExistence();

            Rage.Vehicle.Vehicle_SetOccupant(NativePointer, seat, player.NativePointer);
        }

        public Task SetOccupantAsync(int seat, IPlayer player)
        {
            return _plugin.Schedule(() => SetOccupant(seat, player));
        }

        public bool IsStreamed(IPlayer forPlayer)
        {
            Contract.NotNull(forPlayer, nameof(forPlayer));
            CheckExistence();

            return Rage.Vehicle.Vehicle_IsStreamed(NativePointer, forPlayer.NativePointer);
        }

        public Task<bool> IsStreamedAsync(IPlayer forPlayer)
        {
            return _plugin.Schedule(() => IsStreamed(forPlayer));
        }

        public IReadOnlyCollection<IPlayer> GetStreamedPlayers()
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_GetStreamed(NativePointer, out var playerPointers, out var size);

            return ArrayHelper.ConvertFromIntPtr(playerPointers, size, x => _plugin.PlayerPool[x]);
        }

        public Task<IReadOnlyCollection<IPlayer>> GetStreamedPlayersAsync()
        {
            return _plugin.Schedule(GetStreamedPlayers);
        }
    }
}
