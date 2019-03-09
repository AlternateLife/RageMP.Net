using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IEntity
    {
        /// <summary>
        /// Get the internal entity pointer.
        ///
        /// WARNING: Do NOT use this.
        /// </summary>
        IntPtr NativePointer { get; }

        /// <summary>
        /// Get current entity existance
        ///
        /// WARNING: Do NOT use this.
        /// </summary>
        bool Exists { get; }

        /// <summary>
        /// Get the entity id.
        /// </summary>
        uint Id { get; }

        /// <summary>
        /// Get the entity type.
        /// </summary>
        EntityType Type { get; }

        /// <summary>
        /// Set the model the the entity.
        /// </summary>
        /// <param name="model">New model of the entity</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetModelAsync(uint model);

        /// <summary>
        /// Get the model of the entity.
        /// </summary>
        /// <returns>Model of the entity</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetModelAsync();

        /// <summary>
        /// Set the alpha of the entity.
        /// </summary>
        /// <param name="alpha">New alpha of the entity</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetAlphaAsync(uint alpha);

        /// <summary>
        /// Get the alpha of the entity.
        /// </summary>
        /// <returns>Alpha of the entity</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetAlphaAsync();

        /// <summary>
        /// Set the dimension of the entity.
        /// </summary>
        /// <param name="dimension">New Dimension of the entity</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetDimensionAsync(uint dimension);

        /// <summary>
        /// Get the dimension of the entity.
        /// </summary>
        /// <returns>Dimension of the entity</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<uint> GetDimensionAsync();

        /// <summary>
        /// Set the position of the entity.
        /// </summary>
        /// <param name="position">New position of the entity</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetPositionAsync(Vector3 position);

        /// <summary>
        /// Get the position of the entity.
        /// </summary>
        /// <returns>Position of the entity</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<Vector3> GetPositionAsync();

        /// <summary>
        /// Set the rotation of the entity.
        /// </summary>
        /// <param name="rotation">New rotation of the entity</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task SetRotationAsync(Vector3 rotation);

        /// <summary>
        /// Get the rotation of the entity.
        /// </summary>
        /// <returns>Rotation of the entity</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<Vector3> GetRotationAsync();

        /// <summary>
        /// Get the velocity of the entity.
        /// </summary>
        /// <returns>Velocity of the entity</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task<Vector3> GetVelocityAsync();

        /// <summary>
        /// Destroy the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Task DestroyAsync();

        /// <summary>
        /// Get shared data of the entity.
        /// </summary>
        /// <param name="key">Key of the data</param>
        /// <param name="data">Value of the data</param>
        /// <returns>True if any <paramref name="data" /> is set and not null, otherwise false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool TryGetSharedData(string key, out object data);

        /// <summary>
        /// Set shared data on the entity.
        /// </summary>
        /// <param name="key">Key of the data</param>
        /// <param name="data">Value of the data</param>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetSharedData(string key, object data);

        /// <summary>
        /// Set multiple shared data on the entity.
        /// </summary>
        /// <param name="values">Key value pairs to set</param>
        /// <exception cref="ArgumentNullException"><paramref name="values" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetSharedData(IDictionary<string, object> values);

        /// <summary>
        /// Check if shared data is set on the entity.
        /// </summary>
        /// <param name="key">Key of the data</param>
        /// <returns>True if any data is set and not null, otherwise false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool HasSharedData(string key);

        /// <summary>
        /// Reset the shared data of the entity.
        /// </summary>
        /// <param name="key">Key of the data to reset</param>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void ResetSharedData(string key);

        /// <summary>
        /// Get data of the entity.
        /// </summary>
        /// <param name="key">Key of the data</param>
        /// <param name="data">Value of the data</param>
        /// <returns>True if any <paramref name="data" /> is set, otherwise false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
        bool TryGetData(string key, out object data);

        /// <summary>
        /// Set data on the entity.
        /// </summary>
        /// <param name="key">Key of the data</param>
        /// <param name="data">Value of the data</param>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
        void SetData(string key, object data);

        /// <summary>
        /// Set multiple data on the entity.
        /// </summary>
        /// <param name="values">Key value pairs to set</param>
        /// <exception cref="ArgumentNullException"><paramref name="values" /> is null</exception>
        void SetData(IDictionary<string, object> values);

        /// <summary>
        /// Check if data is set on the entity.
        /// </summary>
        /// <param name="key">Key of the data</param>
        /// <returns>True if any data is set, otherwise false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
        bool HasData(string key);

        /// <summary>
        /// Reset data of the entity.
        /// </summary>
        /// <param name="key">Key of the data</param>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
        void ResetData(string key);

        /// <summary>
        /// Clear all data of the entity.
        ///
        /// This does NOT clear the shared data.
        /// </summary>
        void ClearData();
    }
}
