using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IVehicle : IEntity
    {
        /// <summary>
        /// Get the quaternion rotation of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Quaternion Quaternion { get; }

        /// <summary>
        /// Get the heading of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float Heading { get; }

        /// <summary>
        /// Get the movable state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float MovableState { get; }

        /// <summary>
        /// Get the trailer instance of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IVehicle Trailer { get; }

        /// <summary>
        /// Get the trailered by instance of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IVehicle TraileredBy { get; }

        /// <summary>
        /// Get or set the siren state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsSirenActive { get; set; }

        /// <summary>
        /// Get or set the horn state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsHornActive { get; }

        /// <summary>
        /// Get or set the highbeams state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool AreHighbeamsActive { get; set; }

        /// <summary>
        /// Get or set the lights state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool AreLightsActive { get; set; }

        /// <summary>
        /// Get or set the taxi lights state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool AreTaxiLightsActive { get; set; }

        /// <summary>
        /// Get or set the engine state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsEngineActive { get; set; }

        /// <summary>
        /// Get the rocket boost state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsRocketBoostActive { get; }

        /// <summary>
        /// Get the break state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsBreakActive { get; }

        /// <summary>
        /// Get or set the neons state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool AreNeonsActive { get; set; }

        /// <summary>
        /// Get or set the lock state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsLocked { get; set; }

        /// <summary>
        /// Get if the vehicle is dead.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsDead { get; }

        /// <summary>
        /// Get the steering angle of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float SteerAngle { get; }

        /// <summary>
        /// Get the gas padel state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GasPedalState { get; }

        /// <summary>
        /// Get the engine health of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float EngineHealth { get; }

        /// <summary>
        /// Get the body health of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float BodyHealth { get; }

        /// <summary>
        /// Get the material type of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        MaterialType MaterialType { get; }

        /// <summary>
        /// Get or set the neons color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Color NeonsColor { get; set; }

        /// <summary>
        /// Get or set the number plate of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null</exception>
        string NumberPlate { get; set; }

        /// <summary>
        /// Get or set the livery of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint Livery { get; set; }

        /// <summary>
        /// Get or set the wheel color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint WheelColor { get; set; }

        /// <summary>
        /// Get or set the wheel type of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint WheelType { get; set; }

        /// <summary>
        /// Get or set the number plate type of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint NumberPlateType { get; set; }

        /// <summary>
        /// Get or set the pearlescent color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint PearlescentColor { get; set; }

        /// <summary>
        /// Get or set the window tint of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint WindowTint { get; set; }

        /// <summary>
        /// Get or set the dashboard color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint DashboardColor { get; set; }

        /// <summary>
        /// Get or set the trim color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint TrimColor { get; set; }

        /// <summary>
        /// Explode the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void Explode();

        /// <summary>
        /// Repair the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void Repair();

        /// <summary>
        /// Spawn the vehicle at given position.
        /// </summary>
        /// <param name="position">Position to spawn the vehicle at</param>
        /// <param name="heading">Heading to spawn the vehicle with</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void Spawn(Vector3 position, float heading);

        /// <summary>
        /// Get the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <returns>Value of the modification <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetMod(uint id);

        /// <summary>
        /// Get the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <returns>Value of the modification <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        int GetMod(int id);

        /// <summary>
        /// Set the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <param name="mod">Value of the modification <paramref name="id" /></param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetMod(uint id, uint mod);

        /// <summary>
        /// Set the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <param name="mod">Value of the modification <paramref name="id" /></param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetMod(int id, int mod);

        /// <summary>
        /// Get color number of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the color</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetColor(uint id);

        /// <summary>
        /// Get color number of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the color</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        int GetColor(int id);

        /// <summary>
        /// Get paint of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the paint</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetPaint(uint id);

        /// <summary>
        /// Get paint of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the paint</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        int GetPaint(int id);

        /// <summary>
        /// Set the color of the vehicle.
        /// </summary>
        /// <param name="primaryColor">Primary rgb color of the vehicle</param>
        /// <param name="secondaryColor">Secondary rgb color of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetColorRgb(Color primaryColor, Color secondaryColor);

        /// <summary>
        /// Get the color of the given color slot.
        /// </summary>
        /// <param name="colorSlot">Slot of the color</param>
        /// <returns><see cref="Color" /> of the vehicle at the given <paramref name="colorSlot" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Color GetColorRgb(uint colorSlot);

        /// <summary>
        /// Get the color of the given color slot.
        /// </summary>
        /// <param name="colorSlot">Slot of the color</param>
        /// <returns><see cref="Color" /> of the vehicle at the given <paramref name="colorSlot" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Color GetColorRgb(int colorSlot);

        /// <summary>
        /// Set the primary and secondary color of the vehicle.
        /// </summary>
        /// <param name="primary">Primary color number of the vehicle</param>
        /// <param name="secondary">Secondary color number of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetColor(uint primary, uint secondary);

        /// <summary>
        /// Set the primary and secondary color of the vehicle.
        /// </summary>
        /// <param name="primary">Primary color number of the vehicle</param>
        /// <param name="secondary">Secondary color number of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetColor(int primary, int secondary);

        /// <summary>
        /// Set the primary and secondary paint of the vehicle.
        /// </summary>
        /// <param name="primary">Primary paint of the vehicle</param>
        /// <param name="secondary">Secondary paint of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetPaint(PaintData primary, PaintData secondary);

        /// <summary>
        /// Check if the extra is set on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <returns>True if the <paramref name="id" /> is set, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool GetExtra(uint id);

        /// <summary>
        /// Check if the extra is set on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <returns>True if the <paramref name="id" /> is set, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool GetExtra(int id);

        /// <summary>
        /// Set the extra on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <param name="state">State of the extra</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetExtra(uint id, bool state);

        /// <summary>
        /// Set the extra on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <param name="state">State of the extra</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetExtra(int id, bool state);

        /// <summary>
        /// Get all occupants in the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<IReadOnlyCollection<IPlayer>> GetOccupantsAsync();

        /// <summary>
        /// Get player on given seat in the vehicle.
        /// </summary>
        /// <param name="seat">Seat of the vehicle</param>
        /// <returns><see cref="IPlayer" /> on the <paramref name="seat" /> or null if the <paramref name="seat" /> is empty</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IPlayer GetOccupant(int seat);

        /// <summary>
        /// Set player on given seat in the vehicle.
        /// </summary>
        /// <param name="seat">Seat of the vehicle</param>
        /// <param name="player">Player to place on the seat</param>
        /// <exception cref="ArgumentNullException"><paramref name="player" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetOccupant(int seat, IPlayer player);

        /// <summary>
        /// Check if the vehicle is streamed for given player.
        /// </summary>
        /// <param name="forPlayer">Player to check for</param>
        /// <returns>True if the vehicle is streamed for given <paramref name="forPlayer" />, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsStreamed(IPlayer forPlayer);

        /// <summary>
        /// Get all streamed players for the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<IReadOnlyCollection<IPlayer>> GetStreamedPlayersAsync();
    }
}
