using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworksXD.PoolXD
{
    public class Pool<T>
    {
        private List<T> Unused;
        private List<T> All;

        private Func<T> InstanceGetter;
        private Action<T> OnPutIntoPool;
        private Action<T> OnGotBackFromPool;

        public const int DefaultPoolSize = 10;

        public Pool(Func<T> instanceGetter, int poolSize = DefaultPoolSize, Action<T> onPutBack = null, Action<T> onGotFromPool = null)
        {
            InstanceGetter = instanceGetter;
            OnPutIntoPool = onPutBack;
            OnGotBackFromPool = onGotFromPool;

            All = new List<T>();
            for (int i = 0; i < poolSize; i++)
                All.Add(InstanceGetter.Invoke());

            Unused = new List<T>();
            foreach (var t in All)
            {
                PutBack(t);
            }
        }

        /// <summary>
        /// Puts back element into pool
        /// </summary>
        /// <param name="t"></param>
        public void PutBack(T t)
        {
            if (t == null)
            {
                Debug.LogError("Tried to put a null into a pool. Not allowed");
                return;
            }
            OnPutIntoPool?.Invoke(t);
            Unused.Add(t);
        }

        /// <summary>
        /// Gets an unused element from the pool
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            SpawnIfNeeded();
            T t = Unused[0];
            Unused.RemoveAt(0);
            OnGotBackFromPool?.Invoke(t);
            return t;
        }

        private void SpawnIfNeeded()
        {
            if (Unused.Count == 0)
            {
                var t = InstanceGetter.Invoke();
                All.Add(t);
                Unused.Add(t);
            }
        }

    }
}