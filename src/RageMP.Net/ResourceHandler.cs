using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
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

        public void Start()
        {
            Console.WriteLine($"Loading resource {_directory.Name}...");

            LoadAssemblies();

            if (_loadedAssemblies.Any() == false)
            {
                Console.WriteLine($"No assemblies in {_directory.Name} found");

                return;
            }

            _entryPoint = LoadEntryPoint();
            if (_entryPoint == null)
            {
                return;
            }

            _entryPoint.OnStart();
        }

        private void LoadAssemblies()
        {
            foreach (var file in _directory.GetFiles("*.dll"))
            {
                _loadedAssemblies.Add(Assembly.LoadFrom(file.FullName));
            }
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
