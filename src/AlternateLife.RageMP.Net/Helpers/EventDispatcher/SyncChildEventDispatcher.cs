using System;
using AlternateLife.RageMP.Net.Enums;

namespace AlternateLife.RageMP.Net.Helpers.EventDispatcher
{
    internal class SyncChildEventDispatcher<TEvent> : SyncEventDispatcher<TEvent> where TEvent : System.EventArgs
    {
        private readonly SyncEventDispatcher<TEvent> _parentDispatcher;
        private readonly Func<TEvent, bool> _condition;

        internal SyncChildEventDispatcher(Plugin plugin, EventType eventType,
            SyncEventDispatcher<TEvent> parentDispatcher, Func<TEvent, bool> condition = null)
            : this(plugin, eventType.ToString(), parentDispatcher, condition)
        {

        }
        internal SyncChildEventDispatcher(Plugin plugin, string eventIdentifier,
            SyncEventDispatcher<TEvent> parentDispatcher, Func<TEvent, bool> condition = null)
            : base(plugin, eventIdentifier)
        {
            _parentDispatcher = parentDispatcher;
            _condition = condition;
        }

        public override bool Subscribe(EventHandler<TEvent> callback, out bool isFirstSubscriber)
        {
            var wasAdded = base.Subscribe(callback, out isFirstSubscriber);

            if (wasAdded == false || isFirstSubscriber == false)
            {
                return wasAdded;
            }

            if (_parentDispatcher.Subscribe(OnEventCall, out _) == false)
            {
                Unsubscribe(callback, out _);

                return false;
            }

            return true;
        }

        public override bool Unsubscribe(EventHandler<TEvent> callback, out bool wasLastSubscriber)
        {
            var wasRemoved = base.Unsubscribe(callback, out wasLastSubscriber);

            if (wasRemoved == false || wasLastSubscriber == false)
            {
                return wasRemoved;
            }

            if (_parentDispatcher.Unsubscribe(OnEventCall, out _) == false)
            {
                Subscribe(callback, out _);

                return false;
            }

            return true;
        }

        private void OnEventCall(object sender, TEvent eventargs)
        {
            if (_condition != null && _condition(eventargs) == false)
            {
                return;
            }

            Call(sender, eventargs);
        }
    }
}
