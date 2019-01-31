using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ICheckpoint : IEntity
    {
        /// <summary>
        /// Get or set the color of the checkpoint.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Color Color { get; set; }

        /// <summary>
        /// Get or set the direction of the checkpoint.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Vector3 Direction { get; set; }

        /// <summary>
        /// Get or set the radius of the checkpoint.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float Radius { get; set; }

        /// <summary>
        /// Get or set if the checkpoint is visible.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsVisible { get; set; }

        /// <summary>
        /// Show checkpoint for a list of players.
        /// </summary>
        /// <param name="players">List of players to show the checkpoint for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void ShowFor(IEnumerable<IPlayer> players);

        /// <summary>
        /// Hide checkpoint for a list of players.
        /// </summary>
        /// <param name="players">List of players to hide the checkpoint for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void HideFor(IEnumerable<IPlayer> players);
    }
}
