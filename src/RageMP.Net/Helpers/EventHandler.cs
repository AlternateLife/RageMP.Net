using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using RageMP.Net.Enums;
using RageMP.Net.Native;
using RageMP.Net.Scripting;

namespace RageMP.Net.Helpers
{
    internal class EventHandler<TNative, TEvent>
    {
        private readonly EventType _type;
        private readonly TNative _nativeCallback;
        private readonly bool _forceRegistration;

        private readonly HashSet<TEvent> _subscriptions = new HashSet<TEvent>();

        public EventHandler(EventType type, TNative nativeCallback, bool forceRegistration = false)
        {
            _type = type;
            _nativeCallback = nativeCallback;
            _forceRegistration = forceRegistration;

            if (_forceRegistration)
            {
                Rage.Events.RegisterEventHandler((int) _type, Marshal.GetFunctionPointerForDelegate(_nativeCallback));
            }
        }

        public void Subscribe(TEvent callback)
        {
            Contract.NotNull(callback, nameof(callback));

            var wasEmpty = _subscriptions.Any() == false;

            if (_forceRegistration || _subscriptions.Add(callback) == false || wasEmpty == false)
            {
                return;
            }

            Rage.Events.RegisterEventHandler((int) _type, Marshal.GetFunctionPointerForDelegate(_nativeCallback));
        }

        public void Unsubscribe(TEvent callback)
        {
            Contract.NotNull(callback, nameof(callback));

            if (_forceRegistration || _subscriptions.Remove(callback) == false || _subscriptions.Any())
            {
                return;
            }

            Rage.Events.UnregisterEventHandler((int) _type);
        }

        public void CallAsync(Func<TEvent, Task> callback)
        {
            Contract.NotNull(callback, nameof(callback));

            if (_subscriptions.Any() == false)
            {
                return;
            }

            Task.Run(() =>
            {
                foreach (var subscription in _subscriptions)
                {
                    ExecuteSubscriptionAsync(subscription, callback);
                }
            });
        }

        private async void ExecuteSubscriptionAsync(TEvent subscription, Func<TEvent, Task> callback)
        {
            try
            {
                await callback(subscription).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                MP.Logger.Error($"An error occured during execution of event {_type}", e);
            }
        }
    }
}
