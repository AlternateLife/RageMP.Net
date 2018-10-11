using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Scripting.ScriptingClasses
{
    internal abstract class PoolBase<T> : IPool<T> where T : IEntity
    {
        protected readonly IntPtr _nativePointer;

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

        internal PoolBase(IntPtr nativePointer)
        {
            _nativePointer = nativePointer;
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
