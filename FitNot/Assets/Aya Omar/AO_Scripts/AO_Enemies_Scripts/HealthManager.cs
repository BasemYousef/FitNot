using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class HealthManager : Singleton<HealthManager>
    {
        private void Awake()
        {
            base.RegisterSingleton();
        }
        public void TakeDamage(float damage)
        {

        }
        public void Die()
        {

        }
    }

}
