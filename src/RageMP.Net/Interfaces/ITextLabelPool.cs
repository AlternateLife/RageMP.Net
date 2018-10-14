using System.Numerics;
using RageMP.Net.Data;

namespace RageMP.Net.Interfaces
{
    public interface ITextLabelPool : IPool<ITextLabel>
    {
        ITextLabel New(Vector3 position, string text, uint font, ColorRgba color, float drawDistance, bool los, uint dimension);
    }
}
