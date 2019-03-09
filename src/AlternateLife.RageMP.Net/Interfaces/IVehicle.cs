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
        /// <returns>Quaternion rotation of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<Quaternion> GetQuaternionAsync();

        /// <summary>
        /// Get the heading of the vehicle.
        /// </summary>
        /// <returns>Heading of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetHeadingAsync();

        /// <summary>
        /// Get the movable state of the vehicle.
        /// </summary>
        /// <returns>Movable state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetMovableStateAsync();

        /// <summary>
        /// Get the trailer instance of the vehicle.
        /// </summary>
        /// <returns>Trailer of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<IVehicle> GetTrailerAsync();

        /// <summary>
        /// Get the trailered by instance of the vehicle.
        /// </summary>
        /// <returns>Trailered vehicle of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<IVehicle> GetTraileredByAsync();

        /// <summary>
        /// Set the siren state of the vehicle.
        /// </summary>
        /// <param name="active">New siren state of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetSirenActiveAsync(bool active);

        /// <summary>
        /// Get the siren state of the vehicle.
        /// </summary>
        /// <returns>Siren state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsSirenActiveAsync();

        /// <summary>
        /// Get the horn state of the vehicle.
        /// </summary>
        /// <returns>Horn state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsHornActiveAsync();

        /// <summary>
        /// Set the highbeams state of the vehicle.
        /// </summary>
        /// <param name="active">New highbeams state of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetHighbeamsActiveAsync(bool active);

        /// <summary>
        /// Get the highbeams state of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> AreHighbeamsActiveAsync();

        /// <summary>
        /// Set the lights state of the vehicle.
        /// </summary>
        /// <param name="active">New lights state of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetLightsActiveAsync(bool active);

        /// <summary>
        /// Get the lights state of the vehicle.
        /// </summary>
        /// <returns>Lights state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> AreLightsActiveAsync();

        /// <summary>
        /// Set the taxi lights state of the vehicle.
        /// </summary>
        /// <param name="active">New taxi lights state of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetTaxiLightsActiveAsync(bool active);

        /// <summary>
        /// Get the taxi lights state of the vehicle.
        /// </summary>
        /// <returns>Taxi lights state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> AreTaxiLightsActiveAsync();

        /// <summary>
        /// Set the engine state of the vehicle.
        /// </summary>
        /// <returns>New engine state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetEngineActiveAsync(bool active);

        /// <summary>
        /// Get the engine state of the vehicle.
        /// </summary>
        /// <returns>Engine state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsEngineActiveAsync();

        /// <summary>
        /// Get the rocket boost state of the vehicle.
        /// </summary>
        /// <returns>Rocket boost state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsRocketBoostActiveAsync();

        /// <summary>
        /// Get the break state of the vehicle.
        /// </summary>
        /// <returns>Break state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsBreakActiveAsync();

        /// <summary>
        /// Set the neons state of the vehicle.
        /// </summary>
        /// <param name="active">New neons state of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetNeonsActiveAsync(bool active);

        /// <summary>
        /// Get or set the neons state of the vehicle.
        /// </summary>
        /// <returns>Neons state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> AreNeonsActiveAsync();

        /// <summary>
        /// Set the lock state of the vehicle.
        /// </summary>
        /// <param name="locked">New lock state of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetLockedAsync(bool locked);

        /// <summary>
        /// Get the lock state of the vehicle.
        /// </summary>
        /// <returns>Lock state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsLockedAsync();

        /// <summary>
        /// Get if the vehicle is dead.
        /// </summary>
        /// <returns>True if the vehicle is dead, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsDeadAsync();

        /// <summary>
        /// Get the steering angle of the vehicle.
        /// </summary>
        /// <returns>Steering angle of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetSteerAngleAsync();

        /// <summary>
        /// Get the gas pedal state of the vehicle.
        /// </summary>
        /// <returns>Gas pedal state of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetGasPedalStateAsync();

        /// <summary>
        /// Get the engine health of the vehicle.
        /// </summary>
        /// <returns>Engine health of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetEngineHealthAsync();

        /// <summary>
        /// Get the body health of the vehicle.
        /// </summary>
        /// <returns>Body health of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetBodyHealthAsync();

        /// <summary>
        /// Get the material type of the vehicle.
        /// </summary>
        /// <returns>Material type of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<MaterialType> GetMaterialTypeAsync();

        /// <summary>
        /// Set the neons color of the vehicle.
        /// </summary>
        /// <param name="color">New neons color of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetNeonsColorAsync(Color color);

        /// <summary>
        /// Get the neons color of the vehicle.
        /// </summary>
        /// <returns>Neons color of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<Color> GetNeonsColorAsync();

        /// <summary>
        /// Set the number plate of the vehicle.
        /// </summary>
        /// <param name="numberPlate">New number plate of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null</exception>
        Task SetNumberPlateAsync(string numberPlate);

        /// <summary>
        /// Get the number plate of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<string> GetNumberPlateAsync();

        /// <summary>
        /// Set the livery of the vehicle.
        /// </summary>
        /// <param name="livery">Livery of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetLiveryAsync(uint livery);

        /// <summary>
        /// Get the livery of the vehicle.
        /// </summary>
        /// <returns>Livery of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetLiveryAsync();

        /// <summary>
        /// Set the wheel color of the vehicle.
        /// </summary>
        /// <param name="color">New wheel color of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetWheelColorAsync(uint color);

        /// <summary>
        /// Get the wheel color of the vehicle.
        /// </summary>
        /// <returns>Wheel color of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetWheelColorAsync();

        /// <summary>
        /// Set the wheel type of the vehicle.
        /// </summary>
        /// <param name="wheelType">New wheel type of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetWheelTypeAsync(uint wheelType);

        /// <summary>
        /// Get the wheel type of the vehicle.
        /// </summary>
        /// <returns>Wheel type of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetWheelTypeAsync();

        /// <summary>
        /// Set the number plate type of the vehicle.
        /// </summary>
        /// <param name="type">New number plate type of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetNumberPlateTypeAsync(uint type);

        /// <summary>
        /// Get the number plate type of the vehicle.
        /// </summary>
        /// <returns>Number plate type of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetNumberPlateTypeAsync();

        /// <summary>
        /// Set the pearlescent color of the vehicle.
        /// </summary>
        /// <param name="color">New pearlescent color of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetPearlescentColorAsync(uint color);

        /// <summary>
        /// Get the pearlescent color of the vehicle.
        /// </summary>
        /// <returns>Pearlescent color of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetPearlescentColorAsync();

        /// <summary>
        /// Set the window tint of the vehicle.
        /// </summary>
        /// <param name="tint">New window tint of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetWindowTintAsync(uint tint);

        /// <summary>
        /// Get the window tint of the vehicle.
        /// </summary>
        /// <returns>Window tint of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetWindowTintAsync();

        /// <summary>
        /// Set the dashboard color of the vehicle.
        /// </summary>
        /// <param name="color">Dashboard color of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetDashboardColorAsync(uint color);

        /// <summary>
        /// Get the dashboard color of the vehicle.
        /// </summary>
        /// <returns>Dashboard color of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetDashboardColorAsync();

        /// <summary>
        /// Set the trim color of the vehicle.
        /// </summary>
        /// <param name="color">New trim color of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetTrimColorAsync(uint color);

        /// <summary>
        /// Get the trim color of the vehicle.
        /// </summary>
        /// <returns>Trim color of the vehicle</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetTrimColorAsync();

        /// <summary>
        /// Explode the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task ExplodeAsync();

        /// <summary>
        /// Repair the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task RepairAsync();

        /// <summary>
        /// Spawn the vehicle at given position.
        /// </summary>
        /// <param name="position">Position to spawn the vehicle at</param>
        /// <param name="heading">Heading to spawn the vehicle with</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SpawnAsync(Vector3 position, float heading);

        /// <summary>
        /// Get the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <returns>Value of the modification <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetModAsync(uint id);

        /// <summary>
        /// Get the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <returns>Value of the modification <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<int> GetModAsync(int id);

        /// <summary>
        /// Set the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <param name="mod">Value of the modification <paramref name="id" /></param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetModAsync(uint id, uint mod);

        /// <summary>
        /// Set the value of a modification slot.
        /// </summary>
        /// <param name="id">Slot of the modification</param>
        /// <param name="mod">Value of the modification <paramref name="id" /></param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetModAsync(int id, int mod);

        /// <summary>
        /// Get color number of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the color</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetColorAsync(uint id);

        /// <summary>
        /// Get color number of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the color</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<int> GetColorAsync(int id);

        /// <summary>
        /// Get paint of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the paint</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetPaintAsync(uint id);

        /// <summary>
        /// Get paint of the given color slot.
        /// </summary>
        /// <param name="id">Slot of the paint</param>
        /// <returns>Value of the color <paramref name="id" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<int> GetPaintAsync(int id);

        /// <summary>
        /// Set the color of the vehicle.
        /// </summary>
        /// <param name="primaryColor">Primary rgb color of the vehicle</param>
        /// <param name="secondaryColor">Secondary rgb color of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetColorRgbAsync(Color primaryColor, Color secondaryColor);

        /// <summary>
        /// Get the color of the given color slot.
        /// </summary>
        /// <param name="colorSlot">Slot of the color</param>
        /// <returns><see cref="Color" /> of the vehicle at the given <paramref name="colorSlot" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<Color> GetColorRgbAsync(uint colorSlot);

        /// <summary>
        /// Get the color of the given color slot.
        /// </summary>
        /// <param name="colorSlot">Slot of the color</param>
        /// <returns><see cref="Color" /> of the vehicle at the given <paramref name="colorSlot" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<Color> GetColorRgbAsync(int colorSlot);

        /// <summary>
        /// Set the primary and secondary color of the vehicle.
        /// </summary>
        /// <param name="primary">Primary color number of the vehicle</param>
        /// <param name="secondary">Secondary color number of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetColorAsync(uint primary, uint secondary);

        /// <summary>
        /// Set the primary and secondary color of the vehicle.
        /// </summary>
        /// <param name="primary">Primary color number of the vehicle</param>
        /// <param name="secondary">Secondary color number of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetColorAsync(int primary, int secondary);

        /// <summary>
        /// Set the primary and secondary paint of the vehicle.
        /// </summary>
        /// <param name="primary">Primary paint of the vehicle</param>
        /// <param name="secondary">Secondary paint of the vehicle</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetPaintAsync(PaintData primary, PaintData secondary);

        /// <summary>
        /// Check if the extra is set on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <returns>True if the <paramref name="id" /> is set, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> GetExtraAsync(uint id);

        /// <summary>
        /// Check if the extra is set on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <returns>True if the <paramref name="id" /> is set, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> GetExtraAsync(int id);

        /// <summary>
        /// Set the extra on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <param name="state">State of the extra</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetExtraAsync(uint id, bool state);

        /// <summary>
        /// Set the extra on the vehicle.
        /// </summary>
        /// <param name="id">Slot of the extra</param>
        /// <param name="state">State of the extra</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetExtraAsync(int id, bool state);

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
        Task<IPlayer> GetOccupantAsync(int seat);

        /// <summary>
        /// Set player on given seat in the vehicle.
        /// </summary>
        /// <param name="seat">Seat of the vehicle</param>
        /// <param name="player">Player to place on the seat</param>
        /// <exception cref="ArgumentNullException"><paramref name="player" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetOccupantAsync(int seat, IPlayer player);

        /// <summary>
        /// Check if the vehicle is streamed for given player.
        /// </summary>
        /// <param name="forPlayer">Player to check for</param>
        /// <returns>True if the vehicle is streamed for given <paramref name="forPlayer" />, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsStreamedAsync(IPlayer forPlayer);

        /// <summary>
        /// Get all streamed players for the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<IReadOnlyCollection<IPlayer>> GetStreamedPlayersAsync();
    }
}
