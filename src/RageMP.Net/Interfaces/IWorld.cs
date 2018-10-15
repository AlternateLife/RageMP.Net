using RageMP.Net.Data;

namespace RageMP.Net.Interfaces
{
    public interface IWorld
    {
        TimeData Time { get; set; }
        string Weather { get; set; }
        bool AreTrafficLightsLocked { get; set; }
        int TrafficLightsState { get; set; }

        void SetWeatherTransition(string weather, float time);

        void RequestIpl(string ipl);
        void RemoveIpl(string ipl);
    }
}