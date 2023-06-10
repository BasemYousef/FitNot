using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class UnarmedAttackAnimEvent : MonoBehaviour
    {
        [SerializeField] private Collider unarmedCollider;
        [SerializeField] private GameObject attackEffect;
        public void StartUnarmedAttack()
        {
            // Enable the attack collider
            unarmedCollider.enabled = true;
            attackEffect.SetActive(true);

        }
        public void StopUnarmedAttack()
        {
            // Disable the attack collider
            unarmedCollider.enabled = false;
            attackEffect.SetActive(false);

        }
    }
}
