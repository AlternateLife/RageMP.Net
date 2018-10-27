using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ITextLabel : IEntity
    {
        /// <summary>
        /// Get or set the color of the text label.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        ColorRgba Color { get; set; }

        /// <summary>
        /// Get or set the text of the text label.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string Text { get; set; }

        /// <summary>
        /// Get or set the line of sight state of the text label.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool LOS { get; set; }

        /// <summary>
        /// Get or set the draw distance of the text label.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float DrawDistance { get; set; }

        /// <summary>
        /// Get or set the font of the text label.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint Font { get; set; }

    }
}
