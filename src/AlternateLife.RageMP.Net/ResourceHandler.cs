using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net
{
    internal class ResourceHandler
    {
        private readonly DirectoryInfo _directory;
        private readonly ResourceLoader _resourceLoader;
        private readonly List<Assembly> _loadedAssemblies = new List<Assembly>();
        private IResource _entryPoint;

        public ResourceHandler(DirectoryInfo directory, ResourceLoader resourceLoader)
        {
            _directory = directory;
            _resourceLoader = resourceLoader;
        }

        public void Prepare()
        {
            MP.Logger.Info($"{_directory.Name}: Prepare resource...");

            if (TryLoadAssemblies() == false)
            {
                MP.Logger.Warn($"{_directory.Name}: Resource preparation has been aborted!");

                return;
            }

            if (_loadedAssemblies.Any() == false)
            {
                MP.Logger.Warn($"Could not find any assembly inside resource {_directory.Name}.");

                return;
            }

            _entryPoint = LoadEntryPoint();

            MP.Logger.Info($"{_directory.Name}: Resource successfully prepared!");
        }

        public async Task Start()
        {
            MP.Logger.Info($"{_directory.Name}: Starting resource...");

            if (_entryPoint == null)
            {
                MP.Logger.Warn($"{_directory.Name}: Could not find a valid entrypoint-class implementing interface \"{typeof(IResource)}\"!");

                return;
            }

            try
            {
                await _entryPoint
                    .OnStartAsync()
                    .ConfigureAwait(false);
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
                    var assembly = _resourceLoader.LoadAssembly(file.FullName);
                    if (assembly == null)
                    {
                        MP.Logger.Warn($"Skipping assembly \"{file.FullName}\", because an error occured during load!");

                        continue;
                    }

                    _loadedAssemblies.Add(assembly);
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
                Type[] types;
                try
                {
                    types = assembly.GetTypes();
                }
                catch (Exception e)
                {
                    MP.Logger.Error($"{_directory.Name}: An error occured during entrypoint search in assembly \"{assembly.FullName}\": ");

                    if (e is ReflectionTypeLoadException reflectionException)
                    {
                        MP.Logger.Error($"{_directory.Name}: Following LoaderExceptions are given:");

                        var loaderExceptions = reflectionException.LoaderExceptions;

                        for (int i = 0; i < loaderExceptions.Length; i++)
                        {
                            MP.Logger.Error($"{_directory.Name}: LoaderException {i + 1} / {loaderExceptions.Length}: ", loaderExceptions[i]);
                        }
                    }

                    return null;
                }

                foreach (var type in types)
                {
                    if (type.IsClass == false || type.IsAbstract || resourceInterfaceType.IsAssignableFrom(type) == false)
                    {
                        continue;
                    }

                    var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, Type.EmptyTypes, null);

                    if (constructor == null)
                    {
                        MP.Logger.Warn($"{_directory.Name}: Possible type \"{type}\" was found, but no parameterless-constructor is available!");

                        continue;
                    }

                    try
                    {
                        return (IResource) constructor.Invoke(null);
                    }
                    catch (Exception e)
                    {
                        MP.Logger.Error($"{_directory.Name}: An error occured during constructor-execution: ", e);

                        return null;
                    }
                }
            }

            return null;
        }

    }
}
