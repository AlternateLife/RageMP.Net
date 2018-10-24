using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
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
        public string Serial => StringConverter.PointerToString(Rage.Player.Player_GetSerial(NativePointer));

        public string Name
        {
            get => StringConverter.PointerToString(Rage.Player.Player_GetName(NativePointer));
            set
            {
                using (var converter = new StringConverter())
                {
                    Rage.Player.Player_SetName(NativePointer, converter.StringToPointer(value));
                }
            }
        }

        public string SocialClubName => StringConverter.PointerToString(Rage.Player.Player_GetSocialClubName(NativePointer));

        public float Heading
        {
            get => Rage.Player.Player_GetHeading(NativePointer);
            set => Rage.Player.Player_SetHeading(NativePointer, value);
        }

        public float MoveSpeed => Rage.Player.Player_GetMoveSpeed(NativePointer);

        public float Health
        {
            get => Rage.Player.Player_GetHealth(NativePointer);
            set => Rage.Player.Player_SetHealth(NativePointer, value);
        }

        public float Armor
        {
            get => Rage.Player.Player_GetArmor(NativePointer);
            set => Rage.Player.Player_SetArmor(NativePointer, value);
        }

        public Vector3 AimingAt => Marshal.PtrToStructure<Vector3>(Rage.Player.Player_GetAminingAt(NativePointer));

        public string Ip => StringConverter.PointerToString(Rage.Player.Player_GetIp(NativePointer));
        public int Ping => Rage.Player.Player_GetPing(NativePointer);
        public float PacketLoss => Rage.Player.Player_GetPacketLoss(NativePointer);

        public string KickReason => StringConverter.PointerToString(Rage.Player.Player_GetKickReason(NativePointer));

        public bool IsJumping => Rage.Player.Player_IsJumping(NativePointer);
        public bool IsInCover => Rage.Player.Player_IsInCover(NativePointer);
        public bool IsEnteringVehicle => Rage.Player.Player_IsEnteringVehicle(NativePointer);
        public bool IsLeavingVehicle => Rage.Player.Player_IsLeavingVehicle(NativePointer);
        public bool IsClimbing => Rage.Player.Player_IsClimbing(NativePointer);
        public bool IsOnLadder => Rage.Player.Player_IsOnLadder(NativePointer);
        public bool IsReloading => Rage.Player.Player_IsReloading(NativePointer);
        public bool IsInMelee => Rage.Player.Player_IsInMelee(NativePointer);
        public bool IsAiming => Rage.Player.Player_IsAiming(NativePointer);

        public string ActionString => StringConverter.PointerToString(Rage.Player.Player_GetActionString(NativePointer));

        public IReadOnlyCollection<IPlayer> StreamedPlayers
        {
            get
            {
                Rage.Player.Player_GetStreamed(NativePointer, out var playerPointers, out var size);

                var players = new List<IPlayer>();

                for (var i = 0; i < (int) size; i++)
                {
                    players.Add(_plugin.PlayerPool[playerPointers[i]]);
                }

                return players;
            }
        }

        internal Player(IntPtr playerPointer, Plugin plugin) : base(playerPointer, plugin, EntityType.Player)
        {
        }

        public async Task KickAsync(string reason = null)
        {
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

            var data = ArgumentData.ConvertFromObjects(arguments);

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

            var data = ArgumentData.ConvertFromObjects(arguments);

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

            var data = ArgumentData.ConvertFromObjects(arguments);

            await _plugin
                .Schedule(() => Rage.Player.Player__Invoke(NativePointer, nativeHash, data, (ulong) data.Length))
                .ConfigureAwait(false);

            ArgumentData.Dispose(data);
        }

        public void Spawn(Vector3 position, float heading)
        {
            Rage.Player.Player_Spawn(NativePointer, position, heading);
        }

        public void PlayAnimation(string dictionary, string name, float speed = 8, AnimationFlags flags = (AnimationFlags) 0)
        {
            Contract.NotEmpty(dictionary, nameof(dictionary));
            Contract.NotEmpty(name, nameof(name));

            using (var converter = new StringConverter())
            {
                Rage.Player.Player_PlayAnimation(NativePointer, converter.StringToPointer(dictionary), converter.StringToPointer(name), speed, (int) flags);
            }
        }

        public void StopAnimation()
        {
            Rage.Player.Player_StopAnimation(NativePointer);
        }

        public void PlayScenario(string scenario)
        {
            Contract.NotEmpty(scenario, nameof(scenario));

            using (var converter = new StringConverter())
            {
                Rage.Player.Player_PlayScenario(NativePointer, converter.StringToPointer(scenario));
            }
        }

        public bool IsStreamed(IPlayer player)
        {
            Contract.NotNull(player, nameof(player));

            return Rage.Player.Player_IsStreamed(NativePointer, player.NativePointer);
        }

        public void RemoveObject(uint model, Vector3 position, float radius)
        {
            Rage.Player.Player_RemoveObject(NativePointer, model, position, radius);
        }

        public void RemoveObject(int model, Vector3 position, float radius)
        {
            RemoveObject((uint) model, position, radius);
        }

        public void Eval(string code)
        {
            Contract.NotEmpty(code, nameof(code));

            using (var converter = new StringConverter())
            {
                Rage.Player.Player_Eval(NativePointer, converter.StringToPointer(code));
            }
        }
    }
}
