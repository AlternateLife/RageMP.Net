using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using RageMP.Net.Scripting;

namespace RageMP.Net
{
    internal class ResourceHandler
    {
        private readonly DirectoryInfo _directory;
        private readonly List<Assembly> _loadedAssemblies = new List<Assembly>();
        private IResource _entryPoint;

        public ResourceHandler(DirectoryInfo directory)
        {
            _directory = directory;
        }

        public async Task Start()
        {
            MP.Logger.Info($"{_directory.Name}: Starting resource...");

            if (TryLoadAssemblies() == false)
            {
                MP.Logger.Warn($"{_directory.Name}: Resource startup has been aborted!");

                return;
            }

            if (_loadedAssemblies.Any() == false)
            {
                MP.Logger.Warn($"Could not find any assembly inside resource {_directory.Name}.");

                return;
            }

            _entryPoint = LoadEntryPoint();
            if (_entryPoint == null)
            {
                MP.Logger.Warn($"{_directory.Name}: Could not find the entrypoint-class of type `{typeof(IResource)}`!");

                return;
            }

            try
            {
                await _entryPoint.OnStartAsync();
            }
            catch (Exception e)
            {
                MP.Logger.Error($"{_directory.Name}: An error occured during resource startup!", e);

                return;
            }

            MP.Logger.Info($"{_directory.Name}: Resource successfully started!");
        }

        private bool TryLoadAssemblies()
        {
            try
            {
                foreach (var file in _directory.GetFiles("*.dll"))
                {
                    _loadedAssemblies.Add(Assembly.LoadFrom(file.FullName));
                }

                return true;
            }
            catch (Exception e)
            {
                MP.Logger.Error($"{_directory.Name}: An error occured during assembly loading!", e);
            }

            return false;
        }

        private IResource LoadEntryPoint()
        {
            var resourceInterfaceType = typeof(IResource);

            foreach (var assembly in _loadedAssemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsClass == false || type.IsAbstract || resourceInterfaceType.IsAssignableFrom(type) == false)
                    {
                        continue;
                    }

                    var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, Type.EmptyTypes, null);

                    return (IResource) constructor.Invoke(null);
                }
            }

            return null;
        }

    }
}
