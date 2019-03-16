using System.Linq;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Helpers
{
    internal class NativeAsyncEventDispatcher<TNative, TEvent> : AsyncEventDispatcher<TEvent>
    {
        private readonly EventType _type;
        private readonly TNative _nativeCallback;
        private readonly bool _forceRegistration;

        public NativeAsyncEventDispatcher(Plugin plugin, EventType type, TNative nativeCallback, bool forceRegistration = false) : base(plugin)
        {
            _type = type;
            _nativeCallback = nativeCallback;
            _forceRegistration = forceRegistration;

            if (_forceRegistration)
            {
                Rage.Events.RegisterEventHandler((int) _type, Marshal.GetFunctionPointerForDelegate(_nativeCallback));
            }
        }

        public override bool Subscribe(TEvent callback)
        {
            var wasEmpty = _subscriptions.Any() == false;
            var wasAdded = base.Subscribe(callback);

            if (_forceRegistration || wasAdded == false || wasEmpty == false)
            {
                return true;
            }

            Rage.Events.RegisterEventHandler((int) _type, Marshal.GetFunctionPointerForDelegate(_nativeCallback));

            return true;
        }

        public override bool Unsubscribe(TEvent callback)
        {
            var wasRemoved = base.Unsubscribe(callback);

            if (_forceRegistration || wasRemoved == false || _subscriptions.Any())
            {
                return true;
            }

            Rage.Events.UnregisterEventHandler((int) _type);

            return true;
        }
    }
}
