using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworksXD.PoolXD
{
    public interface IPooledObject
    {
        public abstract void OnPutIntoPool();

        public abstract void OnGotFromPool();

    }
}
