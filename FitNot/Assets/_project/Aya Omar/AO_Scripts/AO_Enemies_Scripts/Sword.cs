using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private EnemyData meleeMummy;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<HealthManager>().TakeDamage(meleeMummy.damageValue);
                
            }
        }
    }
}
