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
                Vector3 bloodpos = other.transform.position;
                bloodpos.y = bloodpos.y + 1f;
                other.GetComponent<HealthManager>().TakeDamage(mummyMeleeStats.damage);
                GameObject cloneBloodVFX = Instantiate(bloodVFX,bloodpos,Quaternion.identity);
                AudioManager.Instance.Play2DPingPongSfx("enemy melee hit");
                Destroy(cloneBloodVFX,0.5f);
            }
        }
    }
}
