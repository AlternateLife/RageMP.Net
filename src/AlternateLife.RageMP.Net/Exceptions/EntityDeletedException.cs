using System;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Exceptions
{
    public class EntityDeletedException : Exception
    {
        internal EntityDeletedException(IEntity entity) : base($"This entity ({entity.Type.ToString()}: ID {entity.Id}) does not exist anymore!")
        {

        }

        internal EntityDeletedException(IEntity entity, string parameterName) : base($"Parameter {parameterName}: This entity ({entity.Type.ToString()}: ID {entity.Id}) does not exist anymore!")
        {

        }
    }
}
