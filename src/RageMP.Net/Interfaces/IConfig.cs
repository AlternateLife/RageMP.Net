namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IConfig
    {
        int GetInt(string key, int defaultValue = default(int));
        string GetString(string key, string defaultValue = "");
    }
}
