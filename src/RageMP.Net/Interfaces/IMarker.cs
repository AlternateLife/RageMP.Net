using System;
using System.Collections.Generic;
using System.Numerics;
using RageMP.Net.Data;

namespace RageMP.Net.Interfaces
{
    public interface IMarker : IEntity
    {
        /// <summary>
        /// Get or set the color of the entity.
        /// </summary>
        ColorRgba Color { get; set; }

        /// <summary>
        /// Get or set the direction of the entity.
        /// </summary>
        Vector3 Direction { get; set; }

        /// <summary>
        /// Get or set the scale of the entity.
        /// </summary>
        float Scale { get; set; }

        /// <summary>
        /// Get or set the visible state of the entity.
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// Show marker for a list of players.
        /// </summary>
        /// <param name="players">List of players to show the marker for</param>
        /// <exception cref="ArgumentNullException">Players is null</exception>
        void ShowFor(IEnumerable<IPlayer> players);

        /// <summary>
        /// Hide marker for a list of players.
        /// </summary>
        /// <param name="players">List of players to hide the marker for</param>
        /// <exception cref="ArgumentNullException">Players is null</exception>
        void HideFor(IEnumerable<IPlayer> players);
    }
}
