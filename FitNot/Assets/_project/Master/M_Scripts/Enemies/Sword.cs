using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class Sword : MonoBehaviour
    {
        public WeaponStats mummyMeleeStats;
        //public LayerMask targetLayer;

        //private void Update()
        //{
        //    //PerformMeleeAttack();
        //}
        //private void PerformMeleeAttack()
        //{
        //    Ray ray = new Ray(transform.position, transform.forward);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, mummyMeleeStats.attackRange, targetLayer))
        //    {
        //        HealthManager targetHealth = hit.collider.GetComponent<HealthManager>();
        //        if (targetHealth != null)
        //        {
        //            targetHealth.TakeDamage(mummyMeleeStats.damage);
        //        }
        //    }
        //}
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<HealthManager>().TakeDamage(mummyMeleeStats.damage);
            }
        }
    }
}
