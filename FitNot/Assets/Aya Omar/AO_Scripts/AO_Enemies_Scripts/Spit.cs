using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class Spit : MonoBehaviour
    {

        [SerializeField] private float life = 5;
        private void Awake()
        {
            Destroy(gameObject, life);
        }
        private void Start()
        {
        
        }
        void Update()
        {
        
        }
    }

}
