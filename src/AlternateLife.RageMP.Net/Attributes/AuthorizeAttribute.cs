using System;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Attributes
{
    /// <summary>
    /// Attribute to only allow the usage of a command or command handler when the player is authorized.
    /// Only works on ReflectionCommands and CommandHandlers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public abstract class AuthorizeAttribute : Attribute
    {
        public abstract bool IsPlayerAuthorized(IPlayer player);
    }
}