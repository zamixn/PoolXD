using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworksXD.PoolXD
{
    public abstract class PooledObject : MonoBehaviour, IPooledObject
    {
        public virtual void OnPutIntoPool()
        {
            gameObject.SetActive(false);
        }

        public virtual void OnGotFromPool()
        {
            gameObject.SetActive(true);
        }
    }
}
