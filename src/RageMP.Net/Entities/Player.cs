using System.Collections.Generic;
using System.Numerics;
using RageMP.Net.Enums;
using RageMP.Net.Interfaces;

namespace RageMP.Net.Entities
{
    public partial class Player : Entity, IPlayer
    {
        public string Serial { get; }
        public string Name { get; set; }
        public string SocialClubName { get; }

        public float Heading { get; set; }
        public float MoveSpeed { get; }
        public float Health { get; set; }
        public float Armor { get; set; }
        public Vector3 AimingAt { get; }

        public string Ip { get; }
        public int Ping { get; }
        public float PacketLoss { get; }

        public string KickReason { get; }

        public bool IsJumping { get; }
        public bool IsInCover { get; }
        public bool IsEnteringVehicle { get; }
        public bool IsLeavingVehicle { get; }
        public bool IsClimbing { get; }
        public bool IsOnLadder { get; }
        public bool IsReloading { get; }
        public bool IsInMelee { get; }

        public string ActionString { get; }

        public IReadOnlyCollection<IPlayer> StreamedPlayers { get; }

        internal Player(uint id) : base(id, EntityType.Player)
        {
        }

        public void Kick(string reason = null)
        {
            throw new System.NotImplementedException();
        }

        public void Ban(string reason = null)
        {
            throw new System.NotImplementedException();
        }

        public void OutputChatBox(string text)
        {
            throw new System.NotImplementedException();
        }

        public void Notify(string text)
        {
            throw new System.NotImplementedException();
        }

        public void Call(string eventName, params object[] arguments)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public void StopAnimation()
        {
            throw new System.NotImplementedException();
        }

        public void PlayScenario(string scenario)
        {
            throw new System.NotImplementedException();
        }

        public uint GetDecoration(uint collection)
        {
            throw new System.NotImplementedException();
        }

        public bool IsStreamed(IPlayer player)
        {
            throw new System.NotImplementedException();
        }
    }
}
