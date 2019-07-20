using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AlternateLife.RageMP.Net.Helpers.EventDispatcher
{
    internal abstract class EventDispatcher<T>
    {
        protected readonly Plugin _plugin;

        private readonly HashSet<T> _subscriptions = new HashSet<T>();
        private readonly ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();

        protected readonly string _eventIdentifier;

        internal EventDispatcher(Plugin plugin, string eventIdentifier)
        {
            _plugin = plugin;
            _eventIdentifier = eventIdentifier;
        }

        public virtual bool Subscribe(T callback, out bool isFirstSubscriber)
        {
            Contract.NotNull(callback, nameof(callback));

            _readerWriterLock.EnterWriteLock();
            try
            {
                isFirstSubscriber = _subscriptions.Any() == false;

                return _subscriptions.Add(callback);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        public virtual bool Unsubscribe(T callback, out bool wasLastSubscriber)
        {
            Contract.NotNull(callback, nameof(callback));

            _readerWriterLock.EnterWriteLock();
            try
            {
                var result = _subscriptions.Remove(callback);

                wasLastSubscriber = _subscriptions.Any() == false;

                return result;
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        protected bool TryGetSubscriptions(out IReadOnlyCollection<T> subscriptions)
        {
            _readerWriterLock.EnterReadLock();
            try
            {
                subscriptions = _subscriptions.ToList();

                return subscriptions.Any();
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
        }

        public void ClearSubscriptions()
        {
            foreach (var subscription in _subscriptions.Reverse())
            {
                Unsubscribe(subscription, out _);
            }
        }
    }
}
