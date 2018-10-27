using System;
using System.Collections.Generic;
using System.Numerics;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IMarker : IEntity
    {
        /// <summary>
        /// Get or set the color of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        ColorRgba Color { get; set; }

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
        void ShowFor(IEnumerable<IPlayer> players);

        /// <summary>
        /// Hide marker for a list of players.
        /// </summary>
        /// <param name="players">List of players to hide the marker for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void HideFor(IEnumerable<IPlayer> players);
    }
}
