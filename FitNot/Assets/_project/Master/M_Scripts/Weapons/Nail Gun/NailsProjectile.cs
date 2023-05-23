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
            //Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
            //Vector3 targetDirection = new Vector3(mouseWorldPosition.x - transform.position.x, 0f, mouseWorldPosition.z - transform.position.z);
            //transform.LookAt(targetDirection );
            Destroy(gameObject,3f);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "MeleeMummy" || other.gameObject.tag == "SpitterMummy")
            {
            GameObject cloneEnemyImpactVFX = Instantiate(enemyImpactVFX, gameObject.transform.position, gameObject.transform.rotation); //vfx
            other.gameObject.GetComponent<HealthManager>().TakeDamage(nailDamage);
            Destroy(gameObject);
            Destroy(cloneEnemyImpactVFX, 2f);
            }
            GameObject cloneEnvironmentImpactVFX = Instantiate(environmentImpactVFX, gameObject.transform.position, gameObject.transform.rotation); //vfx
            Destroy(gameObject);
            Destroy(cloneEnvironmentImpactVFX, 2f);
        }
    }
}
