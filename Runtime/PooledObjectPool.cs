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
        private Pool<IPooledObject> Pool;

        private void Awake()
        {
            Pool = new Pool<IPooledObject>(InstanceGetter, InitialSize, OnPutIntoPool, OnGotFromPool);
        }

        private IPooledObject InstanceGetter()
        {
            var go = Instantiate(PooledGameObject.gameObject, transform);
            var po = go.GetComponent<PooledObject>();
            return po as IPooledObject;
        }

        private void OnPutIntoPool(IPooledObject go)
        {
            go.OnPutIntoPool();
        }

        private void OnGotFromPool(IPooledObject go)
        {
            go.OnGotFromPool();
        }

        public IPooledObject Get()
        {
            return Pool.Get();
        }

        public void PutBack(PooledObject go)
        {
            Pool.PutBack(go);
        }
    }
}
