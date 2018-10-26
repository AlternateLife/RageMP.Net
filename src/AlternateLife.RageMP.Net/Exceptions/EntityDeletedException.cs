using System;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Exceptions
{
    public class EntityDeletedException : Exception
    {
        internal EntityDeletedException(IEntity entity) : base($"This entity ({entity.Type.ToString()}: ID {entity.Id}) does not exist anymore!")
        {

        }
    }
}
