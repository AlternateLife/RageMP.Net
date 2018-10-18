using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Data;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface ITextLabelPool : IPool<ITextLabel>
    {
        /// <summary>
        /// Create a new text label.
        /// </summary>
        /// <param name="position">Position of the text label</param>
        /// <param name="text">Text of the text label</param>
        /// <param name="font">Font of the text label</param>
        /// <param name="color">Color of the text label</param>
        /// <param name="drawDistance">Draw distance of the text label</param>
        /// <param name="los">Line of sight state of the text label</param>
        /// <param name="dimension">Dimension of the text label</param>
        /// <returns>New text label instance</returns>
        Task<ITextLabel> NewAsync(Vector3 position, string text, uint font, ColorRgba color, float drawDistance = 20, bool los = false, uint dimension = MP.GlobalDimension);
    }
}
