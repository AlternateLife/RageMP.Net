using RageMP.Net.Data;

namespace RageMP.Net.Interfaces
{
    public interface ITextLabel : IEntity
    {
        /// <summary>
        /// Get or set the color of the text label.
        /// </summary>
        ColorRgba Color { get; set; }

        /// <summary>
        /// Get or set the text of the text label.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Get or set the line of sight state of the text label.
        /// </summary>
        bool LOS { get; set; }

        /// <summary>
        /// Get or set the draw distance of the text label.
        /// </summary>
        float DrawDistance { get; set; }

        /// <summary>
        /// Get or set the font of the text label.
        /// </summary>
        uint Font { get; set; }

    }
}
