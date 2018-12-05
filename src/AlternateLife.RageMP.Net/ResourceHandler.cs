using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Scripting;
using Microsoft.Extensions.DependencyInjection;

namespace AlternateLife.RageMP.Net
{
    internal class ResourceHandler
    {
        private readonly Plugin _plugin;
        private readonly DirectoryInfo _directory;
        private readonly ResourceLoader _resourceLoader;

        private readonly string _resourceName;
        private readonly List<Assembly> _loadedAssemblies = new List<Assembly>();

        private ICollection<IModule> _modules;
        private IServiceProvider _serviceProvider;

        public ResourceHandler(Plugin plugin, DirectoryInfo directory, ResourceLoader resourceLoader)
        {
            _plugin = plugin;
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

            _modules = FindAndCreateModules();

            BuildServiceProvider();

            Log(LogLevel.Info, "Resource successfully prepared!");
        }

        private void BuildServiceProvider()
        {
            if (_modules.Any() == false)
            {
                Log(LogLevel.Warn, "No valid modules were found.");

                return;
            }

            var services = new ServiceCollection();
            var pluginModule = new MainModule();

            pluginModule.ConfigureServices(_plugin, services);

            foreach (var module in _modules)
            {
                module.ConfigureServices(services);
            }

            _serviceProvider = services.BuildServiceProvider();
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

        private ICollection<IModule> FindAndCreateModules()
        {
            var moduleType = typeof(IModule);
            var foundModules = new List<IModule>();

            foreach (var assembly in _loadedAssemblies)
            {
                Type[] types;
                try
                {
                    types = assembly.GetTypes();
                }
                catch (Exception e)
                {
                    Log(LogLevel.Error, $"{_directory.Name}: An error occured during module search in assembly \"{assembly.FullName}\": ", e);

                    if (e is ReflectionTypeLoadException reflectionException)
                    {
                        Log(LogLevel.Error, "Following LoaderExceptions are given:");

                        var loaderExceptions = reflectionException.LoaderExceptions;

                        for (int i = 0; i < loaderExceptions.Length; i++)
                        {
                            Log(LogLevel.Error, $"LoaderException {i + 1} / {loaderExceptions.Length}: ", loaderExceptions[i]);
                        }
                    }

                    continue;
                }

                foreach (var type in types)
                {
                    if (type.IsClass == false || type.IsAbstract || moduleType.IsAssignableFrom(type) == false)
                    {
                        continue;
                    }

                    var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, Type.EmptyTypes, null);

                    if (constructor == null)
                    {
                        Log(LogLevel.Warn, $"Possible type \"{type}\" was found, but no parameterless-constructor is available!");

                        continue;
                    }

                    Log(LogLevel.Debug, $"Module \"{type}\" found, creating...");

                    try
                    {
                        foundModules.Add((IModule) constructor.Invoke(null));
                    }
                    catch (Exception e)
                    {
                        Log(LogLevel.Error, "An error occured during constructor-execution: ", e);
                    }
                }
            }

            return foundModules;
        }

        public async Task Start()
        {
            Log(LogLevel.Info, "Starting resource...");

            IEnumerable<IResource> resources;

            try
            {
                resources = _serviceProvider.GetServices<IResource>();
            }
            catch (Exception e)
            {
                Log(LogLevel.Error, "Failed to startup resource", e);

                return;
            }

            foreach (var resource in resources)
            {
                try
                {
                    await resource
                        .OnStartAsync()
                        .ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    Log(LogLevel.Error, "An error occured during resource startup!", e);

                    return;
                }
            }

            Log(LogLevel.Info, "Resource successfully started!");
        }

        private void Log(LogLevel logLevel, string message, Exception exception = null)
        {
            _plugin.Logger.Log(logLevel, $"{_resourceName}: {message}", exception);
        }

    }
}
