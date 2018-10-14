using System;

namespace RageMP.Net.Interfaces
{
    internal interface IInternalPool
    {
        bool AddEntity(IEntity entity);
        IEntity GetEntity(IntPtr entity);
        bool RemoveEntity(IntPtr entity, Action<IEntity> preRemoveCallback);
        bool CreateAndSaveEntity(IntPtr entityPointer, out IEntity entity);
    }
}
