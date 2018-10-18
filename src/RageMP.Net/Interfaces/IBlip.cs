using System;
using System.Collections.Generic;

namespace RageMP.Net.Interfaces
{
    public interface IBlip : IEntity
    {
        /// <summary>
        /// Get or set draw distance of the blip.
        /// </summary>
        float DrawDistance { get; set; }

        /// <summary>
        /// Get or set rotation of the blip.
        /// </summary>
        new int Rotation { get; set; }

        /// <summary>
        /// Get or set short range flag of the blip.
        /// </summary>
        bool ShortRange { get; set; }

        /// <summary>
        /// Get or set color of the blip.
        /// </summary>
        uint Color { get; set; }

        /// <summary>
        /// Get or set scale of the blip.
        /// </summary>
        float Scale { get; set; }

        /// <summary>
        /// Get or set name of the blip.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Show route for a list of players with given color and scale.
        ///
        /// The color and scale are used for the route, not the blip.
        /// </summary>
        /// <param name="forPlayers">List of players to show the route for</param>
        /// <param name="color">Color of the route</param>
        /// <param name="scale">Scale of the route</param>
        /// <exception cref="ArgumentNullException">forPlayers is null</exception>
        void ShowRoute(IEnumerable<IPlayer> forPlayers, uint color, float scale);

        /// <summary>
        /// Hide route for a list of players.
        /// </summary>
        /// <param name="forPlayers">List of players to hide the route for</param>
        /// <exception cref="ArgumentNullException">forPlayers is null</exception>
        void HideRoute(IEnumerable<IPlayer> forPlayers);
    }
}
