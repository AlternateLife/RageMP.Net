using System.Numerics;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ITextLabelPool : IPool<ITextLabel>
    {
        ITextLabel New(Vector3 position, string text, uint font, ColorRgba color, float drawDistance = 20, bool los = false, uint dimension = MP.GlobalDimension);
    }
}
