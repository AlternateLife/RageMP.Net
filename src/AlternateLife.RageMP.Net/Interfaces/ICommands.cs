using System;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ICommands
    {
        /// <summary>
        /// Registers a simple command directly without dedicated handler class.
        /// </summary>
        /// <param name="name">name of the command</param>
        /// <param name="callback">callback to call when command was executed</param>
        /// <returns>true if command was registered, false otherwise</returns>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null or empty or <paramref name="callback"/> is null</exception>
        bool Register(string name, CommandDelegate callback);

        /// <summary>
        /// Removes an already existing simple command callback.
        /// </summary>
        /// <param name="callback">callback that was registered before</param>
        /// <exception cref="ArgumentNullException"><paramref name="callback"/> is null</exception>
        void Remove(CommandDelegate callback);

        /// <summary>
        /// Removes an already existing command by name.
        /// </summary>
        /// <param name="name">name to search for</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is empty or null</exception>
        void Remove(string name);

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

    }
}
