using System;
using System.Linq;

namespace AlternateLife.RageMP.Net.Helpers.EventDispatcher
{
    internal class SyncEventDispatcher<TEvent> : EventDispatcher<EventHandler<TEvent>> where TEvent : System.EventArgs
    {
        public SyncEventDispatcher(Plugin plugin, string eventIdentifier) : base(plugin, eventIdentifier)
        {
        }

        public void Call(object sender, TEvent eventArgs)
        {
            Contract.NotNull(sender, nameof(sender));
            Contract.NotNull(eventArgs, nameof(eventArgs));

            if(TryGetSubscriptions(out var subscriptions) == false)
            {
                return;
            }

            foreach (var subscription in subscriptions)
            {
                try
                {
                    subscription(sender, eventArgs);
                }
                catch (Exception e)
                {
                    var methodInfo = subscription.Method;

                    _plugin.Logger.Error($"An error occured during execution of event \"{_eventIdentifier}\" ({methodInfo.DeclaringType}:{methodInfo.Name})", e);
                }
            }
        }
    }
}
