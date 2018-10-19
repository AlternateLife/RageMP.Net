using System;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal class Object : Entity, IObject
    {
        internal Object(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.Object)
        {
        }
    }
}
