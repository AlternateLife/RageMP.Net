using System;
using System.Linq;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Helpers.EventDispatcher
{
    internal class AsyncEventDispatcher<TEvent> : EventDispatcher<AsyncEventHandler<TEvent>> where TEvent : System.EventArgs
    {
        public AsyncEventDispatcher(Plugin plugin, string eventIdentifier) : base(plugin, eventIdentifier)
        {
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
                var methodInfo = subscription.Method;

                _plugin.Logger.Error($"An error occured during execution of event \"{_eventIdentifier}\" ({methodInfo.DeclaringType}:{methodInfo.Name})", e);
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
                var methodInfo = subscription.Method;

                _plugin.Logger.Error($"An error occured during execution of event \"{_eventIdentifier}\" ({methodInfo.DeclaringType}:{methodInfo.Name})", e);
            }
        }
    }
}
