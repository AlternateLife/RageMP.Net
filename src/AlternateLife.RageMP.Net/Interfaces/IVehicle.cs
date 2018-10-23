using System;
using System.Collections.Generic;
using System.Numerics;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IVehicle : IEntity
    {
        /// <summary>
        /// Get the quaternion rotation of the vehicle.
        /// </summary>
        Quaternion Quaternion { get; }

        /// <summary>
        /// Get the heading of the vehicle.
        /// </summary>
        float Heading { get; }

        /// <summary>
        /// Get the movable state of the vehicle.
        /// </summary>
        float MovableState { get; }

        /// <summary>
        /// Get the trailer instance of the vehicle.
        /// </summary>
        IVehicle Trailer { get; }

        /// <summary>
        /// Get the trailered by instance of the vehicle.
        /// </summary>
        IVehicle TraileredBy { get; }

        /// <summary>
        /// Get or set the siren state of the vehicle.
        /// </summary>
        bool IsSirenActive { get; set; }

        /// <summary>
        /// Get or set the horn state of the vehicle.
        /// </summary>
        bool IsHornActive { get; }

        /// <summary>
        /// Get or set the highbeams state of the vehicle.
        /// </summary>
        bool AreHighbeamsActive { get; set; }

        /// <summary>
        /// Get or set the lights state of the vehicle.
        /// </summary>
        bool AreLightsActive { get; set; }

        /// <summary>
        /// Get or set the taxi lights state of the vehicle.
        /// </summary>
        bool AreTaxiLightsActive { get; set; }

        /// <summary>
        /// Get or set the engine state of the vehicle.
        /// </summary>
        bool IsEngineActive { get; set; }

        /// <summary>
        /// Get the rocket boost state of the vehicle.
        /// </summary>
        bool IsRocketBoostActive { get; }

        /// <summary>
        /// Get the break state of the vehicle.
        /// </summary>
        bool IsBreakActive { get; }

        /// <summary>
        /// Get or set the neons state of the vehicle.
        /// </summary>
        bool AreNeonsActive { get; set; }

        /// <summary>
        /// Get or set the lock state of the vehicle.
        /// </summary>
        bool IsLocked { get; set; }

        /// <summary>
        /// Get if the vehicle is dead.
        /// </summary>
        bool IsDead { get; }

        /// <summary>
        /// Get the steering angle of the vehicle.
        /// </summary>
        float SteerAngle { get; }

        /// <summary>
        /// Get the gas padel state of the vehicle.
        /// </summary>
        float GasPedalState { get; }

        /// <summary>
        /// Get the engine health of the vehicle.
        /// </summary>
        float EngineHealth { get; }

        /// <summary>
        /// Get the body health of the vehicle.
        /// </summary>
        float BodyHealth { get; }

        /// <summary>
        /// Get the material type of the vehicle.
        /// </summary>
        MaterialType MaterialType { get; }

        /// <summary>
        /// Get or set the neons color of the vehicle.
        /// </summary>
        ColorRgba NeonsColor { get; set; }

        /// <summary>
        /// Get or set the number plate of the vehicle.
        /// </summary>
        string NumberPlate { get; set; }

        /// <summary>
        /// Get or set the livery of the vehicle.
        /// </summary>
        uint Livery { get; set; }

        /// <summary>
        /// Get or set the wheel color of the vehicle.
        /// </summary>
        uint WheelColor { get; set; }

        /// <summary>
        /// Get or set the wheel type of the vehicle.
        /// </summary>
        uint WheelType { get; set; }

        /// <summary>
        /// Get or set the number plate type of the vehicle.
        /// </summary>
        uint NumberPlateType { get; set; }

        /// <summary>
        /// Get or set the pearlescent color of the vehicle.
        /// </summary>
        uint PearlecentColor { get; set; }

        /// <summary>
        /// Get or set the window tint of the vehicle.
        /// </summary>
        uint WindowTint { get; set; }

        /// <summary>
        /// Get or set the dashboard color of the vehicle.
        /// </summary>
        uint DashboardColor { get; set; }

        /// <summary>
        /// Get or set the trim color of the vehicle.
        /// </summary>
        uint TrimColor { get; set; }

        /// <summary>
        /// Get all occupants in the vehicle.
        /// </summary>
        IReadOnlyCollection<IPlayer> Occupants { get; }

        /// <summary>
        /// Get all streamed players for the vehicle.
        /// </summary>
        IReadOnlyCollection<IPlayer> StreamedPlayers { get; }

        /// <summary>
        /// Explode the vehicle.
        /// </summary>
        void Explode();

        /// <summary>
        /// Repair the vehicle.
        /// </summary>
        void Repair();

        /// <summary>
        /// Spawn the vehicle at given position.
        /// </summary>
        /// <param name="position">Position to spawn the vehicle at</param>
        /// <param name="heading">Heading to spawn the vehicle with</param>
        void Spawn(Vector3 position, float heading);

        /// <summary>
        /// Get the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <returns>Value of the modification <paramref name="id" /></returns>
        uint GetMod(uint id);

        /// <summary>
        /// Get the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <returns>Value of the modification <paramref name="id" /></returns>
        int GetMod(int id);

        /// <summary>
        /// Set the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <param name="mod">Value of the modification <paramref name="id" /></param>
        void SetMod(uint id, uint mod);

        /// <summary>
        /// Set the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <param name="mod">Value of the modification <paramref name="id" /></param>
        void SetMod(int id, int mod);

        /// <summary>
        /// Get color number of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the color</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        uint GetColor(uint id);

        /// <summary>
        /// Get color number of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the color</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        int GetColor(int id);

        /// <summary>
        /// Get paint of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the paint</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        uint GetPaint(uint id);

        /// <summary>
        /// Get paint of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the paint</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        int GetPaint(int id);

        /// <summary>
        /// Set the color of the vehicle.
        /// </summary>
        /// <param name="primaryColor">Primary rgb color of the vehicle</param>
        /// <param name="secondaryColor">Secondary rgb color of the vehicle</param>
        void SetColorRgb(ColorRgba primaryColor, ColorRgba secondaryColor);

        /// <summary>
        /// Get the color of the given color slot.
        /// </summary>
        /// <param name="colorSlot">Slot of the color</param>
        /// <returns><see cref="ColorRgba" /> of the vehicle at the given <paramref name="colorSlot" /></returns>
        ColorRgba GetColorRgb(uint colorSlot);

        /// <summary>
        /// Get the color of the given color slot.
        /// </summary>
        /// <param name="colorSlot">Slot of the color</param>
        /// <returns><see cref="ColorRgba" /> of the vehicle at the given <paramref name="colorSlot" /></returns>
        ColorRgba GetColorRgb(int colorSlot);

        /// <summary>
        /// Set the primary and secondary color of the vehicle.
        /// </summary>
        /// <param name="primary">Primary color number of the vehicle</param>
        /// <param name="secondary">Secondary color number of the vehicle</param>
        void SetColor(uint primary, uint secondary);

        /// <summary>
        /// Set the primary and secondary color of the vehicle.
        /// </summary>
        /// <param name="primary">Primary color number of the vehicle</param>
        /// <param name="secondary">Secondary color number of the vehicle</param>
        void SetColor(int primary, int secondary);

        /// <summary>
        /// Set the primary and secondary paint of the vehicle.
        /// </summary>
        /// <param name="primary">Primary paint of the vehicle</param>
        /// <param name="secondary">Secondary paint of the vehicle</param>
        void SetPaint(PaintData primary, PaintData secondary);

        /// <summary>
        /// Check if the extra is set on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <returns>True if the <paramref name="id" /> is set, otherwise false</returns>
        bool GetExtra(uint id);

        /// <summary>
        /// Check if the extra is set on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <returns>True if the <paramref name="id" /> is set, otherwise false</returns>
        bool GetExtra(int id);

        /// <summary>
        /// Set the extra on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <param name="state">State of the extra</param>
        void SetExtra(uint id, bool state);

        /// <summary>
        /// Set the extra on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <param name="state">State of the extra</param>
        void SetExtra(int id, bool state);

        /// <summary>
        /// Get player on given seat in the vehicle.
        /// </summary>
        /// <param name="seat">Seat of the vehicle</param>
        /// <returns><see cref="IPlayer" /> on the <paramref name="seat" /> or null if the <paramref name="seat" /> is empty</returns>
        IPlayer GetOccupant(int seat);

        /// <summary>
        /// Set player on given seat in the vehicle.
        /// </summary>
        /// <param name="seat">Seat of the vehicle</param>
        /// <param name="player">Player to place on the seat</param>
        /// <exception cref="ArgumentNullException"><paramref name="player" /> is null</exception>
        void SetOccupant(int seat, IPlayer player);

        /// <summary>
        /// Check if the vehicle is streamed for given player.
        /// </summary>
        /// <param name="forPlayer">Player to check for</param>
        /// <returns>True if the vehicle is streamed for given <paramref name="forPlayer" />, otherwise false</returns>
        bool IsStreamed(IPlayer forPlayer);
    }
}
