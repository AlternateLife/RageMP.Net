using System;
using System.Collections.Generic;
using System.Numerics;
using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ICheckpoint : IEntity
    {
        /// <summary>
        /// Get or set the color of the checkpoint.
        /// </summary>
        ColorRgba Color { get; set; }

        /// <summary>
        /// Get or set the direction of the checkpoint.
        /// </summary>
        Vector3 Direction { get; set; }

        /// <summary>
        /// Get or set the radius of the checkpoint.
        /// </summary>
        float Radius { get; set; }

        /// <summary>
        /// Get or set if the checkpoint is visible.
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// Show checkpoint for a list of players.
        /// </summary>
        /// <param name="players">List of players to show the checkpoint for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        void ShowFor(IEnumerable<IPlayer> players);

        /// <summary>
        /// Hide checkpoint for a list of players.
        /// </summary>
        /// <param name="players">List of players to hide the checkpoint for</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null</exception>
        void HideFor(IEnumerable<IPlayer> players);
    }
}
