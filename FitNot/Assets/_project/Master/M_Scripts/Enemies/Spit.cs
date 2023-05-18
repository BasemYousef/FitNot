using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class Spit : MonoBehaviour
    {

        [SerializeField] private float life = 15;
        [SerializeField] private EnemyData spitterMummy;
        private void Awake()
        {
            Destroy(gameObject, life);
        }
        //private void OnTriggerStay(Collider other)
        //{
        //    if (other.CompareTag("Player"))
        //    {
        //        other.GetComponent<HealthManager>().TakeDamage(spitterMummy.damageValue);
        //        Destroy(gameObject, .5f);
        //    }
        //}
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<HealthManager>().TakeDamage(spitterMummy.damageValue);
                Destroy(gameObject);
            }
        }
    }

}
