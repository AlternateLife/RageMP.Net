using System.Collections.Generic;
using System.Numerics;
using RageMP.Net.Data;
using RageMP.Net.Enums;

namespace RageMP.Net.Interfaces
{
    public interface IPlayer : IEntity
    {
        string Serial { get; }
        string Name { get; set; }
        string SocialClubName { get; }
        float Heading { get; set; }
        float MoveSpeed { get; }
        float Health { get; set; }
        float Armor { get; set; }

        Vector3 AimingAt { get; }

        string Ip { get; }
        int Ping { get; }
        float PacketLoss { get; }

        string KickReason { get; }

        bool IsJumping { get; }
        bool IsInCover { get; }
        bool IsEnteringVehicle { get; }
        bool IsLeavingVehicle { get; }
        bool IsClimbing { get; }
        bool IsOnLadder { get; }
        bool IsReloading { get; }
        bool IsInMelee { get; }

        int EyeColor { get; set; }
        int HairColor { get; }
        int HairHighlightColor { get; }
        HeadBlendData HeadBlend { get; set; }

        string ActionString { get; }

        IVehicle Vehicle { get; }
        int Seat { get; }

        uint CurrentWeapon { get; set; }
        uint CurrentWeaponAmmo { get; set; }

        IReadOnlyCollection<IPlayer> StreamedPlayers { get; }

        void Kick(string reason = null);
        void Ban(string reason = null);
        void OutputChatBox(string text);
        void Notify(string text);

        void Call(string eventName, params object[] arguments);
        void Invoke(ulong nativeHash, params object[] arguments);

        void Spawn(Vector3 position, float heading);
        void PlayAnimation(string dictionary, string name, float speed = 8f, AnimationFlags flags = 0);
        void StopAnimation();
        void PlayScenario(string scenario);

        uint GetDecoration(uint collection);
        void RemoveDecoration(uint collection, uint overlay);
        void SetDecoration(uint collection, uint overlay);
        void SetDecorations(Dictionary<uint, uint> decorations);

        void SetHairColor(uint color, uint highlightColor);

        float GetFaceFeature(uint id);
        void SetFaceFeature(uint id, float scale);

        void UpdateHeadBlend(float shapeMix, float skinMix, float thirdMix);

        HeadOverlayData GetHeadOverlay(uint overlayId);
        void SetHeadOverlay(uint overlayId, HeadOverlayData overlayData);

        void PutIntoVehicle(IVehicle vehicle, int seat);
        void RemoveFromVehicle();

        uint GetWeaponAmmo(uint weaponHash);
        void SetWeaponAmmo(uint weaponHash, uint ammo);

        IReadOnlyDictionary<uint, uint> GetWeapons();

        void GiveWeapon(uint weaponHash, uint ammo);
        void GiveWeapons(IDictionary<uint, uint> weapons);

        void RemoveWeapon(uint weaponHash);
        void RemoveWeapons(IEnumerable<uint> weaponHashes);
        void RemoveAllWeapons();

        bool IsStreamed(IPlayer player);

    }
}
