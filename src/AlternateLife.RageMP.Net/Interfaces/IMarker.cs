using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IMarker : IEntity
    {
        /// <summary>
        /// Set the color of the marker.
        /// </summary>
        /// <param name="color">New color of the marker</param>
        /// <exception cref="EntityDeletedException">This marker was deleted before</exception>
        Task SetColorAsync(Color color);

        /// <summary>
        /// Get the color of the marker.
        /// </summary>
        /// <returns>Color of the marker</returns>
        /// <exception cref="EntityDeletedException">This marker was deleted before</exception>
        Task<Color> GetColorAsync();

        /// <summary>
        /// Set the direction of the marker.
        /// </summary>
        /// <param name="direction">New direction of the marker</param>
        /// <returns></returns>
        Task SetDirectionAsync(Vector3 direction);

        /// <summary>
        /// Get the direction of the marker.
        /// </summary>
        /// <returns>Direction of the marker</returns>
        /// <exception cref="EntityDeletedException">This marker was deleted before</exception>
        Task<Vector3> GetDirectionAsync();

        /// <summary>
        /// Set the scale of the marker.
        /// </summary>
        /// <param name="scale">New scale of the marker</param>
        /// <exception cref="EntityDeletedException">This marker was deleted before</exception>
        Task SetScaleAsync(float scale);

        /// <summary>
        /// Get or set the scale of the marker.
        /// </summary>
        /// <returns>Scale of the marker</returns>
        /// <exception cref="EntityDeletedException">This marker was deleted before</exception>
        Task<float> GetScaleAsync();

        /// <summary>
        /// Set the visible state of the marker.
        /// </summary>
        /// <param name="visible">New visible state of the marker</param>
        /// <exception cref="EntityDeletedException">This marker was deleted before</exception>
        Task SetVisibleAsync(bool visible);

        /// <summary>
        /// Get the visible state of the marker.
        /// </summary>
        /// <returns>True if the marker is visible, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This marker was deleted before</exception>
        Task<bool> IsVisibleAsync();

        /// <summary>
        /// Show marker for a list of players.
        /// </summary>
        /// <param name="players">List of players to show the marker for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        /// <exception cref="EntityDeletedException">This marker was deleted before</exception>
        Task ShowForAsync(IEnumerable<IPlayer> players);

        /// <summary>
        /// Hide marker for a list of players.
        /// </summary>
        /// <param name="players">List of players to hide the marker for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        /// <exception cref="EntityDeletedException">This marker was deleted before</exception>
        Task HideForAsync(IEnumerable<IPlayer> players);
    }
}
