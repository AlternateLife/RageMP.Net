using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal class Vehicle : Entity, IVehicle
    {
        public Quaternion Quaternion => Marshal.PtrToStructure<Quaternion>(Rage.Vehicle.Vehicle_GetQuaternion(NativePointer));

        public float Heading => Rage.Vehicle.Vehicle_GetHeading(NativePointer);
        public float MovableState => Rage.Vehicle.Vehicle_GetMovableState(NativePointer);

        public IVehicle Trailer => MP.InternalVehicles[Rage.Vehicle.Vehicle_GetTrailer(NativePointer)];
        public IVehicle TraileredBy => MP.InternalVehicles[Rage.Vehicle.Vehicle_GetTraileredBy(NativePointer)];

        public bool IsSirenActive
        {
            get => Rage.Vehicle.Vehicle_IsSirenActive(NativePointer);
            set => Rage.Vehicle.Vehicle_SetSirenActive(NativePointer, value);
        }

        public bool AreHighbeamsActive
        {
            get => Rage.Vehicle.Vehicle_AreHighbeamsActive(NativePointer);
            set => Rage.Vehicle.Vehicle_SetHighbeamsActive(NativePointer, value);
        }

        public bool AreLightsActive
        {
            get => Rage.Vehicle.Vehicle_AreLightsActive(NativePointer);
            set => Rage.Vehicle.Vehicle_SetLightsActive(NativePointer, value);
        }

        public bool AreTaxiLightsActive
        {
            get => Rage.Vehicle.Vehicle_AreTaxiLightsActive(NativePointer);
            set => Rage.Vehicle.Vehicle_SetTaxiLightsActive(NativePointer, value);
        }

        public bool IsEngineActive
        {
            get => Rage.Vehicle.Vehicle_IsEngineActive(NativePointer);
            set => Rage.Vehicle.Vehicle_SetEngineActive(NativePointer, value);
        }

        public bool AreNeonsActive
        {
            get => Rage.Vehicle.Vehicle_AreNeonsActive(NativePointer);
            set => Rage.Vehicle.Vehicle_SetNeonsActive(NativePointer, value);
        }

        public bool IsLocked
        {
            get => Rage.Vehicle.Vehicle_IsLocked(NativePointer);
            set => Rage.Vehicle.Vehicle_SetLocked(NativePointer, value);
        }

        public bool IsHornActive => Rage.Vehicle.Vehicle_IsHornActive(NativePointer);
        public bool IsRocketBoostActive => Rage.Vehicle.Vehicle_IsRocketBoostActive(NativePointer);
        public bool IsBreakActive => Rage.Vehicle.Vehicle_IsBreakActive(NativePointer);
        public bool IsDead => Rage.Vehicle.Vehicle_IsDead(NativePointer);

        public float SteerAngle => Rage.Vehicle.Vehicle_GetSteerAngle(NativePointer);
        public float GasPedalState => Rage.Vehicle.Vehicle_GetGasPedalState(NativePointer);

        public float EngineHealth => Rage.Vehicle.Vehicle_GetEngineHealth(NativePointer);
        public float BodyHealth => Rage.Vehicle.Vehicle_GetBodyHealth(NativePointer);

        public MaterialType MaterialType => (MaterialType) Rage.Vehicle.Vehicle_GetMaterialType(NativePointer);

        public ColorRgba NeonsColor
        {
            get => Marshal.PtrToStructure<ColorRgba>(Rage.Vehicle.Vehicle_GetNeonsColor(NativePointer));
            set => Rage.Vehicle.Vehicle_SetNeonsColor(NativePointer, value.GetRed(), value.GetGreen(), value.GetBlue());
        }

        public string NumberPlate
        {
            get => StringConverter.PointerToString(Rage.Vehicle.Vehicle_GetNumberPlate(NativePointer));
            set
            {
                using (var converter = new StringConverter())
                {
                    Rage.Vehicle.Vehicle_SetNumberPlate(NativePointer, converter.StringToPointer(value));
                }
            }
        }

        public uint Livery
        {
            get => Rage.Vehicle.Vehicle_GetLivery(NativePointer);
            set => Rage.Vehicle.Vehicle_SetLivery(NativePointer, value);
        }

        public uint WheelColor
        {
            get => Rage.Vehicle.Vehicle_GetWheelColor(NativePointer);
            set => Rage.Vehicle.Vehicle_SetWheelColor(NativePointer, value);
        }

        public uint WheenType
        {
            get => Rage.Vehicle.Vehicle_GetWheelType(NativePointer);
            set => Rage.Vehicle.Vehicle_SetWheelType(NativePointer, value);
        }

        public uint NumberPlateType
        {
            get => Rage.Vehicle.Vehicle_GetNumberPlateType(NativePointer);
            set => Rage.Vehicle.Vehicle_SetNumberPlateType(NativePointer, value);
        }

        public uint PearlecentColor
        {
            get => Rage.Vehicle.Vehicle_GetPearlescentColor(NativePointer);
            set => Rage.Vehicle.Vehicle_SetPearlescentColor(NativePointer, value);
        }

        public uint WindowTint
        {
            get => Rage.Vehicle.Vehicle_GetWindowTint(NativePointer);
            set => Rage.Vehicle.Vehicle_SetWindowTint(NativePointer, value);
        }

        public uint DashboardColor
        {
            get => Rage.Vehicle.Vehicle_GetDashboardColor(NativePointer);
            set => Rage.Vehicle.Vehicle_SetDashboardColor(NativePointer, value);
        }

        public uint TrimColor
        {
            get => Rage.Vehicle.Vehicle_GetTrimColor(NativePointer);
            set => Rage.Vehicle.Vehicle_SetTrimColor(NativePointer, value);
        }

        public IReadOnlyCollection<IPlayer> Occupants
        {
            get
            {
                Rage.Vehicle.Vehicle_GetOccupants(NativePointer, out var playerPointers, out var size);

                var players = new List<IPlayer>();

                for (var i = 0; i < (int)size; i++)
                {
                    players.Add(_plugin.PlayerPool[playerPointers[i]]);
                }

                return players;
            }
        }

        public IReadOnlyCollection<IPlayer> StreamedPlayers
        {
            get
            {
                Rage.Vehicle.Vehicle_GetStreamed(NativePointer, out var playerPointers, out var size);

                var players = new List<IPlayer>();

                for (var i = 0; i < (int)size; i++)
                {
                    players.Add(_plugin.PlayerPool[playerPointers[i]]);
                }

                return players;
            }
        }

        internal Vehicle(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Vehicle)
        {
        }

        public void Explode()
        {
            Rage.Vehicle.Vehicle_Explode(NativePointer);
        }

        public void Repair()
        {
            Rage.Vehicle.Vehicle_Repair(NativePointer);
        }

        public void Spawn(Vector3 position, float heading)
        {
            Rage.Vehicle.Vehicle_Spawn(NativePointer, position, heading);
        }

        public uint GetMod(uint id)
        {
            return Rage.Vehicle.Vehicle_GetMod(NativePointer, id);
        }

        public void SetMod(uint id, uint mod)
        {
            Rage.Vehicle.Vehicle_SetMod(NativePointer, id, mod);
        }

        public uint GetColor(uint id)
        {
            return Rage.Vehicle.Vehicle_GetColor(NativePointer, id);
        }

        public uint GetPaint(uint id)
        {
            return Rage.Vehicle.Vehicle_GetPaint(NativePointer, id);
        }

        public void SetColorRgb(ColorRgba primaryColor, ColorRgba secondaryColor)
        {
            Rage.Vehicle.Vehicle_SetColorRGB(NativePointer, primaryColor, secondaryColor);
        }

        public ColorRgba GetColorRgb(uint colorSlot)
        {
            return Marshal.PtrToStructure<ColorRgba>(Rage.Vehicle.Vehicle_GetColorRGB(NativePointer, colorSlot));
        }

        public void SetColor(uint primary, uint secondary)
        {
            Rage.Vehicle.Vehicle_SetColor(NativePointer, primary, secondary);
        }

        public void SetPaint(PaintData primary, PaintData secondary)
        {
            Rage.Vehicle.Vehicle_SetPaint(NativePointer, primary, secondary);
        }

        public bool GetExtra(uint id)
        {
            return Rage.Vehicle.Vehicle_GetExtra(NativePointer, id);
        }

        public void SetExtra(uint id, bool state)
        {
            Rage.Vehicle.Vehicle_SetExtra(NativePointer, id, state);
        }

        public IPlayer GetOccupant(int seat)
        {
            var pointer = Rage.Vehicle.Vehicle_GetOccupant(NativePointer, seat);

            return MP.InternalPlayers[pointer];
        }

        public void SetOccupant(int seat, IPlayer player)
        {
            Contract.NotNull(player, nameof(player));

            Rage.Vehicle.Vehicle_SetOccupant(NativePointer, seat, player.NativePointer);
        }

        public bool IsStreamed(IPlayer forPlayer)
        {
            Contract.NotNull(forPlayer, nameof(forPlayer));

            return Rage.Vehicle.Vehicle_IsStreamed(NativePointer, forPlayer.NativePointer);
        }
    }
}
