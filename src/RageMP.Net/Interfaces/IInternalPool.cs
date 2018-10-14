using System;

namespace RageMP.Net.Interfaces
{
    internal interface IInternalPool
    {
        bool AddEntity(IEntity entity);
        IEntity GetEntity(IntPtr entity);
        bool RemoveEntity(IntPtr entity, Action<IEntity> preRemoveCallback);
        bool CreateEntity(IntPtr entityPointer, out IEntity entity);
    }
}
