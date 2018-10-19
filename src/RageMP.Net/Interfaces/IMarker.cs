using System.Collections.Generic;
using System.Numerics;
using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IMarker : IEntity
    {
        ColorRgba Color { get; set; }
        Vector3 Direction { get; set; }
        float Scale { get; set; }
        bool IsVisible { get; set; }

        void ShowFor(ICollection<IPlayer> players);
        void HideFor(ICollection<IPlayer> players);
    }
}
