using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
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
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string Name { get; set; }

        /// <summary>
        /// Get the social club name of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string SocialClubName { get; }

        /// <summary>
        /// Get or set the heading of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float Heading { get; set; }

        /// <summary>
        /// Get the move speed of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float MoveSpeed { get; }

        /// <summary>
        /// Get or set the health of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float Health { get; set; }

        /// <summary>
        /// Get or set the armor of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float Armor { get; set; }

        /// <summary>
        /// Get or set the model of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        new PedHash Model { get; set; }

        /// <summary>
        /// Get the position player is aiming at.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Vector3 AimingAt { get; }

        /// <summary>
        /// Get the ip of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string Ip { get; }

        /// <summary>
        /// Get the ping of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        int Ping { get; }

        /// <summary>
        /// Get the packet loss of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float PacketLoss { get; }

        /// <summary>
        /// Get the kick reason of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string KickReason { get; }

        /// <summary>
        /// Check if the player is jumping.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsJumping { get; }

        /// <summary>
        /// Check if the player is in cover.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsInCover { get; }

        /// <summary>
        /// Check if the player is entering a vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsEnteringVehicle { get; }

        /// <summary>
        /// Check if the player is leaving a vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsLeavingVehicle { get; }

        /// <summary>
        /// Check if the player is climbing.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsClimbing { get; }

        /// <summary>
        /// Check if the player is on a ladder.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsOnLadder { get; }

        /// <summary>
        /// Check if the player is reloading.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsReloading { get; }

        /// <summary>
        /// Check if the player is in melee.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsInMelee { get; }

        /// <summary>
        /// Check if the player is aiming.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsAiming { get; }

        /// <summary>
        /// Get or set the eye color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint EyeColor { get; set; }

        /// <summary>
        /// Get the hair color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint HairColor { get; }

        /// <summary>
        /// Get the highlight color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint HairHighlightColor { get; }

        /// <summary>
        /// Get or set the <see cref="HeadBlendData" /> of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        HeadBlendData HeadBlend { get; set; }

        /// <summary>
        /// Get the action string of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string ActionString { get; }

        /// <summary>
        /// Get the <see cref="IVehicle" /> the player is in or null if not in any vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IVehicle Vehicle { get; }

        /// <summary>
        /// Check if the player is in any vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsInVehicle { get; }

        /// <summary>
        /// Get the seat the player is on.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        int Seat { get; }

        /// <summary>
        /// Get or set the weapon the player has equipped.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint CurrentWeapon { get; set; }

        /// <summary>
        /// Get or set the ammo of the current weapon.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint CurrentWeaponAmmo { get; set; }

        /// <summary>
        /// Get all weapons of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IReadOnlyDictionary<WeaponHash, uint> Weapons { get; }

        /// <summary>
        /// Get all streamed players of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IReadOnlyCollection<IPlayer> StreamedPlayers { get; }

        /// <summary>
        /// Kick the player.
        /// </summary>
        /// <param name="reason">Reason the player is kicked</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task KickAsync(string reason = null);

        /// <summary>
        /// Ban the player.
        /// </summary>
        /// <param name="reason">Reason the player is banned</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task BanAsync(string reason = null);

        /// <summary>
        /// Send chat message to the player.
        /// </summary>
        /// <param name="text">Message to send to the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task OutputChatBoxAsync(string text);

        /// <summary>
        /// Send notification to the player.
        /// </summary>
        /// <param name="text">Message to show in the notification</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task NotifyAsync(string text);

        /// <summary>
        /// Send an event to the player.
        /// </summary>
        /// <param name="eventName">Name of the event</param>
        /// <param name="arguments">Arguments of the event</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventName" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task CallAsync(string eventName, params object[] arguments);

        /// <summary>
        /// Send an event to the player.
        /// </summary>
        /// <param name="eventName">Name of the event</param>
        /// <param name="arguments">Arguments of the event</param>
        /// <exception cref="ArgumentNullException"><paramref name="eventName" /> is null or empty, <paramref name="arguments"/> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task CallAsync(string eventName, IEnumerable<object> arguments);

        /// <summary>
        /// Send an event to the player.
        /// </summary>
        /// <param name="eventHash">Hash of the event</param>
        /// <param name="arguments">Arguments of the event</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task CallHashAsync(ulong eventHash, params object[] arguments);

        /// <summary>
        /// Send an event to the player.
        /// </summary>
        /// <param name="eventHash">Hash of the event</param>
        /// <param name="arguments">Arguments of the event</param>
        /// <exception cref="ArgumentNullException"><paramref name="arguments"/> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task CallHashAsync(ulong eventHash, IEnumerable<object> arguments);

        /// <summary>
        /// Call a native hash on the player.
        /// </summary>
        /// <param name="nativeHash">Hash of the native</param>
        /// <param name="arguments">Arguments of the native</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task InvokeAsync(ulong nativeHash, params object[] arguments);

        /// <summary>
        /// Call a native hash on the player.
        /// </summary>
        /// <param name="nativeHash">Hash of the native</param>
        /// <param name="arguments">Arguments of the native</param>
        /// <exception cref="ArgumentNullException"><paramref name="arguments"/> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task InvokeAsync(ulong nativeHash, IEnumerable<object> arguments);

        /// <summary>
        /// Spawn the player at given position.
        /// </summary>
        /// <param name="position">Position to spawn the player at</param>
        /// <param name="heading">Heading to spawn the player with</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void Spawn(Vector3 position, float heading);

        /// <summary>
        /// Play an animation on the player.
        /// </summary>
        /// <param name="dictionary">Dictionary name of the animation</param>
        /// <param name="name">Name of the animation</param>
        /// <param name="speed">Speed of the animation</param>
        /// <param name="flags">Flags of the animation</param>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary" /> or <paramref name="name" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void PlayAnimation(string dictionary, string name, float speed = 8f, AnimationFlags flags = 0);

        /// <summary>
        /// Stop playing any animation on the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void StopAnimation();

        /// <summary>
        /// Play a scenario on the player.
        /// </summary>
        /// <param name="scenario">Name of the scenario</param>
        /// <exception cref="ArgumentNullException"><paramref name="scenario" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void PlayScenario(string scenario);

        /// <summary>
        /// Get cloth of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the cloth</param>
        /// <returns><see cref="ClothSlot" /> of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        ClothData GetCloth(ClothSlot slot);

        /// <summary>
        /// Get cloth of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the cloth</param>
        /// <returns><see cref="ClothSlot" /> of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        ClothData GetCloth(int slot);

        /// <summary>
        /// Set cloth of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the cloth</param>
        /// <param name="data">Value of the slot</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetCloth(ClothSlot slot, ClothData data);

        /// <summary>
        /// Set cloth of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the cloth</param>
        /// <param name="drawable">Drawable value of the cloth</param>
        /// <param name="texture">Texture value of the cloth</param>
        /// <param name="palette">Palette value of the cloth</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetCloth(ClothSlot slot, byte drawable, byte texture, byte palette);

        /// <summary>
        /// Set multiple clothes of the player.
        /// </summary>
        /// <param name="clothes">Clothes to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="clothes" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetClothes(IDictionary<ClothSlot, ClothData> clothes);

        /// <summary>
        /// Get prop of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the prop</param>
        /// <returns><see cref="PropSlot" /> of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        PropData GetProp(PropSlot slot);

        /// <summary>
        /// Get prop of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the prop</param>
        /// <returns><see cref="PropSlot" /> of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        PropData GetProp(int slot);

        /// <summary>
        /// Set prop of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the prop</param>
        /// <param name="data">Value of the prop</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetProp(PropSlot slot, PropData data);

        /// <summary>
        /// Set prop of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the prop</param>
        /// <param name="drawable">Drawable value of the prop</param>
        /// <param name="texture">Texture value of the prop</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetProp(PropSlot slot, byte drawable, byte texture);

        /// <summary>
        /// Set multiple props of the player.
        /// </summary>
        /// <param name="props">Props to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="props" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetProps(IDictionary<PropSlot, PropData> props);

        /// <summary>
        /// Get the decoration of the player at given collection.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <returns>Decoration of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetDecoration(uint collection);

        /// <summary>
        /// Get the decoration of the player at given collection.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <returns>Decoration of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        int GetDecoration(int collection);

        /// <summary>
        /// Remove a decoration of the player.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <param name="overlay">Overlay value of the decoration</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveDecoration(uint collection, uint overlay);

        /// <summary>
        /// Remove a decoration of the player.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <param name="overlay">Overlay value of the decoration</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveDecoration(int collection, int overlay);

        /// <summary>
        /// Set a decoration on the player.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <param name="overlay">Overlay value of the decoration</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetDecoration(uint collection, uint overlay);

        /// <summary>
        /// Set a decoration on the player.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <param name="overlay">Overlay value of the decoration</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetDecoration(int collection, int overlay);

        /// <summary>
        /// Set multiple decorations on the player.
        /// </summary>
        /// <param name="decorations">Decorations to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="decorations" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetDecorations(IDictionary<uint, uint> decorations);

        /// <summary>
        /// Set multiple decorations on the player.
        /// </summary>
        /// <param name="decorations">Decorations to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="decorations" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetDecorations(IDictionary<int, int> decorations);

        /// <summary>
        /// Removes all applied decorations from the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void ClearDecorations();

        /// <summary>
        /// Set the hair color of the player.
        /// </summary>
        /// <param name="color">Color of the hair</param>
        /// <param name="highlightColor">Highlight color of the hair</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetHairColor(uint color, uint highlightColor);

        /// <summary>
        /// Set the hair color of the player.
        /// </summary>
        /// <param name="color">Color of the hair</param>
        /// <param name="highlightColor">Highlight color of the hair</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetHairColor(int color, int highlightColor);

        /// <summary>
        /// Get a face feature of the player.
        /// </summary>
        /// <param name="id">Slot of the face feature</param>
        /// <returns>Value of the face feature</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetFaceFeature(uint id);

        /// <summary>
        /// Get a face feature of the player.
        /// </summary>
        /// <param name="id">Slot of the face feature</param>
        /// <returns>Value of the face feature</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetFaceFeature(int id);

        /// <summary>
        /// Set a face feature on the player.
        /// </summary>
        /// <param name="id">Slot of the face feature</param>
        /// <param name="scale">Value of the face feature</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetFaceFeature(uint id, float scale);

        /// <summary>
        /// Set a face feature on the player.
        /// </summary>
        /// <param name="id">Slot of the face feature</param>
        /// <param name="scale">Value of the face feature</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetFaceFeature(int id, float scale);

        /// <summary>
        /// Update the head blend of the player.
        /// </summary>
        /// <param name="shapeMix">Shape mix of the head blend</param>
        /// <param name="skinMix">Skin mix of the head blend</param>
        /// <param name="thirdMix">Third mix of the head blend</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void UpdateHeadBlend(float shapeMix, float skinMix, float thirdMix);

        /// <summary>
        /// Get the head overlay of the player.
        /// </summary>
        /// <param name="overlayId">Slot of the head overlay</param>
        /// <returns>Value of the <see cref="HeadOverlayData" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        HeadOverlayData GetHeadOverlay(uint overlayId);

        /// <summary>
        /// Get the head overlay of the player.
        /// </summary>
        /// <param name="overlayId">Slot of the head overlay</param>
        /// <returns>Value of the <see cref="HeadOverlayData" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        HeadOverlayData GetHeadOverlay(int overlayId);

        /// <summary>
        /// Set the head overlay of the player.
        /// </summary>
        /// <param name="overlayId">Slot of the head overlay</param>
        /// <param name="overlayData">Value of the head overlay</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetHeadOverlay(uint overlayId, HeadOverlayData overlayData);

        /// <summary>
        /// Set the head overlay of the player.
        /// </summary>
        /// <param name="overlayId">Slot of the head overlay</param>
        /// <param name="overlayData">Value of the head overlay</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetHeadOverlay(int overlayId, HeadOverlayData overlayData);

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
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetCustomization(bool isMale, HeadBlendData headBlend, uint eyeColor, uint hairColor, uint highlightColor, float[] faceFeatures,
            IDictionary<int, HeadOverlayData> headOverlays, IDictionary<uint, uint> decorations);

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
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetCustomization(bool isMale, HeadBlendData headBlend, int eyeColor, int hairColor, int highlightColor, float[] faceFeatures,
            IDictionary<int, HeadOverlayData> headOverlays, IDictionary<int, int> decorations);

        /// <summary>
        /// Place player in given vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle to put the player into</param>
        /// <param name="seat">Seat the put the player on</param>
        /// <exception cref="ArgumentNullException"><paramref name="vehicle" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void PutIntoVehicle(IVehicle vehicle, int seat);

        /// <summary>
        /// Remove the player from any vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveFromVehicle();

        /// <summary>
        /// Get the ammo of given weapon.
        /// </summary>
        /// <param name="weapon">Weapon to get the ammo for</param>
        /// <returns>Ammo of the weapon</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetWeaponAmmo(WeaponHash weapon);

        /// <summary>
        /// Get the ammo of given weapon.
        /// </summary>
        /// <param name="weapon">Weapon to get the ammo for</param>
        /// <returns>Ammo of the weapon</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetWeaponAmmo(uint weapon);

        /// <summary>
        /// Get the ammo of given weapon.
        /// </summary>
        /// <param name="weapon">Weapon to get the ammo for</param>
        /// <returns>Ammo of the weapon</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        int GetWeaponAmmo(int weapon);

        /// <summary>
        /// Set the ammo of given weapon.
        /// </summary>
        /// <param name="weapon">Weapon to set the ammo for</param>
        /// <param name="ammo">Ammo for the weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetWeaponAmmo(WeaponHash weapon, uint ammo);

        /// <summary>
        /// Set the ammo of given weapon.
        /// </summary>
        /// <param name="weapon">Weapon to set the ammo for</param>
        /// <param name="ammo">Ammo for the weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetWeaponAmmo(WeaponHash weapon, int ammo);

        /// <summary>
        /// Set the ammo of given weapon.
        /// </summary>
        /// <param name="weapon">Weapon to set the ammo for</param>
        /// <param name="ammo">Ammo for the weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetWeaponAmmo(uint weapon, uint ammo);

        /// <summary>
        /// Set the ammo of given weapon.
        /// </summary>
        /// <param name="weapon">Weapon to set the ammo for</param>
        /// <param name="ammo">Ammo for the weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetWeaponAmmo(int weapon, int ammo);

        /// <summary>
        /// Give a weapon to the player.
        /// </summary>
        /// <param name="weapon">Weapon to give the player</param>
        /// <param name="ammo">Ammo of the given weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void GiveWeapon(WeaponHash weapon, uint ammo);

        /// <summary>
        /// Give a weapon to the player.
        /// </summary>
        /// <param name="weapon">Weapon to give the player</param>
        /// <param name="ammo">Ammo of the given weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void GiveWeapon(WeaponHash weapon, int ammo);

        /// <summary>
        /// Give a weapon to the player.
        /// </summary>
        /// <param name="weapon">Weapon to give the player</param>
        /// <param name="ammo">Ammo of the given weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void GiveWeapon(uint weapon, uint ammo);

        /// <summary>
        /// Give a weapon to the player.
        /// </summary>
        /// <param name="weapon">Weapon to give the player</param>
        /// <param name="ammo">Ammo of the given weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void GiveWeapon(int weapon, int ammo);

        /// <summary>
        /// Give multiple weapons to the player.
        /// </summary>
        /// <param name="weapons">Key value set of weapons with ammo</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void GiveWeapons(IDictionary<WeaponHash, uint> weapons);

        /// <summary>
        /// Give multiple weapons to the player.
        /// </summary>
        /// <param name="weapons">Key value set of weapons with ammo</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void GiveWeapons(IDictionary<WeaponHash, int> weapons);

        /// <summary>
        /// Give multiple weapons to the player.
        /// </summary>
        /// <param name="weapons">Key value set of weapons with ammo</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void GiveWeapons(IDictionary<uint, uint> weapons);

        /// <summary>
        /// Give multiple weapons to the player.
        /// </summary>
        /// <param name="weapons">Key value set of weapons with ammo</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void GiveWeapons(IDictionary<int, int> weapons);

        /// <summary>
        /// Remove a weapon from the player.
        /// </summary>
        /// <param name="weapon">Weapon to remove</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveWeapon(WeaponHash weapon);

        /// <summary>
        /// Remove a weapon from the player.
        /// </summary>
        /// <param name="weapon">Weapon to remove</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveWeapon(uint weapon);

        /// <summary>
        /// Remove a weapon from the player.
        /// </summary>
        /// <param name="weapon">Weapon to remove</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveWeapon(int weapon);

        /// <summary>
        /// Remove multiple weapons from the player.
        /// </summary>
        /// <param name="weapons">Weapons to remove</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> hashes is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveWeapons(IEnumerable<WeaponHash> weapons);

        /// <summary>
        /// Remove multiple weapons from the player.
        /// </summary>
        /// <param name="weapons">Weapons to remove</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> hashes is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveWeapons(IEnumerable<uint> weapons);

        /// <summary>
        /// Remove multiple weapons from the player.
        /// </summary>
        /// <param name="weapons">Weapons to remove</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> hashes is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveWeapons(IEnumerable<int> weapons);

        /// <summary>
        /// Remove all weapons from the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveAllWeapons();

        /// <summary>
        /// Check if given player is streamed.
        /// </summary>
        /// <param name="player">Player to check</param>
        /// <returns>True if the <paramref name="player" /> is streamed, otherwise false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="player" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsStreamed(IPlayer player);

        /// <summary>
        /// Remove object from the player.
        /// </summary>
        /// <param name="model">Model of the object</param>
        /// <param name="position">Position to search object in</param>
        /// <param name="radius">Radius to search object in</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveObject(uint model, Vector3 position, float radius);

        /// <summary>
        /// Remove object from the player.
        /// </summary>
        /// <param name="model">Model of the object</param>
        /// <param name="position">Position to search object in</param>
        /// <param name="radius">Radius to search object in</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveObject(int model, Vector3 position, float radius);

        /// <summary>
        /// Run code on the player.
        ///
        /// WARNING: Use this at your own risk.
        /// </summary>
        /// <param name="code">Code to execute on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="code" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void Eval(string code);

        /// <summary>
        /// Get the current list of players that can hear this current player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<IReadOnlyCollection<IPlayer>> GetVoiceListenersAsync();

        /// <summary>
        /// Enable the current players voice to the specified <paramref name="target"/> player.
        /// </summary>
        /// <param name="target">player that should listen the current players voice</param>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> is null</exception>
        /// <exception cref="EntityDeletedException"><paramref name="target"/> or this entity was deleted before</exception>
        Task EnableVoiceToAsync(IPlayer target);

        /// <summary>
        /// Disable the current players voice from the specified <paramref name="target"/> player
        /// </summary>
        /// <param name="target">Player that should not hear the current players voice anymore.</param>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> is null</exception>
        /// <exception cref="EntityDeletedException"><paramref name="target"/> or this entity was deleted before</exception>
        Task DisableVoiceToAsync(IPlayer target);
    }
}
