using System.Collections.Generic;

namespace AlternateLife.RageMP.Net.Helpers.EventDispatcher
{
    internal abstract class EventDispatcher<T>
    {
        protected readonly Plugin _plugin;

        protected readonly HashSet<T> _subscriptions = new HashSet<T>();

        internal EventDispatcher(Plugin plugin)
        {
            _plugin = plugin;
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
