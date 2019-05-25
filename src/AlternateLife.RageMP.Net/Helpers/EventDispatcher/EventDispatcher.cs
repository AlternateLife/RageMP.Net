using System.Collections.Generic;

namespace AlternateLife.RageMP.Net.Helpers.EventDispatcher
{
    internal abstract class EventDispatcher<T>
    {
        protected readonly Plugin _plugin;

        protected readonly HashSet<T> _subscriptions = new HashSet<T>();

        protected readonly string _eventIdentifier;

        internal EventDispatcher(Plugin plugin, string eventIdentifier)
        {
            _plugin = plugin;
            _eventIdentifier = eventIdentifier;
        }

        public virtual bool Subscribe(T callback)
        {
            Contract.NotNull(callback, nameof(callback));

            return _subscriptions.Add(callback);
        }

        public virtual bool Unsubscribe(T callback)
        {
            Contract.NotNull(callback, nameof(callback));

            return _subscriptions.Remove(callback);
        }
    }
}
