using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Scripting.ScriptingClasses
{
    internal abstract class PoolBase<T> : IPool<T>, IInternalPool where T : IEntity
    {
        protected readonly IntPtr _nativePointer;
        protected readonly Plugin _plugin;

        private readonly ConcurrentDictionary<IntPtr, T> _entities = new ConcurrentDictionary<IntPtr, T>();

        public int Count => _entities.Count;

        public T this[int index] => _entities.Values.FirstOrDefault(x => x.Id == index);
        public T this[uint index] => this[(int) index];

        internal T this[IntPtr index]
        {
            get
            {
                if (_entities.TryGetValue(index, out T entity) == false)
                {
                    return default(T);
                }

                return entity;
            }
        }

        internal PoolBase(IntPtr nativePointer, Plugin plugin)
        {
            _nativePointer = nativePointer;
            _plugin = plugin;
        }

        public T GetAt(int index)
        {
            return GetAt((uint) index);
        }

        public T GetAt(uint index)
        {
            var pointer = Rage.Pool.Pool_GetAt(_nativePointer, index);

            if (_entities.TryGetValue(pointer, out T entity) == false)
            {
                return default(T);
            }

            return entity;
        }

        public bool AddEntity(IEntity entity)
        {
            if (entity is T correctEntity)
            {
                return _entities.TryAdd(correctEntity.NativePointer, correctEntity);
            }

            return false;
        }

        public IEntity GetEntity(IntPtr entity)
        {
            return this[entity];
        }

        public bool RemoveEntity(IntPtr entityPointer, Action<IEntity> preRemoveCallback)
        {
            if (_entities.TryGetValue(entityPointer, out T entity) == false)
            {
                return false;
            }

            preRemoveCallback?.Invoke(entity);

            return _entities.TryRemove(entityPointer, out _);
        }

        public bool CreateEntity(IntPtr entityPointer, out IEntity entity)
        {
            entity = TryCreateAndSaveEntity(entityPointer);

            if (entity == null)
            {
                entity = default(IEntity);
                return false;
            }

            return true;
        }

        protected abstract T BuildEntity(IntPtr entityPointer);

        protected virtual T TryCreateAndSaveEntity(IntPtr entityPointer)
        {
            if (_entities.TryGetValue(entityPointer, out var entity))
            {
                return entity;
            }

            entity = BuildEntity(entityPointer);

            if (_entities.TryAdd(entityPointer, entity) == false)
            {
                return default(T);
            }

            return entity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _entities.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
