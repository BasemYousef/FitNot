using AyaOmar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

namespace Youssef
{
    public class NailsProjectile : MonoBehaviour
    {
        [SerializeField] GameObject enemyImpactVFX = null;
        [SerializeField] GameObject environmentImpactVFX = null;
        [SerializeField] WeaponStats weaponStats;
        private void Start()
        {
            Destroy(gameObject,3f);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "MeleeMummy" || other.gameObject.tag == "SpitterMummy")
            {
                GameObject cloneEnemyImpactVFX = Instantiate(enemyImpactVFX, gameObject.transform.position, gameObject.transform.rotation); //vfx
                other.gameObject.GetComponent<HealthManager>().TakeDamage(weaponStats.damage);
                AudioManager.Instance.PlaySpatialSfx("nail impact enemy", transform.position);
                Destroy(gameObject);
                Destroy(cloneEnemyImpactVFX, 2f);
            }
          
            GameObject cloneEnvironmentImpactVFX = Instantiate(environmentImpactVFX, gameObject.transform.position, gameObject.transform.rotation); //vfx
            AudioManager.Instance.PlaySpatialSfx("nail impact", transform.position);
            Destroy(gameObject);
            Destroy(cloneEnvironmentImpactVFX, 2f);
        
       
        }
        
    }
}
