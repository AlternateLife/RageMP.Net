using RageMP.Net.Scripting;

namespace RageMP.Net.Example
{
    public class ExampleResource : IResource
    {
        public void OnStart()
        {
            MP.Logger.Info($"{nameof(ExampleResource)}: {nameof(OnStart)}");
        }

        public void OnStop()
        {
            MP.Logger.Info($"{nameof(ExampleResource)}: {nameof(OnStop)}");
        }
    }
}
