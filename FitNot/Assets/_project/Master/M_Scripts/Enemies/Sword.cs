using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class Sword : MonoBehaviour
    {
        public WeaponStats mummyMeleeStats;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<HealthManager>().TakeDamage(mummyMeleeStats.damage);
            }
        }
    }
}
