using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class NailsProjectile : MonoBehaviour
    {
        [SerializeField] private float nailDamage = 10f;
        [SerializeField] GameObject enemyImpactVFX = null;
        [SerializeField] GameObject environmentImpactVFX = null;
        private void Start()
        {
            Destroy(gameObject,3f);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
            Instantiate(enemyImpactVFX, gameObject.transform.position, gameObject.transform.rotation); //vfx
            other.gameObject.GetComponent<HealthManager>().TakeDamage(nailDamage);
            Destroy(gameObject);
            Destroy(enemyImpactVFX, 2f);
            }
            Instantiate(environmentImpactVFX, gameObject.transform.position, gameObject.transform.rotation); //vfx
            Destroy(gameObject);
            Destroy(environmentImpactVFX, 2f);
        }
    }
}
