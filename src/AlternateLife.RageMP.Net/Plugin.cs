using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Elements.Pools;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;
using AlternateLife.RageMP.Net.Scripting;
using AlternateLife.RageMP.Net.Scripting.ScriptingClasses;

namespace AlternateLife.RageMP.Net
{
    internal class Plugin
    {
        private readonly string _basePath = $"dotnet{Path.DirectorySeparatorChar}";

        private readonly ResourceLoader _resourceLoader;

        internal IntPtr NativeMultiplayer { get; }

        internal EventScripting EventScripting { get; }
        internal PlayerPool PlayerPool { get; }
        internal VehiclePool VehiclePool { get; }
        internal BlipPool BlipPool { get; }
        internal CheckpointPool CheckpointPool { get; }
        internal ColshapePool ColshapePool { get; }
        internal MarkerPool MarkerPool { get; }
        internal ObjectPool ObjectPool { get; }
        internal TextLabelPool TextLabelPool { get; }
        internal Config Config { get; }
        internal World World { get; }
        internal Commands Commands { get; }

        internal Logger Logger { get; }
        internal ArgumentConverter ArgumentConverter { get; }

        internal Dictionary<EntityType, IInternalPool> EntityPoolMapping { get; }
        internal RageTaskScheduler TaskScheduler { get; }
        private int MainThreadId { get; }

        internal Plugin(IntPtr multiplayer)
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            MP.Setup(this);

            NativeMultiplayer = multiplayer;
            MainThreadId = Thread.CurrentThread.ManagedThreadId;

            Logger = new Logger(this);
            ArgumentConverter = new ArgumentConverter(this);

            _resourceLoader = new ResourceLoader(Logger);
            TaskScheduler = new RageTaskScheduler();
            EventScripting = new EventScripting(this);
            Commands = new Commands(this);

            PlayerPool = CreateNativeManager<PlayerPool>(Rage.Multiplayer.Multiplayer_GetPlayerPool);
            VehiclePool = CreateNativeManager<VehiclePool>(Rage.Multiplayer.Multiplayer_GetVehiclePool);
            BlipPool = CreateNativeManager<BlipPool>(Rage.Multiplayer.Multiplayer_GetBlipPool);
            CheckpointPool = CreateNativeManager<CheckpointPool>(Rage.Multiplayer.Multiplayer_GetCheckpointPool);
            ColshapePool = CreateNativeManager<ColshapePool>(Rage.Multiplayer.Multiplayer_GetColshapePool);
            MarkerPool = CreateNativeManager<MarkerPool>(Rage.Multiplayer.Multiplayer_GetMarkerPool);
            ObjectPool = CreateNativeManager<ObjectPool>(Rage.Multiplayer.Multiplayer_GetObjectPool);
            TextLabelPool = CreateNativeManager<TextLabelPool>(Rage.Multiplayer.Multiplayer_GetLabelPool);

            Config = CreateNativeManager<Config>(Rage.Multiplayer.Multiplayer_GetConfig);
            World = CreateNativeManager<World>(Rage.Multiplayer.Multiplayer_GetWorld);

            EntityPoolMapping = new Dictionary<EntityType, IInternalPool>
            {
                { EntityType.Player, PlayerPool },
                { EntityType.Vehicle, VehiclePool },
                { EntityType.Blip, BlipPool },
                { EntityType.Checkpoint, CheckpointPool },
                { EntityType.Colshape, ColshapePool },
                { EntityType.Marker, MarkerPool },
                { EntityType.Object, ObjectPool },
                { EntityType.TextLabel, TextLabelPool }
            };
        }

        private T CreateNativeManager<T>(Func<IntPtr, IntPtr> pointerReceiver) where T : class
        {
            return (T) Activator.CreateInstance(typeof(T), pointerReceiver(NativeMultiplayer), this);
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Fatal($"< ==== UNHANDLED EXCEPTION ==== > {Environment.NewLine} Received an unhandled exception from {sender?.GetType()}: ", (Exception) e.ExceptionObject);
        }

        internal void Prepare()
        {
            _resourceLoader.Prepare();
        }

        internal async Task Start()
        {
            await _resourceLoader
                .Start()
                .ConfigureAwait(false);
        }

        internal Task Schedule(Action action, bool forceSchedule = false)
        {
            if (forceSchedule == false && IsInMainThread())
            {
                try
                {
                    action();

                    return Task.CompletedTask;
                }
                catch (Exception e)
                {
                    return Task.FromException(e);
                }
            }

            return Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler);
        }

        internal Task<T> Schedule<T>(Func<T> action, bool forceSchedule = false)
        {
            if (forceSchedule == false && IsInMainThread())
            {
                try
                {
                    return Task.FromResult(action());
                }
                catch (Exception e)
                {
                    return Task.FromException<T>(e);
                }
            }

            return Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler);
        }

        public bool IsInMainThread()
        {
            return Thread.CurrentThread.ManagedThreadId == MainThreadId;
        }

        internal string GetBasePath(string path)
        {
            return Path.Combine(Environment.CurrentDirectory, Path.Combine(_basePath, path));
        }
    }
}
