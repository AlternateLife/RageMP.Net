using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Data;
using RageMP.Net.Scripting;

namespace RageMP.Net.Interfaces
{
    public interface ITextLabelPool : IPool<ITextLabel>
    {
        Task<ITextLabel> NewAsync(Vector3 position, string text, uint font, ColorRgba color, float drawDistance = 20, bool los = false, uint dimension = MP.GlobalDimension);
    }
}
