using System;
using System.Drawing;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ITextLabel : IEntity
    {
        /// <summary>
        /// Get or set the color of the text label.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Color Color { get; set; }

        /// <summary>
        /// Get or set the text of the text label.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null</exception>
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
