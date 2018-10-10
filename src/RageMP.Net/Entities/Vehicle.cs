using System;
using System.Numerics;
using System.Runtime.InteropServices;
using RageMP.Net.Data;
using RageMP.Net.Enums;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Entities
{
    internal class Vehicle : Entity, IVehicle
    {
        public Quaternion Quaternion { get; }

        public float Heading => Rage.Vehicle.Vehicle_GetHeading(NativePointer);
        public float MovableState => Rage.Vehicle.Vehicle_GetMovableState(NativePointer);

        public IVehicle Trailer { get; }
        public IVehicle TraileredBy { get; }

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

        public float EngineHealth
        {
            get => Rage.Vehicle.Vehicle_GetEngineHealth(NativePointer);
            set { }
        }

        public float BodyHealth
        {
            get => Rage.Vehicle.Vehicle_GetBodyHealth(NativePointer);
            set { }
        }

        public MaterialType MaterialType => (MaterialType) Rage.Vehicle.Vehicle_GetMaterialType(NativePointer);

        public string NumberPlate
        {
            get => Marshal.PtrToStringAnsi(Rage.Vehicle.Vehicle_GetNumberPlate(NativePointer));
            set => Rage.Vehicle.Vehicle_SetNumberPlate(NativePointer, value);
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

        internal Vehicle(IntPtr nativePointer) : base(nativePointer, EntityType.Vehicle)
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
            throw new NotImplementedException();
        }

        public uint GetMod(uint id)
        {
            return Rage.Vehicle.Vehicle_GetMod(NativePointer, id);
        }

        public void SetMod(uint id, uint mod)
        {
            Rage.Vehicle.Vehicle_SetMod(NativePointer, id, mod);
        }

        public void SetNeonsColor(uint red, uint green, uint blue)
        {
            Rage.Vehicle.Vehicle_SetNeonsColor(NativePointer, red, green, blue);
        }

        public uint GetColor(uint id)
        {
            return Rage.Vehicle.Vehicle_GetColor(NativePointer, id);
        }

        public uint GetPaint(uint id)
        {
            return Rage.Vehicle.Vehicle_GetPaint(NativePointer, id);
        }

        public void SetColorRgb(ColorRgb primaryColor, ColorRgb secondaryColor)
        {
            throw new NotImplementedException();
        }

        public void SetColor(uint primary, uint seconary)
        {
            Rage.Vehicle.Vehicle_SetColor(NativePointer, primary, seconary);
        }

        public void SetPaint(PaintData pimary, PaintData secondary)
        {
            throw new NotImplementedException();
        }

        public bool GetExtra(uint id)
        {
            return Rage.Vehicle.Vehicle_GetExtra(NativePointer, id);
        }

        public void SetExtra(uint id, bool state)
        {
            Rage.Vehicle.Vehicle_SetExtra(NativePointer, id, state);
        }
    }
}
