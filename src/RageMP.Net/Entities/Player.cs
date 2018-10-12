using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using RageMP.Net.Data;
using RageMP.Net.Enums;
using RageMP.Net.Helpers;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Entities
{
    public partial class Player : Entity, IPlayer
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

        public Vector3 AimingAt { get; }

        public string Ip => StringConverter.PointerToString(Rage.Player.Player_GetIp(NativePointer));
        public int Ping => Rage.Player.Player_GetPing(NativePointer);
        public float PacketLoss => Rage.Player.Player_GetPacketLoss(NativePointer);

        public string KickReason => StringConverter.PointerToString(Rage.Player.Player_GetKickReason(NativePointer));

        public bool IsJumping { get; }
        public bool IsInCover { get; }
        public bool IsEnteringVehicle { get; }
        public bool IsLeavingVehicle { get; }
        public bool IsClimbing { get; }
        public bool IsOnLadder { get; }
        public bool IsReloading { get; }
        public bool IsInMelee { get; }

        public string ActionString => StringConverter.PointerToString(Rage.Player.Player_GetActionString(NativePointer));

        public IReadOnlyCollection<IPlayer> StreamedPlayers { get; }

        internal Player(IntPtr playerPointer) : base(playerPointer, EntityType.Player)
        {
        }

        public void Kick(string reason = null)
        {
            using (var converter = new StringConverter())
            {
                Rage.Player.Player_Kick(NativePointer, converter.StringToPointer(reason));
            }
        }

        public void Ban(string reason = null)
        {
            using (var converter = new StringConverter())
            {
                Rage.Player.Player_Ban(NativePointer, converter.StringToPointer(reason));
            }
        }

        public void OutputChatBox(string text)
        {
            using (var converter = new StringConverter())
            {
                Rage.Player.Player_OutputChatBox(NativePointer, converter.StringToPointer(text));
            }
        }

        public void Notify(string text)
        {
            using (var converter = new StringConverter())
            {
                Rage.Player.Player_Notify(NativePointer, converter.StringToPointer(text));
            }
        }

        public void Call(string eventName, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromArguments(arguments);

            using (var converter = new StringConverter())
            {
                Rage.Player.Player__Call(NativePointer, converter.StringToPointer(eventName), data, data.Length);
            }

            ArgumentData.Dispose(data);
        }

        public void Invoke(ulong nativeHash, params object[] arguments)
        {
            throw new System.NotImplementedException();
        }

        public void Spawn(Vector3 position, float heading)
        {
            throw new System.NotImplementedException();
        }

        public void PlayAnimation(string dictionary, string name, float speed = 8, AnimationFlags flags = (AnimationFlags) 0)
        {
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
            using (var converter = new StringConverter())
            {
                Rage.Player.Player_PlayScenario(NativePointer, converter.StringToPointer(scenario));
            }
        }

        public bool IsStreamed(IPlayer player)
        {
            return Rage.Player.Player_IsStreamed(NativePointer, player.NativePointer);
        }
    }
}
