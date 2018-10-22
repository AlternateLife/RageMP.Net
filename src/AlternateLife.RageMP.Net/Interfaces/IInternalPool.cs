using System;

namespace AlternateLife.RageMP.Net.Interfaces
{
    internal interface IInternalPool
    {
        IEntity GetEntity(IntPtr entity);
        bool RemoveEntity(IntPtr entity, Action<IEntity> preRemoveCallback);
        bool CreateAndSaveEntity(IntPtr entityPointer, out IEntity entity);
    }
}
