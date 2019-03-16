using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlternateLife.RageMP.Net.Helpers
{
    internal class EventDispatcher<TEvent>
    {
        private readonly Plugin _plugin;

        protected readonly HashSet<TEvent> _subscriptions = new HashSet<TEvent>();

        public EventDispatcher(Plugin plugin)
        {
            _plugin = plugin;
        }

        public virtual bool Subscribe(TEvent callback)
        {
            Contract.NotNull(callback, nameof(callback));

            return _subscriptions.Add(callback);
        }

        public virtual bool Unsubscribe(TEvent callback)
        {
            Contract.NotNull(callback, nameof(callback));

            return _subscriptions.Remove(callback);
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
                _plugin.Logger.Error($"An error occured during execution of event {typeof(TEvent)}", e);
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
                _plugin.Logger.Error($"An error occured during execution of event {typeof(TEvent)}", e);
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
                _plugin.Logger.Error($"An error occured during execution of event {typeof(TEvent)}", e);
            }
        }
    }
}
