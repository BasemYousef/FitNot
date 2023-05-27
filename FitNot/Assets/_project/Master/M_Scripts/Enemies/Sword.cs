using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class Sword : MonoBehaviour
    {
        public WeaponStats mummyMeleeStats;

        [SerializeField] private GameObject bloodVFX;
        [SerializeField] private Transform bloodVFXTransform;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<HealthManager>().TakeDamage(mummyMeleeStats.damage);
                GameObject cloneBloodVFX = Instantiate(bloodVFX, bloodVFXTransform.position, bloodVFXTransform.rotation); 
                Destroy(cloneBloodVFX,0.5f);
            }
        }
    }
}
