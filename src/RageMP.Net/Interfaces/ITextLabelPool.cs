using System.Numerics;
using RageMP.Net.Data;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface ITextLabelPool : IPool<ITextLabel>
    {
        ITextLabel New(Vector3 position, string text, uint font, ColorRgba color, float drawDistance = 150, bool los = false, uint dimension = MP.GlobalDimension);
    }
}
