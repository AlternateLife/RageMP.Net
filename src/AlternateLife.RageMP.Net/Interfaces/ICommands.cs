using System;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ICommands
    {

        /// <summary>
        /// Registers a new commandhandler with command methods
        /// </summary>
        /// <param name="handler"><see cref="ICommandHandler"/> to register</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is null</exception>
        void RegisterCommandHandler(ICommandHandler handler);

        /// <summary>
        /// Removes an already registered commandhandler
        /// </summary>
        /// <param name="handler"><see cref="ICommandHandler"/> to remove</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is null</exception>
        void RemoveCommandHandler(ICommandHandler handler);

    }
}
