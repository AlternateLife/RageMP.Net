using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net
{
    internal class ResourceLoader
    {
        private readonly ILogger _logger;
        private const string _basePath = "dotnet/resources";

        private readonly Dictionary<string, Assembly> _loadedAssemblies;
        private List<ResourceHandler> _resources;

        internal ResourceLoader(ILogger logger)
        {
            _logger = logger;
            _loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToDictionary(x => x.GetName().FullName, x => x);
        }

        public void Prepare()
        {
            _resources = new List<ResourceHandler>(FindResources());

            foreach (var resource in _resources)
            {
                resource.Prepare();
            }
        }

        public Task Start()
        {
            var startTasks = new List<Task>();

            foreach (var resource in _resources)
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
                yield return new ResourceHandler(_logger, directory, this);
            }
        }

        internal Assembly LoadAssembly(string path)
        {
            var reflectionAssembly = AssemblyName.GetAssemblyName(path);

            if (_loadedAssemblies.TryGetValue(reflectionAssembly.FullName, out var element))
            {
                return element;
            }

            try
            {
                var loadedAssembly = Assembly.LoadFrom(path);

                _loadedAssemblies[loadedAssembly.GetName().FullName] = loadedAssembly;

                return loadedAssembly;
            }
            catch (FileLoadException e)
            {
                _logger.Error($"An error occured while loading assembly \"{path}\": ", e);

                return null;
            }

        }

    }
}
