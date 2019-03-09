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
        /// Get or set the color of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Color Color { get; set; }

        /// <summary>
        /// Get or set the direction of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Vector3 Direction { get; set; }

        /// <summary>
        /// Get or set the scale of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float Scale { get; set; }

        /// <summary>
        /// Get or set the visible state of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsVisible { get; set; }

        /// <summary>
        /// Show marker for a list of players.
        /// </summary>
        /// <param name="players">List of players to show the marker for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task ShowForAsync(IEnumerable<IPlayer> players);

        /// <summary>
        /// Hide marker for a list of players.
        /// </summary>
        /// <param name="players">List of players to hide the marker for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task HideForAsync(IEnumerable<IPlayer> players);
    }
}
