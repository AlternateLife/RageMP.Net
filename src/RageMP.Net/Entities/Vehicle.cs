using System;
using System.Numerics;
using RageMP.Net.Data;
using RageMP.Net.Enums;
using RageMP.Net.Interfaces;

namespace RageMP.Net.Entities
{
    internal class Vehicle : Entity, IVehicle
    {
        public Quaternion Quaternion { get; }
        public float Heading { get; }
        public float MovableState { get; }
        public IVehicle Trailer { get; }
        public IVehicle TraileredBy { get; }
        public bool IsSirenActive { get; set; }
        public bool IsHornActive { get; }
        public bool AreHighbeamsActive { get; set; }
        public bool AreLightsActive { get; set; }
        public bool AreTaxiLightsActive { get; set; }
        public bool IsEngineActive { get; set; }
        public bool IsRocketBoostActive { get; }
        public bool IsBreakActive { get; }
        public bool AreNeonsActive { get; set; }
        public bool IsLocked { get; }
        public bool IsDead { get; }
        public float SteerAngle { get; }
        public float GasPedalState { get; }
        public float EngineHealth { get; set; }
        public float BodyHealth { get; set; }
        public MaterialType MaterialType { get; }
        public string NumberPlate { get; set; }
        public uint Livery { get; set; }
        public uint WheelColor { get; set; }
        public uint WheenType { get; set; }
        public uint NumberPlateType { get; set; }
        public uint PearlecentColor { get; set; }
        public uint WindowTint { get; set; }
        public uint DashboardColor { get; set; }
        public uint TrimColor { get; set; }

        internal Vehicle(IntPtr nativePointer) : base(nativePointer, EntityType.Vehicle)
        {
        }

        public void Explode()
        {
            throw new NotImplementedException();
        }

        public void Repair()
        {
            throw new NotImplementedException();
        }

        public void Spawn(Vector3 position, float heading)
        {
            throw new NotImplementedException();
        }

        public uint GetMod(uint id)
        {
            throw new NotImplementedException();
        }

        public void SetMod(uint id, uint mod)
        {
            throw new NotImplementedException();
        }

        public void SetNeonsColor(uint r, uint g, uint b)
        {
            throw new NotImplementedException();
        }

        public uint GetColor(uint id)
        {
            throw new NotImplementedException();
        }

        public uint GetPaint(uint id)
        {
            throw new NotImplementedException();
        }

        public void SetColorRgb(ColorRgb primaryColor, ColorRgb secondaryColor)
        {
            throw new NotImplementedException();
        }

        public void SetColor(uint primary, uint seconary)
        {
            throw new NotImplementedException();
        }

        public void SetPaint(PaintData pimary, PaintData secondary)
        {
            throw new NotImplementedException();
        }
    }
}
