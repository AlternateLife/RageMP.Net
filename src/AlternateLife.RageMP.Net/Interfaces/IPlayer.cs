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
        /// Set the name of the player.
        /// </summary>
        /// <param name="name">New name of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null or empty</exception>
        void SetName(string name);

        /// <summary>
        /// Set the name of the player.
        /// </summary>
        /// <param name="name">New name of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null or empty</exception>
        Task SetNameAsync(string name);

        /// <summary>
        /// Get the name of the player.
        /// </summary>
        /// <returns>Name of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string GetName();

        /// <summary>
        /// Get the name of the player.
        /// </summary>
        /// <returns>Name of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<string> GetNameAsync();

        /// <summary>
        /// Get the social club name of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string GetSocialClubName();

        /// <summary>
        /// Get the social club name of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<string> GetSocialClubNameAsync();

        /// <summary>
        /// Set the heading of the player.
        /// </summary>
        /// <param name="heading">New heading of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetHeading(float heading);

        /// <summary>
        /// Set the heading of the player.
        /// </summary>
        /// <param name="heading">New heading of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetHeadingAsync(float heading);

        /// <summary>
        /// Get the heading of the player.
        /// </summary>
        /// <returns>Heading of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetHeading();

        /// <summary>
        /// Get the heading of the player.
        /// </summary>
        /// <returns>Heading of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetHeadingAsync();

        /// <summary>
        /// Get the move speed of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetMoveSpeed();

        /// <summary>
        /// Get the move speed of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetMoveSpeedAsync();

        /// <summary>
        /// Set the health of the player.
        /// </summary>
        /// <param name="health">New health of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetHealth(float health);

        /// <summary>
        /// Set the health of the player.
        /// </summary>
        /// <param name="health">New health of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetHealthAsync(float health);

        /// <summary>
        /// Get the health of the player.
        /// </summary>
        /// <returns>Health of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetHealth();

        /// <summary>
        /// Get the health of the player.
        /// </summary>
        /// <returns>Health of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetHealthAsync();

        /// <summary>
        /// Set the armor of the player
        /// </summary>
        /// <param name="armor">New armor of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetArmor(float armor);

        /// <summary>
        /// Set the armor of the player
        /// </summary>
        /// <param name="armor">New armor of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetArmorAsync(float armor);

        /// <summary>
        /// Get the armor of the player.
        /// </summary>
        /// <returns>Armor of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetArmor();

        /// <summary>
        /// Get the armor of the player.
        /// </summary>
        /// <returns>Armor of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetArmorAsync();

        /// <summary>
        /// Set the model of the player.
        /// </summary>
        /// <param name="model">New model of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetModel(PedHash model);

        /// <summary>
        /// Set the model of the player.
        /// </summary>
        /// <param name="model">New model of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetModelAsync(PedHash model);

        /// <summary>
        /// Get the model of the player.
        /// </summary>
        /// <returns>Model of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        new PedHash GetModel();

        /// <summary>
        /// Get the model of the player.
        /// </summary>
        /// <returns>Model of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        new Task<PedHash> GetModelAsync();

        /// <summary>
        /// Get the position player is aiming at.
        /// </summary>
        /// <returns>Position the player is aiming at</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Vector3 GetAimingAt();

        /// <summary>
        /// Get the position player is aiming at.
        /// </summary>
        /// <returns>Position the player is aiming at</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<Vector3> GetAimingAtAsync();

        /// <summary>
        /// Get the ip of the player.
        /// </summary>
        /// <returns>Ip address of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string GetIp();

        /// <summary>
        /// Get the ip of the player.
        /// </summary>
        /// <returns>Ip address of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<string> GetIpAsync();

        /// <summary>
        /// Get the ping of the player.
        /// </summary>
        /// <returns>Ping of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        int GetPing();

        /// <summary>
        /// Get the ping of the player.
        /// </summary>
        /// <returns>Ping of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<int> GetPingAsync();

        /// <summary>
        /// Get the packet loss of the player.
        /// </summary>
        /// <returns>Packet loss of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetPacketLoss();

        /// <summary>
        /// Get the packet loss of the player.
        /// </summary>
        /// <returns>Packet loss of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetPacketLossAsync();

        /// <summary>
        /// Get the kick reason of the player.
        /// </summary>
        /// <returns>Kick reason for the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string GetKickReason();

        /// <summary>
        /// Get the kick reason of the player.
        /// </summary>
        /// <returns>Kick reason for the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<string> GetKickReasonAsync();

        /// <summary>
        /// Check if the player is jumping.
        /// </summary>
        /// <returns>True if the player is jumping, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsJumping();

        /// <summary>
        /// Check if the player is jumping.
        /// </summary>
        /// <returns>True if the player is jumping, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsJumpingAsync();

        /// <summary>
        /// Check if the player is in cover.
        /// </summary>
        /// <returns>True if the player is in cover, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsInCover();

        /// <summary>
        /// Check if the player is in cover.
        /// </summary>
        /// <returns>True if the player is in cover, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsInCoverAsync();

        /// <summary>
        /// Check if the player is entering a vehicle.
        /// </summary>
        /// <returns>True if the player is entering a vehicle, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsEnteringVehicle();

        /// <summary>
        /// Check if the player is entering a vehicle.
        /// </summary>
        /// <returns>True if the player is entering a vehicle, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsEnteringVehicleAsync();

        /// <summary>
        /// Check if the player is leaving a vehicle.
        /// </summary>
        /// <returns>True if the player is leaving a vehicle, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsLeavingVehicle();

        /// <summary>
        /// Check if the player is leaving a vehicle.
        /// </summary>
        /// <returns>True if the player is leaving a vehicle, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsLeavingVehicleAsync();

        /// <summary>
        /// Check if the player is climbing.
        /// </summary>
        /// <returns>True if the player is climbing, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsClimbing();

        /// <summary>
        /// Check if the player is climbing.
        /// </summary>
        /// <returns>True if the player is climbing, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsClimbingAsync();

        /// <summary>
        /// Check if the player is on a ladder.
        /// </summary>
        /// <returns>True if the player is on a ladder, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsOnLadder();

        /// <summary>
        /// Check if the player is on a ladder.
        /// </summary>
        /// <returns>True if the player is on a ladder, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsOnLadderAsync();

        /// <summary>
        /// Check if the player is reloading.
        /// </summary>
        /// <returns>True if the player is reloading, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsReloading();

        /// <summary>
        /// Check if the player is reloading.
        /// </summary>
        /// <returns>True if the player is reloading, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsReloadingAsync();

        /// <summary>
        /// Check if the player is in melee.
        /// </summary>
        /// <returns>True if the player is in melee, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsInMelee();

        /// <summary>
        /// Check if the player is in melee.
        /// </summary>
        /// <returns>True if the player is in melee, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsInMeleeAsync();

        /// <summary>
        /// Check if the player is aiming.
        /// </summary>
        /// <returns>True if the player is aiming, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsAiming();

        /// <summary>
        /// Check if the player is aiming.
        /// </summary>
        /// <returns>True if the player is aiming, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsAimingAsync();

        /// <summary>
        /// Set the eye color of the player.
        /// </summary>
        /// <param name="eyeColor">New eye color of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetEyeColor(uint eyeColor);

        /// <summary>
        /// Set the eye color of the player.
        /// </summary>
        /// <param name="eyeColor">New eye color of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetEyeColorAsync(uint eyeColor);

        /// <summary>
        /// Get the eye color of the player.
        /// </summary>
        /// <returns>Eye color of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetEyeColor();

        /// <summary>
        /// Get the eye color of the player.
        /// </summary>
        /// <returns>Eye color of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetEyeColorAsync();

        /// <summary>
        /// Get the hair color of the player.
        /// </summary>
        /// <returns>Hair color of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetHairColor();

        /// <summary>
        /// Get the hair color of the player.
        /// </summary>
        /// <returns>Hair color of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetHairColorAsync();

        /// <summary>
        /// Get the highlight color of the player.
        /// </summary>
        /// <returns>Hair highlight color of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetHairHighlightColor();

        /// <summary>
        /// Get the highlight color of the player.
        /// </summary>
        /// <returns>Hair highlight color of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetHairHighlightColorAsync();

        /// <summary>
        /// Set the <see cref="HeadBlendData"/> of the player.
        /// </summary>
        /// <param name="headBlend">New head blend of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetHeadBlend(HeadBlendData headBlend);

        /// <summary>
        /// Set the <see cref="HeadBlendData"/> of the player.
        /// </summary>
        /// <param name="headBlend">New head blend of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetHeadBlendAsync(HeadBlendData headBlend);

        /// <summary>
        /// Get the <see cref="HeadBlendData" /> of the player.
        /// </summary>
        /// <returns>Head blend of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        HeadBlendData GetHeadBlend();

        /// <summary>
        /// Get the <see cref="HeadBlendData" /> of the player.
        /// </summary>
        /// <returns>Head blend of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<HeadBlendData> GetHeadBlendAsync();

        /// <summary>
        /// Get the action string of the player.
        /// </summary>
        /// <returns>Action string of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string GetActionString();

        /// <summary>
        /// Get the action string of the player.
        /// </summary>
        /// <returns>Action string of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<string> GetActionStringAsync();

        /// <summary>
        /// Get the <see cref="IVehicle" /> the player is in or null if not in any vehicle.
        /// </summary>
        /// <returns>Vehicle the player is in</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IVehicle GetVehicle();

        /// <summary>
        /// Get the <see cref="IVehicle" /> the player is in or null if not in any vehicle.
        /// </summary>
        /// <returns>Vehicle the player is in</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<IVehicle> GetVehicleAsync();

        /// <summary>
        /// Check if the player is in any vehicle.
        /// </summary>
        /// <returns>True if the player is in any vehicle, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsInVehicle();

        /// <summary>
        /// Check if the player is in any vehicle.
        /// </summary>
        /// <returns>True if the player is in any vehicle, otherwise false</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsInVehicleAsync();

        /// <summary>
        /// Get the seat the player is on.
        /// </summary>
        /// <returns>Vehicle seat the player is on</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        int GetSeat();

        /// <summary>
        /// Get the seat the player is on.
        /// </summary>
        /// <returns>Vehicle seat the player is on</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<int> GetSeatAsync();

        /// <summary>
        /// Set the weapon the player has equipped.
        /// </summary>
        /// <param name="currentWeapon">Current weapon of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetCurrentWeapon(uint currentWeapon);

        /// <summary>
        /// Set the weapon the player has equipped.
        /// </summary>
        /// <param name="currentWeapon">Current weapon of the player</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetCurrentWeaponAsync(uint currentWeapon);

        /// <summary>
        /// Get the weapon the player has equipped.
        /// </summary>
        /// <returns>Current weapon of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetCurrentWeapon();

        /// <summary>
        /// Get the weapon the player has equipped.
        /// </summary>
        /// <returns>Current weapon of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetCurrentWeaponAsync();

        /// <summary>
        /// Set the ammo of the current weapon.
        /// </summary>
        /// <param name="ammo">New ammo of the current weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetCurrentWeaponAmmo(uint ammo);

        /// <summary>
        /// Set the ammo of the current weapon.
        /// </summary>
        /// <param name="ammo">New ammo of the current weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetCurrentWeaponAmmoAsync(uint ammo);

        /// <summary>
        /// Get the ammo of the current weapon.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetCurrentWeaponAmmo();

        /// <summary>
        /// Get the ammo of the current weapon.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetCurrentWeaponAmmoAsync();

        /// <summary>
        /// Kick the player.
        /// </summary>
        /// <param name="reason">Reason the player is kicked</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void Kick(string reason = null);

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
        void Ban(string reason = null);

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
        void OutputChatBox(string text);

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
        void Notify(string text);

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
        void Call(string eventName, params object[] arguments);

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
        void Call(string eventName, IEnumerable<object> arguments);

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
        void CallHash(ulong eventHash, params object[] arguments);

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
        void CallHash(ulong eventHash, IEnumerable<object> arguments);

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
        void Invoke(ulong nativeHash, params object[] arguments);

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
        void Invoke(ulong nativeHash, IEnumerable<object> arguments);

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
        /// Spawn the player at given position.
        /// </summary>
        /// <param name="position">Position to spawn the player at</param>
        /// <param name="heading">Heading to spawn the player with</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SpawnAsync(Vector3 position, float heading);

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
        /// Play an animation on the player.
        /// </summary>
        /// <param name="dictionary">Dictionary name of the animation</param>
        /// <param name="name">Name of the animation</param>
        /// <param name="speed">Speed of the animation</param>
        /// <param name="flags">Flags of the animation</param>
        /// <exception cref="ArgumentNullException"><paramref name="dictionary" /> or <paramref name="name" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task PlayAnimationAsync(string dictionary, string name, float speed = 8f, AnimationFlags flags = 0);

        /// <summary>
        /// Stop playing any animation on the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void StopAnimation();

        /// <summary>
        /// Stop playing any animation on the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task StopAnimationAsync();

        /// <summary>
        /// Play a scenario on the player.
        /// </summary>
        /// <param name="scenario">Name of the scenario</param>
        /// <exception cref="ArgumentNullException"><paramref name="scenario" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void PlayScenario(string scenario);

        /// <summary>
        /// Play a scenario on the player.
        /// </summary>
        /// <param name="scenario">Name of the scenario</param>
        /// <exception cref="ArgumentNullException"><paramref name="scenario" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task PlayScenarioAsync(string scenario);

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
        Task<ClothData> GetClothAsync(ClothSlot slot);

        /// <summary>
        /// Get cloth of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the cloth</param>
        /// <returns><see cref="ClothSlot" /> of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        ClothData GetCloth(int slot);

        /// <summary>
        /// Get cloth of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the cloth</param>
        /// <returns><see cref="ClothSlot" /> of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<ClothData> GetClothAsync(int slot);

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
        /// <param name="data">Value of the slot</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetClothAsync(ClothSlot slot, ClothData data);

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
        /// Set cloth of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the cloth</param>
        /// <param name="drawable">Drawable value of the cloth</param>
        /// <param name="texture">Texture value of the cloth</param>
        /// <param name="palette">Palette value of the cloth</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetClothAsync(ClothSlot slot, byte drawable, byte texture, byte palette);

        /// <summary>
        /// Set multiple clothes of the player.
        /// </summary>
        /// <param name="clothes">Clothes to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="clothes" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetClothes(IDictionary<ClothSlot, ClothData> clothes);

        /// <summary>
        /// Set multiple clothes of the player.
        /// </summary>
        /// <param name="clothes">Clothes to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="clothes" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetClothesAsync(IDictionary<ClothSlot, ClothData> clothes);

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
        Task<PropData> GetPropAsync(PropSlot slot);

        /// <summary>
        /// Get prop of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the prop</param>
        /// <returns><see cref="PropSlot" /> of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        PropData GetProp(int slot);

        /// <summary>
        /// Get prop of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the prop</param>
        /// <returns><see cref="PropSlot" /> of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<PropData> GetPropAsync(int slot);

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
        /// <param name="data">Value of the prop</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetPropAsync(PropSlot slot, PropData data);

        /// <summary>
        /// Set prop of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the prop</param>
        /// <param name="drawable">Drawable value of the prop</param>
        /// <param name="texture">Texture value of the prop</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetProp(PropSlot slot, byte drawable, byte texture);

        /// <summary>
        /// Set prop of the player at given slot.
        /// </summary>
        /// <param name="slot">Slot of the prop</param>
        /// <param name="drawable">Drawable value of the prop</param>
        /// <param name="texture">Texture value of the prop</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetPropAsync(PropSlot slot, byte drawable, byte texture);

        /// <summary>
        /// Set multiple props of the player.
        /// </summary>
        /// <param name="props">Props to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="props" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetProps(IDictionary<PropSlot, PropData> props);

        /// <summary>
        /// Set multiple props of the player.
        /// </summary>
        /// <param name="props">Props to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="props" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetPropsAsync(IDictionary<PropSlot, PropData> props);

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
        Task<uint> GetDecorationAsync(uint collection);

        /// <summary>
        /// Get the decoration of the player at given collection.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <returns>Decoration of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        int GetDecoration(int collection);

        /// <summary>
        /// Get the decoration of the player at given collection.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <returns>Decoration of the player</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<int> GetDecorationAsync(int collection);

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
        Task RemoveDecorationAsync(uint collection, uint overlay);

        /// <summary>
        /// Remove a decoration of the player.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <param name="overlay">Overlay value of the decoration</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveDecoration(int collection, int overlay);

        /// <summary>
        /// Remove a decoration of the player.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <param name="overlay">Overlay value of the decoration</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task RemoveDecorationAsync(int collection, int overlay);

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
        Task SetDecorationAsync(uint collection, uint overlay);

        /// <summary>
        /// Set a decoration on the player.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <param name="overlay">Overlay value of the decoration</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetDecoration(int collection, int overlay);

        /// <summary>
        /// Set a decoration on the player.
        /// </summary>
        /// <param name="collection">Collection of the decoration</param>
        /// <param name="overlay">Overlay value of the decoration</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetDecorationAsync(int collection, int overlay);

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
        Task SetDecorationsAsync(IDictionary<uint, uint> decorations);

        /// <summary>
        /// Set multiple decorations on the player.
        /// </summary>
        /// <param name="decorations">Decorations to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="decorations" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetDecorations(IDictionary<int, int> decorations);

        /// <summary>
        /// Set multiple decorations on the player.
        /// </summary>
        /// <param name="decorations">Decorations to set on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="decorations" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetDecorationsAsync(IDictionary<int, int> decorations);

        /// <summary>
        /// Removes all applied decorations from the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void ClearDecorations();

        /// <summary>
        /// Removes all applied decorations from the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task ClearDecorationsAsync();

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
        Task SetHairColorAsync(uint color, uint highlightColor);

        /// <summary>
        /// Set the hair color of the player.
        /// </summary>
        /// <param name="color">Color of the hair</param>
        /// <param name="highlightColor">Highlight color of the hair</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetHairColor(int color, int highlightColor);

        /// <summary>
        /// Set the hair color of the player.
        /// </summary>
        /// <param name="color">Color of the hair</param>
        /// <param name="highlightColor">Highlight color of the hair</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetHairColorAsync(int color, int highlightColor);

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
        Task<float> GetFaceFeatureAsync(uint id);

        /// <summary>
        /// Get a face feature of the player.
        /// </summary>
        /// <param name="id">Slot of the face feature</param>
        /// <returns>Value of the face feature</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetFaceFeature(int id);

        /// <summary>
        /// Get a face feature of the player.
        /// </summary>
        /// <param name="id">Slot of the face feature</param>
        /// <returns>Value of the face feature</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<float> GetFaceFeatureAsync(int id);

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
        Task SetFaceFeatureAsync(uint id, float scale);

        /// <summary>
        /// Set a face feature on the player.
        /// </summary>
        /// <param name="id">Slot of the face feature</param>
        /// <param name="scale">Value of the face feature</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetFaceFeature(int id, float scale);

        /// <summary>
        /// Set a face feature on the player.
        /// </summary>
        /// <param name="id">Slot of the face feature</param>
        /// <param name="scale">Value of the face feature</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetFaceFeatureAsync(int id, float scale);

        /// <summary>
        /// Update the head blend of the player.
        /// </summary>
        /// <param name="shapeMix">Shape mix of the head blend</param>
        /// <param name="skinMix">Skin mix of the head blend</param>
        /// <param name="thirdMix">Third mix of the head blend</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void UpdateHeadBlend(float shapeMix, float skinMix, float thirdMix);

        /// <summary>
        /// Update the head blend of the player.
        /// </summary>
        /// <param name="shapeMix">Shape mix of the head blend</param>
        /// <param name="skinMix">Skin mix of the head blend</param>
        /// <param name="thirdMix">Third mix of the head blend</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task UpdateHeadBlendAsync(float shapeMix, float skinMix, float thirdMix);

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
        Task<HeadOverlayData> GetHeadOverlayAsync(uint overlayId);

        /// <summary>
        /// Get the head overlay of the player.
        /// </summary>
        /// <param name="overlayId">Slot of the head overlay</param>
        /// <returns>Value of the <see cref="HeadOverlayData" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        HeadOverlayData GetHeadOverlay(int overlayId);

        /// <summary>
        /// Get the head overlay of the player.
        /// </summary>
        /// <param name="overlayId">Slot of the head overlay</param>
        /// <returns>Value of the <see cref="HeadOverlayData" /></returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<HeadOverlayData> GetHeadOverlayAsync(int overlayId);

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
        Task SetHeadOverlayAsync(uint overlayId, HeadOverlayData overlayData);

        /// <summary>
        /// Set the head overlay of the player.
        /// </summary>
        /// <param name="overlayId">Slot of the head overlay</param>
        /// <param name="overlayData">Value of the head overlay</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetHeadOverlay(int overlayId, HeadOverlayData overlayData);

        /// <summary>
        /// Set the head overlay of the player.
        /// </summary>
        /// <param name="overlayId">Slot of the head overlay</param>
        /// <param name="overlayData">Value of the head overlay</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetHeadOverlayAsync(int overlayId, HeadOverlayData overlayData);

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
        Task SetCustomizationAsync(bool isMale, HeadBlendData headBlend, uint eyeColor, uint hairColor, uint highlightColor, float[] faceFeatures,
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
        Task SetCustomizationAsync(bool isMale, HeadBlendData headBlend, int eyeColor, int hairColor, int highlightColor, float[] faceFeatures,
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
        /// Place player in given vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle to put the player into</param>
        /// <param name="seat">Seat the put the player on</param>
        /// <exception cref="ArgumentNullException"><paramref name="vehicle" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task PutIntoVehicleAsync(IVehicle vehicle, int seat);

        /// <summary>
        /// Remove the player from any vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveFromVehicle();

        /// <summary>
        /// Remove the player from any vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task RemoveFromVehicleAsync();

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
        Task<uint> GetWeaponAmmoAsync(WeaponHash weapon);

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
        Task<uint> GetWeaponAmmoAsync(uint weapon);

        /// <summary>
        /// Get the ammo of given weapon.
        /// </summary>
        /// <param name="weapon">Weapon to get the ammo for</param>
        /// <returns>Ammo of the weapon</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        int GetWeaponAmmo(int weapon);

        /// <summary>
        /// Get the ammo of given weapon.
        /// </summary>
        /// <param name="weapon">Weapon to get the ammo for</param>
        /// <returns>Ammo of the weapon</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<int> GetWeaponAmmoAsync(int weapon);

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
        Task SetWeaponAmmoAsync(WeaponHash weapon, uint ammo);

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
        Task SetWeaponAmmoAsync(WeaponHash weapon, int ammo);

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
        Task SetWeaponAmmoAsync(uint weapon, uint ammo);

        /// <summary>
        /// Set the ammo of given weapon.
        /// </summary>
        /// <param name="weapon">Weapon to set the ammo for</param>
        /// <param name="ammo">Ammo for the weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetWeaponAmmo(int weapon, int ammo);

        /// <summary>
        /// Set the ammo of given weapon.
        /// </summary>
        /// <param name="weapon">Weapon to set the ammo for</param>
        /// <param name="ammo">Ammo for the weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetWeaponAmmoAsync(int weapon, int ammo);

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
        Task GiveWeaponAsync(WeaponHash weapon, uint ammo);

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
        Task GiveWeaponAsync(WeaponHash weapon, int ammo);

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
        Task GiveWeaponAsync(uint weapon, uint ammo);

        /// <summary>
        /// Give a weapon to the player.
        /// </summary>
        /// <param name="weapon">Weapon to give the player</param>
        /// <param name="ammo">Ammo of the given weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void GiveWeapon(int weapon, int ammo);

        /// <summary>
        /// Give a weapon to the player.
        /// </summary>
        /// <param name="weapon">Weapon to give the player</param>
        /// <param name="ammo">Ammo of the given weapon</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task GiveWeaponAsync(int weapon, int ammo);

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
        Task GiveWeaponsAsync(IDictionary<WeaponHash, uint> weapons);

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
        Task GiveWeaponsAsync(IDictionary<WeaponHash, int> weapons);

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
        Task GiveWeaponsAsync(IDictionary<uint, uint> weapons);

        /// <summary>
        /// Give multiple weapons to the player.
        /// </summary>
        /// <param name="weapons">Key value set of weapons with ammo</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void GiveWeapons(IDictionary<int, int> weapons);

        /// <summary>
        /// Give multiple weapons to the player.
        /// </summary>
        /// <param name="weapons">Key value set of weapons with ammo</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task GiveWeaponsAsync(IDictionary<int, int> weapons);

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
        Task RemoveWeaponAsync(WeaponHash weapon);

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
        Task RemoveWeaponAsync(uint weapon);

        /// <summary>
        /// Remove a weapon from the player.
        /// </summary>
        /// <param name="weapon">Weapon to remove</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveWeapon(int weapon);

        /// <summary>
        /// Remove a weapon from the player.
        /// </summary>
        /// <param name="weapon">Weapon to remove</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task RemoveWeaponAsync(int weapon);

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
        Task RemoveWeaponsAsync(IEnumerable<WeaponHash> weapons);

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
        Task RemoveWeaponsAsync(IEnumerable<uint> weapons);

        /// <summary>
        /// Remove multiple weapons from the player.
        /// </summary>
        /// <param name="weapons">Weapons to remove</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> hashes is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveWeapons(IEnumerable<int> weapons);

        /// <summary>
        /// Remove multiple weapons from the player.
        /// </summary>
        /// <param name="weapons">Weapons to remove</param>
        /// <exception cref="ArgumentNullException"><paramref name="weapons" /> hashes is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task RemoveWeaponsAsync(IEnumerable<int> weapons);

        /// <summary>
        /// Remove all weapons from the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveAllWeapons();

        /// <summary>
        /// Remove all weapons from the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task RemoveAllWeaponsAsync();

        /// <summary>
        /// Check if given player is streamed.
        /// </summary>
        /// <param name="player">Player to check</param>
        /// <returns>True if the <paramref name="player" /> is streamed, otherwise false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="player" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool IsStreamed(IPlayer player);

        /// <summary>
        /// Check if given player is streamed.
        /// </summary>
        /// <param name="player">Player to check</param>
        /// <returns>True if the <paramref name="player" /> is streamed, otherwise false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="player" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<bool> IsStreamedAsync(IPlayer player);

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
        Task RemoveObjectAsync(uint model, Vector3 position, float radius);

        /// <summary>
        /// Remove object from the player.
        /// </summary>
        /// <param name="model">Model of the object</param>
        /// <param name="position">Position to search object in</param>
        /// <param name="radius">Radius to search object in</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void RemoveObject(int model, Vector3 position, float radius);

        /// <summary>
        /// Remove object from the player.
        /// </summary>
        /// <param name="model">Model of the object</param>
        /// <param name="position">Position to search object in</param>
        /// <param name="radius">Radius to search object in</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task RemoveObjectAsync(int model, Vector3 position, float radius);

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
        /// Run code on the player.
        ///
        /// WARNING: Use this at your own risk.
        /// </summary>
        /// <param name="code">Code to execute on the player</param>
        /// <exception cref="ArgumentNullException"><paramref name="code" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task EvalAsync(string code);

        /// <summary>
        /// Get the current list of players that can hear this current player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IReadOnlyCollection<IPlayer> GetVoiceListeners();

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
        void EnableVoiceTo(IPlayer target);

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
        void DisableVoiceTo(IPlayer target);

        /// <summary>
        /// Disable the current players voice from the specified <paramref name="target"/> player
        /// </summary>
        /// <param name="target">Player that should not hear the current players voice anymore.</param>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> is null</exception>
        /// <exception cref="EntityDeletedException"><paramref name="target"/> or this entity was deleted before</exception>
        Task DisableVoiceToAsync(IPlayer target);

        /// <summary>
        /// Get all weapons of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IReadOnlyDictionary<WeaponHash, uint> GetWeapons();

        /// <summary>
        /// Get all weapons of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<IReadOnlyDictionary<WeaponHash, uint>> GetWeaponsAsync();

        /// <summary>
        /// Get all streamed players of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IReadOnlyCollection<IPlayer> GetStreamedPlayers();

        /// <summary>
        /// Get all streamed players of the player.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<IReadOnlyCollection<IPlayer>> GetStreamedPlayersAsync();
    }
}
