using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class ObjectPool : MonoBehaviour
    {
        public Spit prefab; // The prefab to be pooled
        public int poolSize = 10; // The initial size of the object pool

        public Transform poolParent;
        private List<Spit> pooledObjects;

        private void Awake()
        {
            pooledObjects = new List<Spit>();

            for (int i = 0; i < poolSize; i++)
            {
                Spit obj = Instantiate(prefab);
                obj.gameObject.transform.parent = poolParent.parent;
                obj.gameObject.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        public Spit GetObjectFromPool()
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                
                if (!pooledObjects[i].gameObject.activeInHierarchy)
                {
                    pooledObjects[i].gameObject.SetActive(true);
                    return pooledObjects[i];
                }
            }

            // If no inactive object is found, create a new one
            Spit newObj = Instantiate(prefab);
            pooledObjects.Add(newObj);
            return newObj;
        }

        public void ReturnObjectToPool(Spit obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
