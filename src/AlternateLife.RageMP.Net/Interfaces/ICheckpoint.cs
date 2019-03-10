using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ICheckpoint : IEntity
    {
        /// <summary>
        /// Set the color of the checkpoint.
        /// </summary>
        /// <param name="color">New color of the checkpoint</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetColor(Color color);

        /// <summary>
        /// Set the color of the checkpoint.
        /// </summary>
        /// <param name="color">New color of the checkpoint</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetColorAsync(Color color);

        /// <summary>
        /// Get the color of the checkpoint.
        /// </summary>
        /// <returns>Color of the checkpoint</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Color GetColor();

        /// <summary>
        /// Get the color of the checkpoint.
        /// </summary>
        /// <returns>Color of the checkpoint</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<Color> GetColorAsync();

        /// <summary>
        /// Set the direction of the checkpoint.
        /// </summary>
        /// <param name="direction">New direction of the checkpoint</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetDirection(Vector3 direction);

        /// <summary>
        /// Set the direction of the checkpoint.
        /// </summary>
        /// <param name="direction">New direction of the checkpoint</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetDirectionAsync(Vector3 direction);

        /// <summary>
        /// Get the direction of the checkpoint.
        /// </summary>
        /// <returns>Direction of the checkpoint</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Vector3 GetDirection();

        /// <summary>
        /// Get the direction of the checkpoint.
        /// </summary>
        /// <returns>Direction of the checkpoint</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<Vector3> GetDirectionAsync();

        /// <summary>
        /// Set the radius of the checkpoint.
        /// </summary>
        /// <param name="radius">Radius of the checkpoint</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetRadius(float radius);

        /// <summary>
        /// Set the radius of the checkpoint.
        /// </summary>
        /// <param name="radius">Radius of the checkpoint</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetRadiusAsync(float radius);

        /// <summary>
        /// Get the radius of the checkpoint.
        /// </summary>
        /// <returns>Radius of the checkpoint</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetRadius();

        /// <summary>
        /// Get the radius of the checkpoint.
        /// </summary>
        /// <returns>Radius of the checkpoint</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetRadiusAsync();

        /// <summary>
        /// Set if the checkpoint is visible.
        /// </summary>
        /// <param name="visible">New visible state of the checkpoint</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetVisible(bool visible);

        /// <summary>
        /// Set if the checkpoint is visible.
        /// </summary>
        /// <param name="visible">New visible state of the checkpoint</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetVisibleAsync(bool visible);

        /// <summary>
        /// Get if the checkpoint is visible.
        /// </summary>
        /// <returns>Visible state of the checkpoint</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsVisible();

        /// <summary>
        /// Get if the checkpoint is visible.
        /// </summary>
        /// <returns>Visible state of the checkpoint</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsVisibleAsync();

        /// <summary>
        /// Show checkpoint for a list of players.
        /// </summary>
        /// <param name="players">List of players to show the checkpoint for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void ShowFor(IEnumerable<IPlayer> players);

        /// <summary>
        /// Show checkpoint for a list of players.
        /// </summary>
        /// <param name="players">List of players to show the checkpoint for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task ShowForAsync(IEnumerable<IPlayer> players);

        /// <summary>
        /// Hide checkpoint for a list of players.
        /// </summary>
        /// <param name="players">List of players to hide the checkpoint for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void HideFor(IEnumerable<IPlayer> players);

        /// <summary>
        /// Hide checkpoint for a list of players.
        /// </summary>
        /// <param name="players">List of players to hide the checkpoint for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task HideForAsync(IEnumerable<IPlayer> players);
    }
}
