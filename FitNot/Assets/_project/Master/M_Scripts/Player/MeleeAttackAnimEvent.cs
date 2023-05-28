using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class MeleeAttackAnimEvent : MonoBehaviour
    {
        [SerializeField] private Collider attackCollider;
        public void StartAttack()
        {
            // Enable the attack collider
            attackCollider.enabled = true;

        }
        public void StopAttack()
        {
            // Disable the attack collider
            attackCollider.enabled = false;

        }
    }
}
