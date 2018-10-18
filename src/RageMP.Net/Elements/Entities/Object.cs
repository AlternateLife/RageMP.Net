using System;
using RageMP.Net.Enums;
using RageMP.Net.Interfaces;

namespace RageMP.Net.Elements.Entities
{
    internal class Object : Entity, IObject
    {
        internal Object(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Object)
        {
        }
    }
}
