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

        public virtual bool Subscribe(T callback)
        {
            Contract.NotNull(callback, nameof(callback));

            _readerWriterLock.EnterWriteLock();
            try
            {
                return _subscriptions.Add(callback);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

        public virtual bool Unsubscribe(T callback)
        {
            Contract.NotNull(callback, nameof(callback));

            _readerWriterLock.EnterWriteLock();
            try
            {
                return _subscriptions.Remove(callback);
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

        protected bool AnySubscriptions()
        {
            _readerWriterLock.EnterReadLock();
            try
            {
                return _subscriptions.Any();
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
        }

    }
}
