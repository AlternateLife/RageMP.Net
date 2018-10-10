using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using RageMP.Net.Data;
using RageMP.Net.Enums;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Entities
{
    public partial class Player : Entity, IPlayer
    {
        public string Serial => Marshal.PtrToStringAnsi(Rage.Player.Player_GetSerial(NativePointer));

        public string Name
        {
            get => Marshal.PtrToStringAnsi(Rage.Player.Player_GetName(NativePointer));
            set => Rage.Player.Player_SetName(NativePointer, value);
        }

        public string SocialClubName => Marshal.PtrToStringAnsi(Rage.Player.Player_GetSocialClubName(NativePointer));

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

        public string Ip => Marshal.PtrToStringAnsi(Rage.Player.Player_GetIp(NativePointer));
        public int Ping => Rage.Player.Player_GetPing(NativePointer);
        public float PacketLoss => Rage.Player.Player_GetPacketLoss(NativePointer);

        public string KickReason => Marshal.PtrToStringAnsi(Rage.Player.Player_GetKickReason(NativePointer));

        public bool IsJumping { get; }
        public bool IsInCover { get; }
        public bool IsEnteringVehicle { get; }
        public bool IsLeavingVehicle { get; }
        public bool IsClimbing { get; }
        public bool IsOnLadder { get; }
        public bool IsReloading { get; }
        public bool IsInMelee { get; }

        public string ActionString => Marshal.PtrToStringAnsi(Rage.Player.Player_GetActionString(NativePointer));

        public IReadOnlyCollection<IPlayer> StreamedPlayers { get; }

        internal Player(IntPtr playerPointer) : base(playerPointer, EntityType.Player)
        {
        }

        public void Kick(string reason = null)
        {
            Rage.Player.Player_Kick(NativePointer, reason);
        }

        public void Ban(string reason = null)
        {
            Rage.Player.Player_Ban(NativePointer, reason);
        }

        public void OutputChatBox(string text)
        {
            Rage.Player.Player_OutputChatBox(NativePointer, text);
        }

        public void Notify(string text)
        {
            Rage.Player.Player_Notify(NativePointer, text);
        }

        public void Call(string eventName, params object[] arguments)
        {
            var data = ArgumentData.ConvertFromArguments(arguments);

            Rage.Player.Player__Call(NativePointer, eventName, data, data.Length);
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
            Rage.Player.Player_PlayAnimation(NativePointer, dictionary, name, speed, (int) flags);
        }

        public void StopAnimation()
        {
            Rage.Player.Player_StopAnimation(NativePointer);
        }

        public void PlayScenario(string scenario)
        {
            Rage.Player.Player_PlayScenario(NativePointer, scenario);
        }

        public bool IsStreamed(IPlayer player)
        {
            return Rage.Player.Player_IsStreamed(NativePointer, player.NativePointer);
        }
    }
}
