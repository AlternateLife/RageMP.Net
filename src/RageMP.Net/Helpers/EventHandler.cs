using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using RageMP.Net.Enums;
using RageMP.Net.Native;

namespace RageMP.Net.Helpers
{
    internal class EventHandler<TNative, TEvent>
    {
        private readonly EventType _type;
        private readonly TNative _nativeCallback;
        private readonly HashSet<TEvent> _subscriptions = new HashSet<TEvent>();

        public EventHandler(EventType type, TNative nativeCallback)
        {
            _type = type;
            _nativeCallback = nativeCallback;
        }

        public void Subscribe(TEvent callback)
        {
            var wasEmpty = _subscriptions.Any() == false;

            if (_subscriptions.Add(callback) == false || wasEmpty == false)
            {
                return;
            }

            Rage.Events.RegisterEventHandler((int) _type, Marshal.GetFunctionPointerForDelegate(_nativeCallback));
        }

        public void Unsubscribe(TEvent callback)
        {
            if (_subscriptions.Remove(callback) == false || _subscriptions.Any())
            {
                return;
            }

            Rage.Events.UnregisterEventHandler((int) _type);
        }

        public void Call(Action<TEvent> callback)
        {
            foreach (var subscription in _subscriptions)
            {
                try
                {
                    callback(subscription);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
