using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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
        public Quaternion Quaternion
        {
            get
            {
                CheckExistence();

                return Marshal.PtrToStructure<Quaternion>(Rage.Vehicle.Vehicle_GetQuaternion(NativePointer));
            }
        }

        public float Heading
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetHeading(NativePointer);
            }
        }

        public float MovableState
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetMovableState(NativePointer);
            }
        }

        public IVehicle Trailer
        {
            get
            {
                CheckExistence();

                return MP.InternalVehicles[Rage.Vehicle.Vehicle_GetTrailer(NativePointer)];
            }
        }

        public IVehicle TraileredBy
        {
            get
            {
                CheckExistence();

                return MP.InternalVehicles[Rage.Vehicle.Vehicle_GetTraileredBy(NativePointer)];
            }
        }

        public bool IsSirenActive
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_IsSirenActive(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetSirenActive(NativePointer, value);
            }
        }

        public bool AreHighbeamsActive
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_AreHighbeamsActive(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetHighbeamsActive(NativePointer, value);
            }
        }

        public bool AreLightsActive
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_AreLightsActive(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetLightsActive(NativePointer, value);
            }
        }

        public bool AreTaxiLightsActive
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_AreTaxiLightsActive(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetTaxiLightsActive(NativePointer, value);
            }
        }

        public bool IsEngineActive
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_IsEngineActive(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetEngineActive(NativePointer, value);
            }
        }

        public bool AreNeonsActive
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_AreNeonsActive(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetNeonsActive(NativePointer, value);
            }
        }

        public bool IsLocked
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_IsLocked(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetLocked(NativePointer, value);
            }
        }

        public bool IsHornActive
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_IsHornActive(NativePointer);
            }
        }

        public bool IsRocketBoostActive
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_IsRocketBoostActive(NativePointer);
            }
        }

        public bool IsBreakActive
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_IsBreakActive(NativePointer);
            }
        }

        public bool IsDead
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_IsDead(NativePointer);
            }
        }

        public float SteerAngle
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetSteerAngle(NativePointer);
            }
        }

        public float GasPedalState
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetGasPedalState(NativePointer);
            }
        }

        public float EngineHealth
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetEngineHealth(NativePointer);
            }
        }

        public float BodyHealth
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetBodyHealth(NativePointer);
            }
        }

        public MaterialType MaterialType
        {
            get
            {
                CheckExistence();

                return (MaterialType) Rage.Vehicle.Vehicle_GetMaterialType(NativePointer);
            }
        }

        public ColorRgba NeonsColor
        {
            get
            {
                CheckExistence();

                return Marshal.PtrToStructure<ColorRgba>(Rage.Vehicle.Vehicle_GetNeonsColor(NativePointer));
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetNeonsColor(NativePointer, value.GetRed(), value.GetGreen(), value.GetBlue());
            }
        }

        public string NumberPlate
        {
            get
            {
                CheckExistence();

                return StringConverter.PointerToString(Rage.Vehicle.Vehicle_GetNumberPlate(NativePointer));
            }
            set
            {
                CheckExistence();

                using (var converter = new StringConverter())
                {
                    Rage.Vehicle.Vehicle_SetNumberPlate(NativePointer, converter.StringToPointer(value));
                }
            }
        }

        public uint Livery
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetLivery(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetLivery(NativePointer, value);
            }
        }

        public uint WheelColor
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetWheelColor(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetWheelColor(NativePointer, value);
            }
        }

        public uint WheelType
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetWheelType(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetWheelType(NativePointer, value);
            }
        }

        public uint NumberPlateType
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetNumberPlateType(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetNumberPlateType(NativePointer, value);
            }
        }

        public uint PearlecentColor
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetPearlescentColor(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetPearlescentColor(NativePointer, value);
            }
        }

        public uint WindowTint
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetWindowTint(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetWindowTint(NativePointer, value);
            }
        }

        public uint DashboardColor
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetDashboardColor(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetDashboardColor(NativePointer, value);
            }
        }

        public uint TrimColor
        {
            get
            {
                CheckExistence();

                return Rage.Vehicle.Vehicle_GetTrimColor(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Vehicle.Vehicle_SetTrimColor(NativePointer, value);
            }
        }

        public IReadOnlyCollection<IPlayer> StreamedPlayers
        {
            get
            {
                CheckExistence();

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
            CheckExistence();

            Rage.Vehicle.Vehicle_Explode(NativePointer);
        }

        public void Repair()
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_Repair(NativePointer);
        }

        public void Spawn(Vector3 position, float heading)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_Spawn(NativePointer, position, heading);
        }

        public uint GetMod(uint id)
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetMod(NativePointer, id);
        }

        public int GetMod(int id)
        {
            return (int) GetMod((uint) id);
        }

        public void SetMod(uint id, uint mod)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetMod(NativePointer, id, mod);
        }

        public void SetMod(int id, int mod)
        {
            SetMod((uint) id, (uint) mod);
        }

        public uint GetColor(uint id)
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetColor(NativePointer, id);
        }

        public int GetColor(int id)
        {
            return (int) GetColor((uint) id);
        }

        public uint GetPaint(uint id)
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetPaint(NativePointer, id);
        }

        public int GetPaint(int id)
        {
            return (int) GetPaint((uint) id);
        }

        public void SetColorRgb(ColorRgba primaryColor, ColorRgba secondaryColor)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetColorRGB(NativePointer, primaryColor, secondaryColor);
        }

        public ColorRgba GetColorRgb(uint colorSlot)
        {
            CheckExistence();

            return Marshal.PtrToStructure<ColorRgba>(Rage.Vehicle.Vehicle_GetColorRGB(NativePointer, colorSlot));
        }

        public ColorRgba GetColorRgb(int colorSlot)
        {
            return GetColorRgb((uint) colorSlot);
        }

        public void SetColor(uint primary, uint secondary)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetColor(NativePointer, primary, secondary);
        }

        public void SetColor(int primary, int secondary)
        {
            SetColor((uint) primary, (uint) secondary);
        }

        public void SetPaint(PaintData primary, PaintData secondary)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetPaint(NativePointer, primary, secondary);
        }

        public bool GetExtra(uint id)
        {
            CheckExistence();

            return Rage.Vehicle.Vehicle_GetExtra(NativePointer, id);
        }

        public bool GetExtra(int id)
        {
            return GetExtra((uint) id);
        }

        public void SetExtra(uint id, bool state)
        {
            CheckExistence();

            Rage.Vehicle.Vehicle_SetExtra(NativePointer, id, state);
        }

        public void SetExtra(int id, bool state)
        {
            SetExtra((uint) id, state);
        }

        public async Task<IReadOnlyCollection<IPlayer>> GetOccupantsAsync()
        {
            CheckExistence();

            IntPtr playerPointers = IntPtr.Zero;
            ulong size = 0;

            await _plugin
                .Schedule(() => Rage.Vehicle.Vehicle_GetOccupants(NativePointer, out playerPointers, out size))
                .ConfigureAwait(false);

            return ArrayHelper.ConvertIntPtr(playerPointers, size, p => _plugin.PlayerPool[p]);
        }

        public IPlayer GetOccupant(int seat)
        {
            CheckExistence();

            var pointer = Rage.Vehicle.Vehicle_GetOccupant(NativePointer, seat);

            return MP.InternalPlayers[pointer];
        }

        public void SetOccupant(int seat, IPlayer player)
        {
            Contract.NotNull(player, nameof(player));
            CheckExistence();

            Rage.Vehicle.Vehicle_SetOccupant(NativePointer, seat, player.NativePointer);
        }

        public bool IsStreamed(IPlayer forPlayer)
        {
            Contract.NotNull(forPlayer, nameof(forPlayer));
            CheckExistence();

            return Rage.Vehicle.Vehicle_IsStreamed(NativePointer, forPlayer.NativePointer);
        }
    }
}
