using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using RageMP.Net.Data;
using RageMP.Net.Enums;

namespace RageMP.Net.Interfaces
{
    public interface IPlayer : IEntity
    {
        /// <summary>
        /// Get the serial of the player.
        /// </summary>
        string Serial { get; }

        /// <summary>
        /// Get or set the name of the player.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Get the social club name of the player.
        /// </summary>
        string SocialClubName { get; }

        /// <summary>
        /// Get or set the heading of the player.
        /// </summary>
        float Heading { get; set; }

        /// <summary>
        /// Get the move speed of the player.
        /// </summary>
        float MoveSpeed { get; }

        /// <summary>
        /// Get or set the health of the player.
        /// </summary>
        float Health { get; set; }

        /// <summary>
        /// Get or set the armor of the player.
        /// </summary>
        float Armor { get; set; }

        /// <summary>
        /// Get or set the model of the player.
        /// </summary>
        new PedHash Model { get; set; }

        /// <summary>
        /// Get the position player is aiming at.
        /// </summary>
        Vector3 AimingAt { get; }

        /// <summary>
        /// Get the ip of the player.
        /// </summary>
        string Ip { get; }

        /// <summary>
        /// Get the ping of the player.
        /// </summary>
        int Ping { get; }

        /// <summary>
        /// Get the packet loss of the player.
        /// </summary>
        float PacketLoss { get; }

        /// <summary>
        /// Get the kick reason of the player.
        /// </summary>
        string KickReason { get; }

        /// <summary>
        /// Check if the player is jumping.
        /// </summary>
        bool IsJumping { get; }

        /// <summary>
        /// Check if the player is in cover.
        /// </summary>
        bool IsInCover { get; }

        /// <summary>
        /// Check if the player is entering a vehicle.
        /// </summary>
        bool IsEnteringVehicle { get; }

        /// <summary>
        /// Check if the player is leaving a vehicle.
        /// </summary>
        bool IsLeavingVehicle { get; }

        /// <summary>
        /// Check if the player is climbing.
        /// </summary>
        bool IsClimbing { get; }

        /// <summary>
        /// Check if the player is on a ladder.
        /// </summary>
        bool IsOnLadder { get; }

        /// <summary>
        /// Check if the player is reloading.
        /// </summary>
        bool IsReloading { get; }

        /// <summary>
        /// Check if the player is in melee.
        /// </summary>
        bool IsInMelee { get; }

        /// <summary>
        /// Check if the player is aiming.
        /// </summary>
        bool IsAiming { get; }

        /// <summary>
        /// Get or set the eye color of the vehicle.
        /// </summary>
        uint EyeColor { get; set; }

        /// <summary>
        /// Get the hair color of the vehicle.
        /// </summary>
        uint HairColor { get; }

        /// <summary>
        /// Get the highlight color of the vehicle.
        /// </summary>
        uint HairHighlightColor { get; }

        /// <summary>
        /// Get or set the head blend of the vehicle.
        /// </summary>
        HeadBlendData HeadBlend { get; set; }

        /// <summary>
        /// Get the action string of the vehicle.
        /// </summary>
        string ActionString { get; }

        /// <summary>
        /// Get the vehicle the player is in or null if not in any vehicle.
        /// </summary>
        IVehicle Vehicle { get; }

        /// <summary>
        /// Get the seat the player is on.
        /// </summary>
        int Seat { get; }

        /// <summary>
        /// Get or set the weapon the player has equipped.
        /// </summary>
        uint CurrentWeapon { get; set; }

        /// <summary>
        /// Get or set the ammo of the current weapon.
        /// </summary>
        uint CurrentWeaponAmmo { get; set; }

        /// <summary>
        /// Get all weapons of the player.
        /// </summary>
        IReadOnlyDictionary<uint, uint> Weapons { get; }

        /// <summary>
        /// Get all streamed players of the player.
        /// </summary>
        IReadOnlyCollection<IPlayer> StreamedPlayers { get; }

        /// <summary>
        /// Kick the player.
        /// </summary>
        /// <param name="reason">Reason the player is kicked</param>
        Task KickAsync(string reason = null);

        /// <summary>
        /// Ban the player.
        /// </summary>
        /// <param name="reason">Reason the player is banned</param>
        Task BanAsync(string reason = null);

        /// <summary>
        /// Send chat message to the player.
        /// </summary>
        /// <param name="text">Message to send to the player</param>
        Task OutputChatBoxAsync(string text);

        /// <summary>
        /// Send notification to the player.
        /// </summary>
        /// <param name="text">Message to show in the notification</param>
        Task NotifyAsync(string text);

        /// <summary>
        /// Send an event to the player.
        /// </summary>
        /// <param name="eventName">Name of the event</param>
        /// <param name="arguments">Arguments of the event</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventName" /> is null or empty</exception>
        Task CallAsync(string eventName, params object[] arguments);

        /// <summary>
        /// Send an event to the player.
        /// </summary>
        /// <param name="eventHash">Hash of the event</param>
        /// <param name="arguments">Arguments of the event</param>
        Task CallHashAsync(ulong eventHash, params object[] arguments);

        /// <summary>
        /// Call a native hash on the player.
        /// </summary>
        /// <param name="nativeHash">Hash of the native</param>
        /// <param name="arguments">Arguments of the native</param>
        Task InvokeAsync(ulong nativeHash, params object[] arguments);

        /// <summary>
        /// Spawn the player at given position.
        /// </summary>
        /// <param name="position">Position to spawn the player at</param>
        /// <param name="heading">Heading to spawn the player with</param>
        void Spawn(Vector3 position, float heading);

        /// <summary>
        /// Play an animation on the player.
        /// </summary>
        /// <param name="dictionary">Dictionary name of the animation</param>
        /// <param name="name">Name of the animation</param>
        /// <param name="speed">Speed of the animation</param>
        /// <param name="flags">Flags of the animation</param>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary" /> or <paramref name="name" /> is null or empty</exception>
        void PlayAnimation(string dictionary, string name, float speed = 8f, AnimationFlags flags = 0);

        /// <summary>
        /// Stop playing any animation on the player.
        /// </summary>
        void StopAnimation();

        /// <summary>
        /// Play a scenario on the player.
        /// </summary>
        /// <param name="scenario">Name of the scenario</param>
        /// <exception cref="ArgumentNullException"><paramref name="scenario" /> is null or empty</exception>
        void PlayScenario(string scenario);

        /// <summary>
        /// Get cloth of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the cloth</param>
        /// <returns>Cloth of the player</returns>
        ClothData GetCloth(ClothSlot slot);

        /// <summary>
        /// Set cloth of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the cloth</param>
        /// <param name="data">Value of the slot</param>
        void SetCloth(ClothSlot slot, ClothData data);

        /// <summary>
        /// Set multiple clothes of the player.
        /// </summary>
        /// <param name="clothes">Clothes to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="clothes" /> is null</exception>
        void SetClothes(IDictionary<ClothSlot, ClothData> clothes);

        /// <summary>
        /// Get prop of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the prop</param>
        /// <returns>Prop of the player</returns>
        PropData GetProp(PropSlot slot);

        /// <summary>
        /// Set prop of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the prop</param>
        /// <param name="data">Value of the prop</param>
        void SetProp(PropSlot slot, PropData data);

        /// <summary>
        /// Set multiple props of the player.
        /// </summary>
        /// <param name="props">Props to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="props" /> is null</exception>
        void SetProps(IDictionary<PropSlot, PropData> props);

        /// <summary>
        /// Get the decoration of the player at given collection.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <returns>Decoration of the player</returns>
        uint GetDecoration(uint collection);

        /// <summary>
        /// Remove a decoration of the player.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <param name="overlay">Overlay value of the decoration</param>
        void RemoveDecoration(uint collection, uint overlay);

        /// <summary>
        /// Set a decoration on the player.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <param name="overlay">Overlay value of the decoration</param>
        void SetDecoration(uint collection, uint overlay);

        /// <summary>
        /// Set multiple decorations on the player.
        /// </summary>
        /// <param name="decorations">Decorations to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="decorations" /> is null</exception>
        void SetDecorations(IDictionary<uint, uint> decorations);

        /// <summary>
        /// Set the hair color of the player.
        /// </summary>
        /// <param name="color">Color of the hair</param>
        /// <param name="highlightColor">Highlight color of the hair</param>
        void SetHairColor(uint color, uint highlightColor);

        /// <summary>
        /// Get a face feature of the player.
        /// </summary>
        /// <param name="id">Slot of the face feature</param>
        /// <returns>Value of the face feature</returns>
        float GetFaceFeature(uint id);

        /// <summary>
        /// Set a face feature on the player.
        /// </summary>
        /// <param name="id">Slot of the face feature</param>
        /// <param name="scale">Value of the face feature</param>
        void SetFaceFeature(uint id, float scale);

        /// <summary>
        /// Update the head blend of the player.
        /// </summary>
        /// <param name="shapeMix">Shape mix of the head blend</param>
        /// <param name="skinMix">Skin mix of the head blend</param>
        /// <param name="thirdMix">Third mix of the head blend</param>
        void UpdateHeadBlend(float shapeMix, float skinMix, float thirdMix);

        /// <summary>
        /// Get the head overlay of the player.
        /// </summary>
        /// <param name="overlayId">Slot of the head overlay</param>
        /// <returns>Value of the head overlay</returns>
        HeadOverlayData GetHeadOverlay(uint overlayId);

        /// <summary>
        /// Set the head overlay of the player.
        /// </summary>
        /// <param name="overlayId">Slot of the head overlay</param>
        /// <param name="overlayData">Value of the head overlay</param>
        void SetHeadOverlay(uint overlayId, HeadOverlayData overlayData);

        /// <summary>
        /// Customize the player.
        /// </summary>
        /// <param name="isMale">Male if true, otherwise female</param>
        /// <param name="headBlend">Head blend of the player</param>
        /// <param name="eyeColor">Eye color of the player</param>
        /// <param name="hairColor">Hair color of the player</param>
        /// <param name="highlightColor">Hair highlight color of the player</param>
        /// <param name="faceFeatures">Face features of the player</param>
        /// <param name="headOverlays">Head overlays of the player</param>
        /// <param name="decorations">Decorations of the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="headOverlays" /> or <paramref name="decorations" /> is null</exception>
        void SetCustomization(bool isMale, HeadBlendData headBlend, uint eyeColor, uint hairColor, uint highlightColor, float[] faceFeatures,
            IDictionary<int, HeadOverlayData> headOverlays, IDictionary<uint, uint> decorations);

        /// <summary>
        /// Place player in given vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle to put the player into</param>
        /// <param name="seat">Seat the put the player on</param>
        /// <exception cref="ArgumentNullException"><paramref name="vehicle" /> is null</exception>
        void PutIntoVehicle(IVehicle vehicle, int seat);

        /// <summary>
        /// Remove the player from any vehicle.
        /// </summary>
        void RemoveFromVehicle();

        /// <summary>
        /// Get the ammo of given weapon.
        /// </summary>
        /// <param name="weaponHash">Weapon to get the ammo for</param>
        /// <returns>Ammo of the weapon</returns>
        uint GetWeaponAmmo(uint weaponHash);

        /// <summary>
        /// Set the ammo of given weapon.
        /// </summary>
        /// <param name="weaponHash">Weapon to set the ammo for</param>
        /// <param name="ammo">Ammo for the weapon</param>
        void SetWeaponAmmo(uint weaponHash, uint ammo);

        /// <summary>
        /// Give a weapon to the player.
        /// </summary>
        /// <param name="weaponHash">Weapon to give the player</param>
        /// <param name="ammo">Ammo of the given weapon</param>
        void GiveWeapon(uint weaponHash, uint ammo);

        /// <summary>
        /// Give multiple weapons to the player.
        /// </summary>
        /// <param name="weapons">Key value set of weapons with ammo</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> is null</exception>
        void GiveWeapons(IDictionary<uint, uint> weapons);

        /// <summary>
        /// Remove a weapon from the player.
        /// </summary>
        /// <param name="weaponHash">Weapon to remove</param>
        void RemoveWeapon(uint weaponHash);

        /// <summary>
        /// Remove multiple weapons from the player.
        /// </summary>
        /// <param name="weaponHashes">Weapons to remove</param>
        /// <exception cref="ArgumentNullException"><paramref name="weaponHashes" /> hashes is null</exception>
        void RemoveWeapons(IEnumerable<uint> weaponHashes);

        /// <summary>
        /// Remove all weapons from the player.
        /// </summary>
        void RemoveAllWeapons();

        /// <summary>
        /// Check if given player is streamed.
        /// </summary>
        /// <param name="player">Player to check</param>
        /// <returns>True if the <paramref name="player" /> is streamed, otherwise false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="player" /> is null</exception>
        bool IsStreamed(IPlayer player);

        /// <summary>
        /// Remove object from the player.
        /// </summary>
        /// <param name="model">Model of the object</param>
        /// <param name="position">Position to search object in</param>
        /// <param name="radius">Radius to search object in</param>
        void RemoveObject(uint model, Vector3 position, float radius);

        /// <summary>
        /// Run code on the player.
        ///
        /// WARNING: Use this at your own risk.
        /// </summary>
        /// <param name="code">Code to execute on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="code" /> is null or empty</exception>
        void Eval(string code);

    }
}
