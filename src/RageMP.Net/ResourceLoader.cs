using System.Collections.Generic;
using System.IO;

namespace RageMP.Net
{
    internal class ResourceLoader
    {
        private const string _basePath = "dotnet/resources";

        private readonly Plugin _plugin;

        public ResourceLoader(Plugin plugin)
        {
            _plugin = plugin;
        }

        public void Start()
        {
            foreach (var resource in FindResources())
            {
                resource.Start();
            }
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
