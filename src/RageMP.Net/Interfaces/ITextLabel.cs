using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ITextLabel : IEntity
    {
        ColorRgba Color { get; set; }
        string Text { get; set; }
        bool LOS { get; set; }
        float DrawDistance { get; set; }
        uint Font { get; set; }

    }
}
