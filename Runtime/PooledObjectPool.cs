using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworksXD.PoolXD
{
    public class PooledObjectPool : MonoBehaviour
    {
        [Header("Pool settings")]
        [SerializeField] private PooledObject PooledGameObject;
        [SerializeField] private int InitialSize;
        private Pool<PooledObject> Pool;

        private void Awake()
        {
            Pool = new Pool<PooledObject>(InstanceGetter, InitialSize, OnPutIntoPool, OnGotFromPool);
        }

        private PooledObject InstanceGetter()
        {
            var go = Instantiate(PooledGameObject, transform);
            return go;
        }

        private void OnPutIntoPool(PooledObject go)
        {
            go.OnPutIntoPool();
        }

        private void OnGotFromPool(PooledObject go)
        {
            go.OnGotFromPool();
        }

        public PooledObject Get()
        {
            return Pool.Get();
        }

        public void PutBack(PooledObject go)
        {
            Pool.PutBack(go);
        }
    }
}
