using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;

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
        /// Get the entity id.
        /// </summary>
        uint Id { get; }

        /// <summary>
        /// Get the entity type.
        /// </summary>
        EntityType Type { get; }

        /// <summary>
        /// Get or set the model of the entity.
        /// </summary>
        uint Model { get; set; }

        /// <summary>
        /// Get or set the alpha of the entity.
        /// </summary>
        uint Alpha { get; set; }

        /// <summary>
        /// Get or set the dimension of the entity.
        /// </summary>
        uint Dimension { get; set; }

        /// <summary>
        /// Get or set the position of the entity.
        /// </summary>
        Vector3 Position { get; set; }

        /// <summary>
        /// Get or set the rotation of the entity.
        /// </summary>
        Vector3 Rotation { get; set; }

        /// <summary>
        /// Get the velocity of the entity.
        /// </summary>
        Vector3 Velocity { get; }

        /// <summary>
        /// Destroy the entity.
        /// </summary>
        Task Destroy();

        /// <summary>
        /// Get shared data of the entity.
        /// </summary>
        /// <param name="key">Key of the data</param>
        /// <param name="data">Value of the data</param>
        /// <returns>True if any <paramref name="data" /> is set and not null, otherwise false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
        bool TryGetSharedData(string key, out object data);

        /// <summary>
        /// Set shared data on the entity.
        /// </summary>
        /// <param name="key">Key of the data</param>
        /// <param name="data">Value of the data</param>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
        void SetSharedData(string key, object data);

        /// <summary>
        /// Set multiple shared data on the entity.
        /// </summary>
        /// <param name="values">Key value pairs to set</param>
        /// <exception cref="ArgumentNullException"><paramref name="values" /> is null</exception>
        void SetSharedData(IDictionary<string, object> values);

        /// <summary>
        /// Check if shared data is set on the entity.
        /// </summary>
        /// <param name="key">Key of the data</param>
        /// <returns>True if any data is set and not null, otherwise false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
        bool HasSharedData(string key);

        /// <summary>
        /// Reset the shared data of the entity.
        /// </summary>
        /// <param name="key">Key of the data to reset</param>
        /// <exception cref="ArgumentNullException"><paramref name="key" /> is null or empty</exception>
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
