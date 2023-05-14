using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] public float health = 100f;

        bool isDead = false;

        public bool IsDead()
        {
            return isDead;
        }
        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            print(health);
            if (health == 0)
            {
                Die();
            }

        }

        private void Die()
        {
            if (isDead) return;

            GetComponent<Animator>().SetTrigger("die"); // using trigger for the death animation
            isDead = true;
        }
    }
}
