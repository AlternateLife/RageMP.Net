using AlternateLife.RageMP.Net.Data;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IWorld
    {
        TimeData Time { get; set; }
        string Weather { get; set; }
        bool AreTrafficLightsLocked { get; set; }
        int TrafficLightsState { get; set; }

        void SetWeatherTransition(string weather, float time = 0.5f);

        void RequestIpl(string ipl);
        void RemoveIpl(string ipl);
    }
}
