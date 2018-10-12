using System.Collections.Generic;
using System.Numerics;
using RageMP.Net.Data;

namespace RageMP.Net.Interfaces
{
    public interface ICheckpoint : IEntity
    {
        ColorRgba Color { get; set; }
        Vector3 Direction { get; set; }
        float Radius { get; set; }
        bool IsVisible { get; set; }

        void ShowFor(ICollection<IPlayer> players);
        void HideFor(ICollection<IPlayer> players);
    }
}
