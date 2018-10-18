using System;
using System.Collections.Generic;
using System.Numerics;
using RageMP.Net.Enums;

namespace RageMP.Net.Interfaces
{
    public interface IEntity
    {
        IntPtr NativePointer { get; }
        uint Id { get; }
        EntityType Type { get; }

        uint Model { get; set; }
        uint Alpha { get; set; }

        uint Dimension { get; set; }
        Vector3 Position { get; set; }
        Vector3 Rotation { get; set; }
        Vector3 Velocity { get; }

        void Destroy();

        object GetSharedData(string key);
        void SetSharedData(string key, object data);
        void SetSharedData(Dictionary<string, object> values);
        bool HasSharedData(string key);
        void ResetSharedData(string key);
    }
}
