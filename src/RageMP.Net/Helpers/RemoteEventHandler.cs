using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using RageMP.Net.Data;
using RageMP.Net.Native;
using RageMP.Net.Scripting;

namespace RageMP.Net.Helpers
{
    internal class RemoteEventHandler
    {
        private readonly Plugin _plugin;

        private readonly ConcurrentDictionary<string, HashSet<PlayerRemoteEventDelegate>> _subscriptions = new ConcurrentDictionary<string, HashSet<PlayerRemoteEventDelegate>>();

        internal RemoteEventHandler(Plugin plugin)
        {
            _plugin = plugin;
        }

        public void Subscribe(string eventName, PlayerRemoteEventDelegate callback)
        {
            if (_subscriptions.TryGetValue(eventName, out var eventSubscriptions) == false)
            {
                eventSubscriptions = new HashSet<PlayerRemoteEventDelegate>();

                if (_subscriptions.TryAdd(eventName, eventSubscriptions) == false)
                {
                    MP.Logger.Error($"Unable to create subscription list for event {eventName}");

                    return;
                }

                Rage.Multiplayer.Multiplayer_AddRemoteEventHandler(_plugin.NativeMultiplayer, eventName, (playerPointer, arguments) => OnPlayerRemoteEvent(playerPointer, eventName, arguments));
            }

            eventSubscriptions.Add(callback);
        }

        private void OnPlayerRemoteEvent(IntPtr playerPointer, string eventName, ArgumentsData data)
        {
            if (_subscriptions.TryGetValue(eventName, out var eventSubscriptions) == false)
            {
                MP.Logger.Warn($"Unregistered remote event '{eventName}'");

                return;
            }

            var player = _plugin.PlayerPool[playerPointer];
            var arguments = data.ToArguments();

            foreach (var subscription in eventSubscriptions)
            {
                try
                {
                    subscription(player, eventName, arguments);
                }
                catch (Exception e)
                {
                    MP.Logger.Error($"An error occured during exception of {eventName}", e);
                }
            }
        }
    }
}
