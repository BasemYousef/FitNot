using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class MeleeAttackAnimEvent : MonoBehaviour
    {
        [SerializeField] private Collider attackCollider;
        [SerializeField] private GameObject attackEffect;
        public void StartAttack()
        {
            // Enable the attack collider
            attackCollider.enabled = true;
            attackEffect.SetActive(true);

        }
        public void StopAttack()
        {
            // Disable the attack collider
            attackCollider.enabled = false;
            attackEffect.SetActive(false);

        }
    }
}
