using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RageMP.Net
{
    internal class ResourceLoader
    {
        private const string _basePath = "dotnet/resources";

        public Task Start()
        {
            var startTasks = new List<Task>();

            foreach (var resource in FindResources())
            {
                startTasks.Add(Task.Run(() => resource.Start()));
            }

            return Task.WhenAll(startTasks);
        }

        private IEnumerable<ResourceHandler> FindResources()
        {
            var directoryFolder = new DirectoryInfo(_basePath);

            foreach (var directory in directoryFolder.GetDirectories())
            {
                yield return new ResourceHandler(directory);
            }
        }

    }
}
