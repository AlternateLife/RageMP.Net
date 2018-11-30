using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Native;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Helpers
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
            var wasAdded = _subscriptions.Add(callback);

            if (_forceRegistration || wasAdded == false || wasEmpty == false)
            {
                return;
            }

            Rage.Events.RegisterEventHandler((int) _type, Marshal.GetFunctionPointerForDelegate(_nativeCallback));
        }

        public void Unsubscribe(TEvent callback)
        {
            Contract.NotNull(callback, nameof(callback));

            var wasRemoved = _subscriptions.Remove(callback);

            if (_forceRegistration || wasRemoved == false || _subscriptions.Any())
            {
                return;
            }

            Rage.Events.UnregisterEventHandler((int) _type);
        }

        public void Call(Action<TEvent> callback)
        {
            Contract.NotNull(callback, nameof(callback));

            if (_subscriptions.Any() == false)
            {
                return;
            }

            foreach (var subscription in _subscriptions)
            {
                ExecuteSubscription(subscription, callback);
            }
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

        public async Task CallAsyncAwaitable(Func<TEvent, Task> callback)
        {
            Contract.NotNull(callback, nameof(callback));

            if (_subscriptions.Any() == false)
            {
                return;
            }

            await Task.Run(async () =>
            {
                foreach (var subscription in _subscriptions)
                {
                    await ExecuteSubscriptionAsyncAwaitable(subscription, callback)
                        .ConfigureAwait(false);
                }
            }).ConfigureAwait(false);
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

        private async Task ExecuteSubscriptionAsyncAwaitable(TEvent subscription, Func<TEvent, Task> callback)
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

        private void ExecuteSubscription(TEvent subscription, Action<TEvent> callback)
        {
            try
            {
                callback(subscription);
            }
            catch (Exception e)
            {
                MP.Logger.Error($"An error occured during execution of event {_type}", e);
            }
        }
    }
}
