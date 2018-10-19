using System.Collections.Generic;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IBlip : IEntity
    {
        float DrawDistance { get; set; }
        new int Rotation { get; set; }
        bool ShortRange { get; set; }
        uint Color { get; set; }
        float Scale { get; set; }
        string Name { get; set; }

        void ShowRoute(ICollection<IPlayer> forPlayers, uint color, float scale);
        void HideRoute(ICollection<IPlayer> forPlayers);
    }
}
