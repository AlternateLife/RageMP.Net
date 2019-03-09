using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal partial class Player : Entity, IPlayer
    {
        public string Serial { get; }

        public string Name
        {
            get
            {
                CheckExistence();

                return StringConverter.PointerToString(Rage.Player.Player_GetName(NativePointer));
            }
            set
            {
                Contract.NotEmpty(value, nameof(value));
                CheckExistence();

                using (var converter = new StringConverter())
                {
                    Rage.Player.Player_SetName(NativePointer, converter.StringToPointer(value));
                }
            }
        }

        public string SocialClubName
        {
            get
            {
                CheckExistence();

                return StringConverter.PointerToString(Rage.Player.Player_GetSocialClubName(NativePointer));
            }
        }

        public float Heading
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_GetHeading(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Player.Player_SetHeading(NativePointer, value);
            }
        }

        public override Vector3 Rotation
        {
            get
            {
                CheckExistence();

                var vehicle = Vehicle;

                if (vehicle != null)
                {
                    return vehicle.Rotation;
                }

                return new Vector3(0, 0, Heading);
            }
            set
            {
                CheckExistence();

                Heading = value.Z;
            }
        }

        public float MoveSpeed
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_GetMoveSpeed(NativePointer);
            }
        }

        public float Health
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_GetHealth(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Player.Player_SetHealth(NativePointer, value);
            }
        }

        public float Armor
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_GetArmor(NativePointer);
            }
            set
            {
                CheckExistence();

                Rage.Player.Player_SetArmor(NativePointer, value);
            }
        }

        public Vector3 AimingAt
        {
            get
            {
                CheckExistence();

                return StructConverter.PointerToStruct<Vector3>(Rage.Player.Player_GetAminingAt(NativePointer));
            }
        }

        public string Ip
        {
            get
            {
                CheckExistence();

                return StringConverter.PointerToString(Rage.Player.Player_GetIp(NativePointer));
            }
        }

        public int Ping
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_GetPing(NativePointer);
            }
        }

        public float PacketLoss
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_GetPacketLoss(NativePointer);
            }
        }

        public string KickReason
        {
            get
            {
                CheckExistence();

                return StringConverter.PointerToString(Rage.Player.Player_GetKickReason(NativePointer));
            }
        }

        public bool IsJumping
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_IsJumping(NativePointer);
            }
        }

        public bool IsInCover
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_IsInCover(NativePointer);
            }
        }

        public bool IsEnteringVehicle
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_IsEnteringVehicle(NativePointer);
            }
        }

        public bool IsLeavingVehicle
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_IsLeavingVehicle(NativePointer);
            }
        }

        public bool IsClimbing
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_IsClimbing(NativePointer);
            }
        }

        public bool IsOnLadder
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_IsOnLadder(NativePointer);
            }
        }

        public bool IsReloading
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_IsReloading(NativePointer);
            }
        }

        public bool IsInMelee
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_IsInMelee(NativePointer);
            }
        }

        public bool IsAiming
        {
            get
            {
                CheckExistence();

                return Rage.Player.Player_IsAiming(NativePointer);
            }
        }

        public string ActionString
        {
            get
            {
                CheckExistence();

                return StringConverter.PointerToString(Rage.Player.Player_GetActionString(NativePointer));
            }
        }

        internal Player(IntPtr playerPointer, Plugin plugin) : base(playerPointer, plugin, EntityType.Player)
        {
            Serial = StringConverter.PointerToString(Rage.Player.Player_GetSerial(NativePointer));
        }

        public async Task KickAsync(string reason = null)
        {
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var reasonPointer = converter.StringToPointer(reason);

                await _plugin
                    .Schedule(() => Rage.Player.Player_Kick(NativePointer, reasonPointer))
                    .ConfigureAwait(false);
            }
        }

        public async Task BanAsync(string reason = null)
        {
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var reasonPointer = converter.StringToPointer(reason);

                await _plugin
                    .Schedule(() => Rage.Player.Player_Ban(NativePointer, reasonPointer))
                    .ConfigureAwait(false);
            }
        }

        public async Task OutputChatBoxAsync(string text)
        {
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var textPointer = converter.StringToPointer(text);

                await _plugin
                    .Schedule(() => Rage.Player.Player_OutputChatBox(NativePointer, textPointer))
                    .ConfigureAwait(false);
            }
        }

        public async Task NotifyAsync(string text)
        {
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var textPointer = converter.StringToPointer(text);

                await _plugin
                    .Schedule(() => Rage.Player.Player_Notify(NativePointer, textPointer))
                    .ConfigureAwait(false);
            }
        }

        public Task CallAsync(string eventName, params object[] arguments)
        {
            return CallAsync(eventName, (IEnumerable<object>) arguments);
        }

        public async Task CallAsync(string eventName, IEnumerable<object> arguments)
        {
            Contract.NotEmpty(eventName, nameof(eventName));
            Contract.NotNull(arguments, nameof(arguments));
            CheckExistence();

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            using (var converter = new StringConverter())
            {
                var eventNamePointer = converter.StringToPointer(eventName);

                await _plugin
                    .Schedule(() => Rage.Player.Player__Call(NativePointer, eventNamePointer, data, (ulong) data.Length))
                    .ConfigureAwait(false);
            }

            ArgumentData.Dispose(data);
        }

        public Task CallHashAsync(ulong eventHash, params object[] arguments)
        {
            return CallHashAsync(eventHash, (IEnumerable<object>) arguments);
        }

        public async Task CallHashAsync(ulong eventHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(arguments, nameof(arguments));
            CheckExistence();

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            await _plugin
                .Schedule(() => Rage.Player.Player__CallHash(NativePointer, eventHash, data, (ulong) data.Length))
                .ConfigureAwait(false);

            ArgumentData.Dispose(data);
        }

        public Task InvokeAsync(ulong nativeHash, params object[] arguments)
        {
            return InvokeAsync(nativeHash, (IEnumerable<object>) arguments);
        }

        public async Task InvokeAsync(ulong nativeHash, IEnumerable<object> arguments)
        {
            Contract.NotNull(arguments, nameof(arguments));
            CheckExistence();

            var data = _plugin.ArgumentConverter.ConvertFromObjects(arguments);

            await _plugin
                .Schedule(() => Rage.Player.Player__Invoke(NativePointer, nativeHash, data, (ulong) data.Length))
                .ConfigureAwait(false);

            ArgumentData.Dispose(data);
        }

        public async Task SpawnAsync(Vector3 position, float heading)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_Spawn(NativePointer, position, heading))
                .ConfigureAwait(false);
        }

        public async Task PlayAnimationAsync(string dictionary, string name, float speed = 8, AnimationFlags flags = (AnimationFlags) 0)
        {
            Contract.NotEmpty(dictionary, nameof(dictionary));
            Contract.NotEmpty(name, nameof(name));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var dictionaryPointer = converter.StringToPointer(dictionary);
                var namePointer = converter.StringToPointer(name);

                await _plugin
                    .Schedule(() => Rage.Player.Player_PlayAnimation(NativePointer, dictionaryPointer, namePointer, speed, (int) flags))
                    .ConfigureAwait(false);
            }
        }

        public async Task StopAnimationAsync()
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_StopAnimation(NativePointer))
                .ConfigureAwait(false);
        }

        public async Task PlayScenarioAsync(string scenario)
        {
            Contract.NotEmpty(scenario, nameof(scenario));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var scenarioPointer = converter.StringToPointer(scenario);

                await _plugin
                    .Schedule(() => Rage.Player.Player_PlayScenario(NativePointer, scenarioPointer))
                    .ConfigureAwait(false);
            }
        }

        public async Task<bool> IsStreamedAsync(IPlayer player)
        {
            Contract.NotNull(player, nameof(player));
            CheckExistence();

            return await _plugin
                .Schedule(() => Rage.Player.Player_IsStreamed(NativePointer, player.NativePointer))
                .ConfigureAwait(false);
        }

        public async Task RemoveObjectAsync(uint model, Vector3 position, float radius)
        {
            CheckExistence();

            await _plugin
                .Schedule(() => Rage.Player.Player_RemoveObject(NativePointer, model, position, radius))
                .ConfigureAwait(false);
        }

        public Task RemoveObjectAsync(int model, Vector3 position, float radius)
        {
            return RemoveObjectAsync((uint) model, position, radius);
        }

        public async Task EvalAsync(string code)
        {
            Contract.NotEmpty(code, nameof(code));
            CheckExistence();

            using (var converter = new StringConverter())
            {
                var codePointer = converter.StringToPointer(code);

                await _plugin
                    .Schedule(() => Rage.Player.Player_Eval(NativePointer, codePointer))
                    .ConfigureAwait(false);
            }
        }

        public async Task<IReadOnlyCollection<IPlayer>> GetStreamedPlayersAsync()
        {
            CheckExistence();

            IntPtr playerPointers = IntPtr.Zero;
            ulong size = 0;

            await _plugin
                .Schedule(() => Rage.Player.Player_GetStreamed(NativePointer, out playerPointers, out size))
                .ConfigureAwait(false);

            return ArrayHelper.ConvertFromIntPtr(playerPointers, size, x => _plugin.PlayerPool[x]);
        }
    }
}
