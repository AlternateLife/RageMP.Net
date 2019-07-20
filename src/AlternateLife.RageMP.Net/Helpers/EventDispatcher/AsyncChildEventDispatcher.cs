using System;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Helpers.EventDispatcher
{
    internal class AsyncChildEventDispatcher<TEvent> : AsyncEventDispatcher<TEvent> where TEvent : System.EventArgs
    {
        private readonly AsyncEventDispatcher<TEvent> _parentDispatcher;
        private readonly Func<TEvent, Task<bool>> _condition;

        internal AsyncChildEventDispatcher(Plugin plugin, string eventIdentifier,
            AsyncEventDispatcher<TEvent> parentDispatcher, Func<TEvent, Task<bool>> condition = null) : base(plugin, eventIdentifier)
        {
            _parentDispatcher = parentDispatcher;
            _condition = condition;
        }

        public override bool Subscribe(AsyncEventHandler<TEvent> callback, out bool isFirstSubscriber)
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

        public override bool Unsubscribe(AsyncEventHandler<TEvent> callback, out bool wasLastSubscriber)
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

        private async Task OnEventCall(object sender, TEvent eventargs)
        {
            if (_condition != null && await _condition(eventargs) == false)
            {
                return;
            }

            CallAsync(sender, eventargs);
        }
    }
}
