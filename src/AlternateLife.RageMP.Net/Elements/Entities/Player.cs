using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.EventArgs;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Helpers.EventDispatcher;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal partial class Player : Entity, IPlayer
    {
        private readonly AsyncChildEventDispatcher<PlayerCommandEventArgs> _commandDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerCommandFailedEventArgs> _commandFailedDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerChatEventArgs> _chatDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerEventArgs> _spawnDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerDamageEventArgs> _damageDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerWeaponChangeEventArgs> _weaponChangeDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerEnterVehicleEventArgs> _startEnterVehicleDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerEnterVehicleEventArgs> _enterVehicleDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerVehicleEventArgs> _startExitVehicleDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerVehicleEventArgs> _exitVehicleDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerCheckpointEventArgs> _enterCheckpointDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerCheckpointEventArgs> _exitCheckpointDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerColshapeEventArgs> _enterColshapeDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerColshapeEventArgs> _exitColshapeDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerCreateWaypointEventArgs> _createWaypointDispatcher;
        private readonly AsyncChildEventDispatcher<PlayerEventArgs> _reachWaypointDispatcher;

        public event AsyncEventHandler<PlayerCommandEventArgs> Command;
        public event AsyncEventHandler<PlayerCommandFailedEventArgs> CommandFailed;
        public event AsyncEventHandler<PlayerChatEventArgs> Chat;
        public event AsyncEventHandler<PlayerEventArgs> Spawned;
        public event AsyncEventHandler<PlayerDamageEventArgs> Damage;
        public event AsyncEventHandler<PlayerWeaponChangeEventArgs> WeaponChange;
        public event AsyncEventHandler<PlayerEnterVehicleEventArgs> StartEnterVehicle;
        public event AsyncEventHandler<PlayerEnterVehicleEventArgs> EnterVehicle;
        public event AsyncEventHandler<PlayerVehicleEventArgs> StartExitVehicle;
        public event AsyncEventHandler<PlayerVehicleEventArgs> ExitVehicle;
        public event AsyncEventHandler<PlayerCheckpointEventArgs> EnterCheckpoint;
        public event AsyncEventHandler<PlayerCheckpointEventArgs> ExitCheckpoint;
        public event AsyncEventHandler<PlayerColshapeEventArgs> EnterColshape;
        public event AsyncEventHandler<PlayerColshapeEventArgs> ExitColshape;
        public event AsyncEventHandler<PlayerCreateWaypointEventArgs> CreateWaypoint;
        public event AsyncEventHandler<PlayerEventArgs> ReachWaypoint;

        public string Serial { get; }

        internal Player(IntPtr playerPointer, Plugin plugin) : base(playerPointer, plugin, EntityType.Player)
        {
            Serial = StringConverter.PointerToString(Rage.Player.Player_GetSerial(NativePointer));
        }

        public void SetName(string value)
        {
            Contract.NotEmpty(value, nameof(value));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var name = converter.StringToPointer(value);
                Rage.Player.Player_SetName(NativePointer, name);
            }
        }

        public Task SetNameAsync(string value)
        {
            return _plugin.Schedule(() => SetName(value));
        }

        public string GetName()
        {
            CheckExistence();

            var namePointer = Rage.Player.Player_GetName(NativePointer);

            return StringConverter.PointerToString(namePointer);
        }

        public Task<string> GetNameAsync()
        {
            return _plugin.Schedule(GetName);
        }

        public string GetSocialClubName()
        {
            CheckExistence();

            var socialClubNamePointer = Rage.Player.Player_GetSocialClubName(NativePointer);

            return StringConverter.PointerToString(socialClubNamePointer);
        }

        public Task<string> GetSocialClubNameAsync()
        {
            return _plugin.Schedule(GetSocialClubName);
        }

        public void SetHeading(float value)
        {
            CheckExistence();

            Rage.Player.Player_SetHeading(NativePointer, value);
        }

        public Task SetHeadingAsync(float value)
        {
            return _plugin.Schedule(() => SetHeading(value));
        }

        public float GetHeading()
        {
            CheckExistence();

            return Rage.Player.Player_GetHeading(NativePointer);
        }

        public Task<float> GetHeadingAsync()
        {
            return _plugin.Schedule(GetHeading);
        }

        public override void SetRotation(Vector3 value)
        {
            SetHeading(value.Z);
        }

        public override Task SetRotationAsync(Vector3 value)
        {
            return SetHeadingAsync(value.Z);
        }

        public override Vector3 GetRotation()
        {
            CheckExistence();

            var vehicle = GetVehicle();

            if (vehicle != null)
            {
                return vehicle.GetRotation();
            }

            return new Vector3(0, 0, GetHeading());
        }

        public override Task<Vector3> GetRotationAsync()
        {
            return _plugin.Schedule(GetRotation);
        }

        public float GetMoveSpeed()
        {
            CheckExistence();

            return Rage.Player.Player_GetMoveSpeed(NativePointer);
        }

        public Task<float> GetMoveSpeedAsync()
        {
            return _plugin.Schedule(GetMoveSpeed);
        }

        public void SetHealth(float value)
        {
            CheckExistence();

            Rage.Player.Player_SetHealth(NativePointer, value);
        }

        public Task SetHealthAsync(float value)
        {
            return _plugin.Schedule(() => SetHealth(value));
        }

        public float GetHealth()
        {
            CheckExistence();

            return Rage.Player.Player_GetHealth(NativePointer);
        }

        public Task<float> GetHealthAsync()
        {
            return _plugin.Schedule(GetHealth);
        }

        public void SetArmor(float value)
        {
            CheckExistence();

            Rage.Player.Player_SetArmor(NativePointer, value);
        }

        public Task SetArmorAsync(float value)
        {
            return _plugin.Schedule(() => SetArmor(value));
        }

        public float GetArmor()
        {
            CheckExistence();

            return Rage.Player.Player_GetArmor(NativePointer);
        }

        public Task<float> GetArmorAsync()
        {
            return _plugin.Schedule(GetArmor);
        }

        public Vector3 GetAimingAt()
        {
            CheckExistence();

            var aimingAtPointer = Rage.Player.Player_GetAminingAt(NativePointer);

            return StructConverter.PointerToStruct<Vector3>(aimingAtPointer);
        }

        public Task<Vector3> GetAimingAtAsync()
        {
            return _plugin.Schedule(GetAimingAt);
        }

        public string GetIp()
        {
            CheckExistence();

            var ipPointer = Rage.Player.Player_GetIp(NativePointer);

            return StringConverter.PointerToString(ipPointer);
        }

        public Task<string> GetIpAsync()
        {
            return _plugin.Schedule(GetIp);
        }

        public int GetPing()
        {
            CheckExistence();

            return Rage.Player.Player_GetPing(NativePointer);
        }

        public Task<int> GetPingAsync()
        {
            return _plugin.Schedule(GetPing);
        }

        public float GetPacketLoss()
        {
            CheckExistence();

            return Rage.Player.Player_GetPacketLoss(NativePointer);
        }

        public Task<float> GetPacketLossAsync()
        {
            return _plugin.Schedule(GetPacketLoss);
        }

        public string GetKickReason()
        {
            CheckExistence();

            var kickReasonPointer = Rage.Player.Player_GetKickReason(NativePointer);

            return StringConverter.PointerToString(kickReasonPointer);
        }

        public Task<string> GetKickReasonAsync()
        {
            return _plugin.Schedule(GetKickReason);
        }

        public bool IsJumping()
        {
            CheckExistence();

            return Rage.Player.Player_IsJumping(NativePointer);
        }

        public Task<bool> IsJumpingAsync()
        {
            return _plugin.Schedule(IsJumping);
        }

        public bool IsInCover()
        {
            CheckExistence();

            return Rage.Player.Player_IsInCover(NativePointer);
        }

        public Task<bool> IsInCoverAsync()
        {
            return _plugin.Schedule(IsInCover);
        }

        public bool IsEnteringVehicle()
        {
            CheckExistence();

            return Rage.Player.Player_IsEnteringVehicle(NativePointer);
        }

        public Task<bool> IsEnteringVehicleAsync()
        {
            return _plugin.Schedule(IsEnteringVehicle);
        }

        public bool IsLeavingVehicle()
        {
            CheckExistence();

            return Rage.Player.Player_IsLeavingVehicle(NativePointer);
        }

        public Task<bool> IsLeavingVehicleAsync()
        {
            return _plugin.Schedule(IsLeavingVehicle);
        }

        public bool IsClimbing()
        {
            CheckExistence();

            return Rage.Player.Player_IsClimbing(NativePointer);
        }

        public Task<bool> IsClimbingAsync()
        {
            return _plugin.Schedule(IsClimbing);
        }

        public bool IsOnLadder()
        {
            CheckExistence();

            return Rage.Player.Player_IsOnLadder(NativePointer);
        }

        public Task<bool> IsOnLadderAsync()
        {
            return _plugin.Schedule(IsOnLadder);
        }

        public bool IsReloading()
        {
            CheckExistence();

            return Rage.Player.Player_IsReloading(NativePointer);
        }

        public Task<bool> IsReloadingAsync()
        {
            return _plugin.Schedule(IsReloading);
        }

        public bool IsInMelee()
        {
            CheckExistence();

            return Rage.Player.Player_IsInMelee(NativePointer);
        }

        public Task<bool> IsInMeleeAsync()
        {
            return _plugin.Schedule(IsInMelee);
        }

        public bool IsAiming()
        {
            CheckExistence();

            return Rage.Player.Player_IsAiming(NativePointer);
        }

        public Task<bool> IsAimingAsync()
        {
            return _plugin.Schedule(IsAiming);
        }

        public string GetActionString()
        {
            CheckExistence();

            var actionStringPointer = Rage.Player.Player_GetActionString(NativePointer);

            return StringConverter.PointerToString(actionStringPointer);
        }

        public Task<string> GetActionStringAsync()
        {
            return _plugin.Schedule(GetActionString);
        }

        public void Kick(string reason = null)
        {
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var reasonPointer = converter.StringToPointer(reason);
                Rage.Player.Player_Kick(NativePointer, reasonPointer);
            }
        }

        public Task KickAsync(string reason = null)
        {
            return _plugin.Schedule(() => Kick(reason));
        }

        public void Ban(string reason = null)
        {
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var reasonPointer = converter.StringToPointer(reason);
                Rage.Player.Player_Ban(NativePointer, reasonPointer);
            }
        }

        public Task BanAsync(string reason = null)
        {
            return _plugin.Schedule(() => Ban(reason));
        }

        public void OutputChatBox(string text)
        {
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var textPointer = converter.StringToPointer(text);
                Rage.Player.Player_OutputChatBox(NativePointer, textPointer);
            }
        }

        public Task OutputChatBoxAsync(string text)
        {
            return _plugin.Schedule(() => OutputChatBox(text));
        }

        public void Notify(string text)
        {
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var textPointer = converter.StringToPointer(text);
                Rage.Player.Player_Notify(NativePointer, textPointer);
            }
        }

        public Task NotifyAsync(string text)
        {
            return _plugin.Schedule(() => Notify(text));
        }

        public void Call(string eventName, params object[] arguments)
        {
            Call(eventName, (IEnumerable<object>) arguments);
        }

        public Task CallAsync(string eventName, params object[] arguments)
        {
            return CallAsync(eventName, (IEnumerable<object>) arguments);
        }

        public void Call(string eventName, IEnumerable<object> arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));
            Contract.NotNull(arguments, nameof(arguments));
            CheckExistence();

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                var eventNamePointer = converter.StringToPointer(eventName);

                Rage.Player.Player__Call(NativePointer, eventNamePointer, data, (ulong) data.LongLength);
            }

            ArgumentData.Dispose(data);
        }

        public Task CallAsync(string eventName, IEnumerable<object> arguments)
        {
            return _plugin.Schedule(() => Call(eventName, arguments));
        }

        public void CallHash(ulong eventHash, params object[] arguments)
        {
            CallHash(eventHash, (IEnumerable<object>) arguments);
        }

        public Task CallHashAsync(ulong eventHash, params object[] arguments)
        {
            return CallHashAsync(eventHash, (IEnumerable<object>) arguments);
        }

        public void CallHash(ulong eventHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(arguments, nameof(arguments));
            CheckExistence();

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            Rage.Player.Player__CallHash(NativePointer, eventHash, data, (ulong) data.LongLength);

            ArgumentData.Dispose(data);
        }

        public Task CallHashAsync(ulong eventHash, IEnumerable<object> arguments)
        {
            return _plugin.Schedule(() => CallHash(eventHash, arguments));
        }

        public void Invoke(ulong nativeHash, params object[] arguments)
        {
            Invoke(nativeHash, (IEnumerable<object>) arguments);
        }

        public Task InvokeAsync(ulong nativeHash, params object[] arguments)
        {
            return InvokeAsync(nativeHash, (IEnumerable<object>) arguments);
        }

        public void Invoke(ulong nativeHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(arguments, nameof(arguments));
            CheckExistence();

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            Rage.Player.Player__Invoke(NativePointer, nativeHash, data, (ulong) data.LongLength);

            ArgumentData.Dispose(data);
        }

        public Task InvokeAsync(ulong nativeHash, IEnumerable<object> arguments)
        {
            return _plugin.Schedule(() => Invoke(nativeHash, arguments));
        }

        public void Spawn(Vector3 position, float heading)
        {
            CheckExistence();

            Rage.Player.Player_Spawn(NativePointer, position, heading);
        }

        public Task SpawnAsync(Vector3 position, float heading)
        {
            return _plugin.Schedule(() => Spawn(position, heading));
        }

        public void PlayAnimation(string dictionary, string name, float speed = 8, AnimationFlags flags = (AnimationFlags) 0)
        {
            Contract.NotEmpty(dictionary, nameof(dictionary));
            Contract.NotEmpty(name, nameof(name));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var dictionaryPointer = converter.StringToPointer(dictionary);
                var namePointer = converter.StringToPointer(name);

                Rage.Player.Player_PlayAnimation(NativePointer, dictionaryPointer, namePointer, speed, (int) flags);
            }
        }

        public Task PlayAnimationAsync(string dictionary, string name, float speed = 8, AnimationFlags flags = (AnimationFlags) 0)
        {
            return _plugin.Schedule(() => PlayAnimation(dictionary, name, speed, flags));
        }

        public void StopAnimation()
        {
            CheckExistence();

            Rage.Player.Player_StopAnimation(NativePointer);
        }

        public Task StopAnimationAsync()
        {
            return _plugin.Schedule(StopAnimation);
        }

        public void PlayScenario(string scenario)
        {
            Contract.NotEmpty(scenario, nameof(scenario));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var scenarioPointer = converter.StringToPointer(scenario);

                Rage.Player.Player_PlayScenario(NativePointer, scenarioPointer);
            }
        }

        public Task PlayScenarioAsync(string scenario)
        {
            return _plugin.Schedule(() => PlayScenario(scenario));
        }

        public bool IsStreamed(IPlayer player)
        {
            Contract.NotNull(player, nameof(player));
            CheckExistence();

            return Rage.Player.Player_IsStreamed(NativePointer, player.NativePointer);
        }

        public Task<bool> IsStreamedAsync(IPlayer player)
        {
            return _plugin.Schedule(() => IsStreamed(player));
        }

        public void RemoveObject(uint model, Vector3 position, float radius)
        {
            CheckExistence();

            Rage.Player.Player_RemoveObject(NativePointer, model, position, radius);
        }

        public Task RemoveObjectAsync(uint model, Vector3 position, float radius)
        {
            return _plugin.Schedule(() => RemoveObject(model, position, radius));
        }

        public void RemoveObject(int model, Vector3 position, float radius)
        {
            RemoveObject((uint) model, position, radius);
        }

        public Task RemoveObjectAsync(int model, Vector3 position, float radius)
        {
            return RemoveObjectAsync((uint) model, position, radius);
        }

        public void Eval(string code)
        {
            Contract.NotEmpty(code, nameof(code));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var codePointer = converter.StringToPointer(code);

                Rage.Player.Player_Eval(NativePointer, codePointer);
            }
        }

        public Task EvalAsync(string code)
        {
            return _plugin.Schedule(() => Eval(code));
        }

        public IReadOnlyCollection<IPlayer> GetStreamedPlayers()
        {
            CheckExistence();

            Rage.Player.Player_GetStreamed(NativePointer, out var playerPointers, out var size);

            return ArrayHelper.ConvertFromIntPtr(playerPointers, size, x => _plugin.PlayerPool[x]);
        }

        public Task<IReadOnlyCollection<IPlayer>> GetStreamedPlayersAsync()
        {
            return _plugin.Schedule(GetStreamedPlayers);
        }
    }
}
