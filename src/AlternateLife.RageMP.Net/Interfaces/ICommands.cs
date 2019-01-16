using System;
using System.Collections.Generic;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ICommands
    {
        /// <summary>
        /// Checks if specified event exists.
        /// </summary>
        /// <param name="name">name to check</param>
        /// <returns>true if command was registered before, false otherwise</returns>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null or empty</exception>
        bool DoesCommandExist(string name);
        
        /// <summary>
        /// Returns a collection of already created commands.
        /// </summary>
        /// <returns>collection of command names</returns>
        IReadOnlyCollection<string> GetRegisteredCommands();
        
        /// <summary>
        /// Registers a new commandhandler with command methods
        /// </summary>
        /// <param name="handler"><see cref="ICommandHandler"/> to register</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is null</exception>
        void RegisterHandler(ICommandHandler handler);

        /// <summary>
        /// Removes an already registered commandhandler
        /// </summary>
        /// <param name="handler"><see cref="ICommandHandler"/> to remove</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is null</exception>
        void RemoveHandler(ICommandHandler handler);
        
        /// <summary>
        /// Removes an already existing command by name.
        /// </summary>
        /// <param name="name">name to search for</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is empty or null</exception>
        void Remove(string name);
    }
}