using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IPlayerPool : IPool<IPlayer>
    {
        /// <summary>
        /// Send chat message to all players.
        /// </summary>
        /// <param name="message">Message to the players</param>
        /// <exception cref="ArgumentNullException"><paramref name="message" /> is null (empty message is allowed)</exception>
        Task BroadcastAsync(string message);

        /// <summary>
        /// Send chat message to all players at given position.
        /// </summary>
        /// <param name="message">Message to the players</param>
        /// <param name="position">Position to search players at</param>
        /// <param name="range">Range to search players in</param>
        /// <param name="dimension">Dimension to search players in</param>
        /// <exception cref="ArgumentNullException"><paramref name="message" /> is null (empty message is allowed)</exception>
        Task BroadcastAsync(string message, Vector3 position, float range, uint dimension = MP.GlobalDimension);

        /// <summary>
        /// Send chat message to all players in given dimension.
        /// </summary>
        /// <param name="message">Message to the players</param>
        /// <param name="dimension">Dimension to search players in</param>
        /// <exception cref="ArgumentNullException"><paramref name="message" /> is null (empty message is allowed)</exception>
        Task BroadcastAsync(string message, uint dimension);

        /// <summary>
        /// Send event to all players.
        /// </summary>
        /// <param name="eventName">Name of the event</param>
        /// <param name="arguments">Arguments of the event</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventName" /> is null or empty</exception>
        Task CallAsync(string eventName, params object[] arguments);

        /// <summary>
        /// Send event to a list of players.
        /// </summary>
        /// <param name="players">List of players to send the event to.</param>
        /// <param name="eventName">Name of the event</param>
        /// <param name="arguments">Arguments of the event</param>
        /// <exception cref="ArgumentNullException"><paramref name="players" /> is null or <paramref name="eventName" /> is null or empty</exception>
        Task CallAsync(IEnumerable<IPlayer> players, string eventName, params object[] arguments);

        /// <summary>
        /// Send event to all players at given position.
        /// </summary>
        /// <param name="position">Position to search players at</param>
        /// <param name="range">Range to search players in</param>
        /// <param name="dimension">Dimension to search players in</param>
        /// <param name="eventName">Name of the event</param>
        /// <param name="arguments">Arguments of the event</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventName" /> is null or empty</exception>
        Task CallAsync(Vector3 position, float range, uint dimension, string eventName, params object[] arguments);

        /// <summary>
        /// Send event to all players in given dimension.
        /// </summary>
        /// <param name="dimension">Dimension to search players in</param>
        /// <param name="eventName">Name of the event</param>
        /// <param name="arguments">Arguments of the event</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventName" /> is null or empty</exception>
        Task CallAsync(uint dimension, string eventName, params object[] arguments);

        /// <summary>
        /// Send native call to all players.
        /// </summary>
        /// <param name="nativeHash">Hash of the native</param>
        /// <param name="arguments">Arguments of the native</param>
        Task InvokeAsync(ulong nativeHash, params object[] arguments);

        /// <summary>
        /// Send native call to a list of players.
        /// </summary>
        /// <param name="players">List of players to send the native to.</param>
        /// <param name="nativeHash">Hash of the native</param>
        /// <param name="arguments">Arguments of the native</param>
        Task InvokeAsync(IEnumerable<IPlayer> players, ulong nativeHash, params object[] arguments);

        /// <summary>
        /// Send native call to all players at given position.
        /// </summary>
        /// <param name="position">Position to search players at</param>
        /// <param name="range">Range to search players in</param>
        /// <param name="dimension">Dimension to search players in</param>
        /// <param name="nativeHash">Hash of the native</param>
        /// <param name="arguments">Arguments of the native</param>
        Task InvokeAsync(Vector3 position, float range, uint dimension, ulong nativeHash, params object[] arguments);

        /// <summary>
        /// Send native call to all players in given dimension.
        /// </summary>
        /// <param name="dimension">Dimension to search players in</param>
        /// <param name="nativeHash">Hash of the native</param>
        /// <param name="arguments">Arguments of the native</param>
        Task InvokeAsync(uint dimension, ulong nativeHash, params object[] arguments);
    }
}
