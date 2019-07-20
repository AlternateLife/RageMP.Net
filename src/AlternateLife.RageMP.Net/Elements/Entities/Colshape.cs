using System;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.EventArgs;
using AlternateLife.RageMP.Net.Helpers.EventDispatcher;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal class Colshape : Entity, IColshape
    {

        private readonly AsyncChildEventDispatcher<PlayerColshapeEventArgs> _playerEnterColshape;
        private readonly AsyncChildEventDispatcher<PlayerColshapeEventArgs> _playerExitColshape;

        public event AsyncEventHandler<PlayerColshapeEventArgs> PlayerEnterColshape
        {
            add => _playerEnterColshape.Subscribe(value, out _);
            remove => _playerEnterColshape.Unsubscribe(value, out _);
        }

        public event AsyncEventHandler<PlayerColshapeEventArgs> PlayerExitColshape
        {
            add => _playerExitColshape.Subscribe(value, out _);
            remove => _playerExitColshape.Unsubscribe(value, out _);
        }

        internal Colshape(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Colshape)
        {
            var events = _plugin.EventScripting;

            _playerEnterColshape = new AsyncChildEventDispatcher<PlayerColshapeEventArgs>(_plugin, "PlayerEnterColshape",
                events.PlayerEnterColshapeDispatcher, eventArgs => Task.FromResult(eventArgs.Colshape == this));

            _playerExitColshape = new AsyncChildEventDispatcher<PlayerColshapeEventArgs>(_plugin, "PlayerExitColshape",
                events.PlayerExitColshapeDispatcher, eventArgs => Task.FromResult(eventArgs.Colshape == this));
        }

        public ColshapeType GetShapeType()
        {
            CheckExistence();

            return (ColshapeType) Rage.Colshape.Colshape_GetShapeType(NativePointer);
        }

        public Task<ColshapeType> GetShapeTypeAsync()
        {
            return _plugin.Schedule(GetShapeType);
        }

        public bool IsPointWhithin(Vector3 position)
        {
            CheckExistence();

            return Rage.Colshape.Colshape_IsPointWithin(NativePointer, position);
        }

        public Task<bool> IsPointWhithinAsync(Vector3 position)
        {
            return _plugin.Schedule(() => IsPointWhithin(position));
        }

        public override void Destroy()
        {
            _playerEnterColshape.ClearSubscriptions();
            _playerExitColshape.ClearSubscriptions();

            base.Destroy();
        }
    }
}
