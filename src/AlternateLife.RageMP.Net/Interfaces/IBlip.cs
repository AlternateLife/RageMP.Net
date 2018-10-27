using System;
using System.Collections.Generic;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IBlip : IEntity
    {
        /// <summary>
        /// Get or set draw distance of the blip.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float DrawDistance { get; set; }

        /// <summary>
        /// Get or set rotation of the blip.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        new int Rotation { get; set; }

        /// <summary>
        /// Get or set short range flag of the blip.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool ShortRange { get; set; }

        /// <summary>
        /// Get or set color of the blip.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint Color { get; set; }

        /// <summary>
        /// Get or set scale of the blip.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float Scale { get; set; }

        /// <summary>
        /// Get or set name of the blip.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string Name { get; set; }

        /// <summary>
        /// Show route for a list of players with given color and scale.
        ///
        /// The <paramref name="color" /> and <paramref name="scale" /> are used for the route, not the blip.
        /// </summary>
        /// <param name="forPlayers">List of players to show the route for</param>
        /// <param name="color">Color of the route</param>
        /// <param name="scale">Scale of the route</param>
        /// <exception cref="ArgumentNullException"><paramref name="forPlayers" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void ShowRoute(IEnumerable<IPlayer> forPlayers, uint color, float scale);

        /// <summary>
        /// Show route for a list of players with given color and scale.
        ///
        /// The <paramref name="color" /> and <paramref name="scale" /> are used for the route, not the blip.
        /// </summary>
        /// <param name="forPlayers">List of players to show the route for</param>
        /// <param name="color">Color of the route</param>
        /// <param name="scale">Scale of the route</param>
        /// <exception cref="ArgumentNullException"><paramref name="forPlayers" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void ShowRoute(IEnumerable<IPlayer> forPlayers, int color, float scale);

        /// <summary>
        /// Hide route for a list of players.
        /// </summary>
        /// <param name="forPlayers">List of players to hide the route for</param>
        /// <exception cref="ArgumentNullException"><paramref name="forPlayers" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void HideRoute(IEnumerable<IPlayer> forPlayers);
    }
}
