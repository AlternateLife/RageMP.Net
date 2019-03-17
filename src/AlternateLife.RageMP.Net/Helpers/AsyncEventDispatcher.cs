using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Helpers
{
    internal class AsyncEventDispatcher<TEvent> where TEvent : EventArgs
    {
        private readonly Plugin _plugin;

        protected readonly HashSet<AsyncEventHandler<TEvent>> _subscriptions = new HashSet<AsyncEventHandler<TEvent>>();

        public AsyncEventDispatcher(Plugin plugin)
        {
            _plugin = plugin;
        }

        public virtual bool Subscribe(AsyncEventHandler<TEvent> callback)
        {
            Contract.NotNull(callback, nameof(callback));

            return _subscriptions.Add(callback);
        }

        public virtual bool Unsubscribe(AsyncEventHandler<TEvent> callback)
        {
            Contract.NotNull(callback, nameof(callback));

            return _subscriptions.Remove(callback);
        }

        public void CallAsync(object sender, TEvent eventArgs)
        {
            Contract.NotNull(sender, nameof(sender));
            Contract.NotNull(eventArgs, nameof(eventArgs));

            if (_subscriptions.Any() == false)
            {
                return;
            }

            Task.Run(() =>
            {
                foreach (var subscription in _subscriptions)
                {
                    ExecuteSubscriptionAsync(sender, subscription, eventArgs);
                }
            });
        }

        public async Task CallAsyncAwaitable(object sender, TEvent eventArgs)
        {
            Contract.NotNull(sender, nameof(sender));
            Contract.NotNull(eventArgs, nameof(eventArgs));

            if (_subscriptions.Any() == false)
            {
                return;
            }

            await Task.Run(async () =>
            {
                foreach (var subscription in _subscriptions)
                {
                    await ExecuteSubscriptionAsyncAwaitable(sender, subscription, eventArgs)
                        .ConfigureAwait(false);
                }
            }).ConfigureAwait(false);
        }

        private async void ExecuteSubscriptionAsync(object sender, AsyncEventHandler<TEvent> subscription, TEvent eventArgs)
        {
            try
            {
                await subscription(sender, eventArgs).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _plugin.Logger.Error($"An error occured during execution of event {typeof(TEvent)}", e);
            }
        }

        private async Task ExecuteSubscriptionAsyncAwaitable(object sender, AsyncEventHandler<TEvent> subscription, TEvent eventArgs)
        {
            try
            {
                await subscription(sender, eventArgs).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _plugin.Logger.Error($"An error occured during execution of event {typeof(TEvent)}", e);
            }
        }
    }
}
