using System.Collections.Generic;
using System.Numerics;
using RageMP.Net.Enums;

namespace RageMP.Net.Interfaces
{
    public interface IEntity
    {
        uint Id { get; }
        EntityType Type { get; }

        uint Model { get; set; }
        uint Alpha { get; set; }

        uint Dimension { get; set; }
        Vector3 Position { get; set; }
        Vector3 Rotation { get; set; }
        Vector3 Velocity { get; }

        void Destroy();

        object GetVariable(string key);
        void SetVariable(string key, object data);
        void SetVariables(Dictionary<string, object> values);
        bool HasVariable(string key);
    }
}
