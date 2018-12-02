using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net
{
    internal class ResourceHandler
    {
        private readonly ILogger _logger;
        private readonly DirectoryInfo _directory;
        private readonly ResourceLoader _resourceLoader;

        private readonly string _resourceName;
        private readonly List<Assembly> _loadedAssemblies = new List<Assembly>();

        private IResource _entryPoint;

        public ResourceHandler(ILogger logger, DirectoryInfo directory, ResourceLoader resourceLoader)
        {
            _logger = logger;
            _directory = directory;
            _resourceLoader = resourceLoader;

            _resourceName = _directory.Name;
        }

        public void Prepare()
        {
            Log(LogLevel.Info, "Prepare resource...");

            if (TryLoadAssemblies() == false)
            {
                Log(LogLevel.Warn, "Resource preparation has been aborted!");

                return;
            }

            if (_loadedAssemblies.Any() == false)
            {
                Log(LogLevel.Warn, "Could not find any assembly inside resource folder.");

                return;
            }

            _entryPoint = LoadEntryPoint();

            Log(LogLevel.Info, "Resource successfully prepared!");
        }

        public async Task Start()
        {
            Log(LogLevel.Info, "Starting resource...");

            if (_entryPoint == null)
            {
                Log(LogLevel.Warn, $"Could not find a valid entrypoint-class implementing interface \"{typeof(IResource)}\"!");

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
                Log(LogLevel.Error, "An error occured during resource startup!", e);

                return;
            }

            Log(LogLevel.Info, "Resource successfully started!");
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
                        Log(LogLevel.Warn, $"Skipping assembly \"{file.FullName}\", because an error occured during load!");

                        continue;
                    }

                    _loadedAssemblies.Add(assembly);
                }

                return true;
            }
            catch (Exception e)
            {
                Log(LogLevel.Error, "An error occured during assembly loading:", e);
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
                    Log(LogLevel.Error, $"{_directory.Name}: An error occured during entrypoint search in assembly \"{assembly.FullName}\": ", e);

                    if (e is ReflectionTypeLoadException reflectionException)
                    {
                        Log(LogLevel.Error, "Following LoaderExceptions are given:");

                        var loaderExceptions = reflectionException.LoaderExceptions;

                        for (int i = 0; i < loaderExceptions.Length; i++)
                        {
                            Log(LogLevel.Error, $"LoaderException {i + 1} / {loaderExceptions.Length}: ", loaderExceptions[i]);
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
                        Log(LogLevel.Warn, $"Possible type \"{type}\" was found, but no parameterless-constructor is available!");

                        continue;
                    }

                    Log(LogLevel.Debug, $"Entrypoint \"{type}\" found, executing constructor...");

                    try
                    {
                        return (IResource) constructor.Invoke(null);
                    }
                    catch (Exception e)
                    {
                        Log(LogLevel.Error, "An error occured during constructor-execution: ", e);

                        return null;
                    }
                }
            }

            return null;
        }

        private void Log(LogLevel logLevel, string message, Exception exception = null)
        {
            _logger.Log(logLevel, $"{_resourceName}: {message}", exception);
        }

    }
}
