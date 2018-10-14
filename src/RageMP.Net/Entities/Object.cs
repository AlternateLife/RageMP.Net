using System;
using RageMP.Net.Enums;
using RageMP.Net.Interfaces;

namespace RageMP.Net.Entities
{
    internal class Object : Entity, IObject
    {
        internal Object(IntPtr nativePointer) : base(nativePointer, EntityType.Object)
        {
        }
    }
}
