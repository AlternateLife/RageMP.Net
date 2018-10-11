using System;
using RageMP.Net.Scripting;

namespace RageMP.Net.Example
{
    public class ExampleResource : IResource
    {
        public void OnStart()
        {
            Console.WriteLine($"{nameof(ExampleResource)}: {nameof(OnStart)}");
        }

        public void OnStop()
        {
            Console.WriteLine($"{nameof(ExampleResource)}: {nameof(OnStop)}");
        }
    }
}
