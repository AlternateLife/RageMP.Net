namespace RageMP.Net.Interfaces
{
    public interface IConfig
    {
        int GetInt(string key, int defaultValue);
        string GetString(string key, string defaultValue);
    }
}
