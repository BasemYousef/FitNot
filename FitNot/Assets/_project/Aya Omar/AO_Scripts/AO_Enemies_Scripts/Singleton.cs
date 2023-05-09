using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;
        private void Awake()
        {
            RegisterSingleton();
        }

        protected void RegisterSingleton()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                //Destroy(gameObject);
            }
        }
    }

}
