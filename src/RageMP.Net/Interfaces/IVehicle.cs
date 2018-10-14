using System.Collections.Generic;
using System.Numerics;
using RageMP.Net.Data;
using RageMP.Net.Enums;

namespace RageMP.Net.Interfaces
{
    public interface IVehicle : IEntity
    {
        Quaternion Quaternion { get; }
        float Heading { get; }
        float MovableState { get; }

        IVehicle Trailer { get; }
        IVehicle TraileredBy { get; }

        bool IsSirenActive { get; set; }
        bool IsHornActive { get; }
        bool AreHighbeamsActive { get; set; }
        bool AreLightsActive { get; set; }
        bool AreTaxiLightsActive { get; set; }
        bool IsEngineActive { get; set; }
        bool IsRocketBoostActive { get; }
        bool IsBreakActive { get; }
        bool AreNeonsActive { get; set; }

        bool IsLocked { get; set; }
        bool IsDead { get; }

        float SteerAngle { get; }
        float GasPedalState { get; }

        float EngineHealth { get; set; }
        float BodyHealth { get; set; }

        MaterialType MaterialType { get; }

        string NumberPlate { get; set; }
        uint Livery { get; set; }
        uint WheelColor { get; set; }
        uint WheenType { get; set; }
        uint NumberPlateType { get; set; }
        uint PearlecentColor { get; set; }
        uint WindowTint { get; set; }
        uint DashboardColor { get; set; }
        uint TrimColor { get; set; }

        IReadOnlyCollection<IPlayer> Occupants { get; }

        void Explode();
        void Repair();
        void Spawn(Vector3 position, float heading);

        uint GetMod(uint id);
        void SetMod(uint id, uint mod);

        void SetNeonsColor(uint red, uint green, uint blue);
        uint GetColor(uint id);
        uint GetPaint(uint id);

        void SetColorRgb(ColorRgba primaryColor, ColorRgba secondaryColor);
        void SetColor(uint primary, uint seconary);
        void SetPaint(PaintData pimary, PaintData secondary);

        bool GetExtra(uint id);
        void SetExtra(uint id, bool state);

        IPlayer GetOccupant(int seat);
        void SetOccupant(int seat, IPlayer player);
    }
}
