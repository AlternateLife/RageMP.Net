using System;
using System.Drawing;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ITextLabel : IEntity
    {
        /// <summary>
        /// Set the color of the text label.
        /// </summary>
        /// <param name="color">New color of the text label</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetColorAsync(Color color);

        /// <summary>
        /// Get the color of the text label.
        /// </summary>
        /// <returns>Color of the text label</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<Color> GetColorAsync();

        /// <summary>
        /// Set the text of the text label.
        /// </summary>
        /// <param name="text">New text of the text label</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is null</exception>
        Task SetTextAsync(string text);

        /// <summary>
        /// Get the text of the text label.
        /// </summary>
        /// <returns>Text of the text label</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<string> GetTextAsync();

        /// <summary>
        /// Set the line of sight state of the text label.
        /// </summary>
        /// <param name="los">New line of sight state of the text label</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetLOSAsync(bool los);

        /// <summary>
        /// Get the line of sight state of the text label.
        /// </summary>
        /// <returns>Line of sight state of the text label</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> GetLOSAsync();

        /// <summary>
        /// Set the draw distance of the text label.
        /// </summary>
        /// <param name="drawDistance">New draw distance of the text label</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetDrawDistanceAsync(float drawDistance);

        /// <summary>
        /// Get the draw distance of the text label.
        /// </summary>
        /// <returns>New draw distance of the text label</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetDrawDistanceAsync();

        /// <summary>
        /// Set the font of the text label.
        /// </summary>
        /// <param name="font">New font of the text label</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetFontAsync(uint font);

        /// <summary>
        /// Get the font of the text label.
        /// </summary>
        /// <returns>Font of the text label</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetFontAsync();

    }
}
