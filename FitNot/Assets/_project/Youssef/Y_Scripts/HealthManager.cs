using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

namespace Youssef
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] public float health = 100f;
        public Slider healthBar;

        private float startingHealth;

        bool isDead = false;

        private void Start()
        {
            startingHealth = health;
            healthBar.maxValue = startingHealth;
            healthBar.value = health;
        }
        public bool IsDead()
        {
            return isDead;
        }
        public void TakeDamage(float damage)
        {
            health -= damage; 
            health = Mathf.Max(health, 0);
            UpdateHealthLevel(health);
            print("Health :" +health);
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
        public void Heal(float healingAmount)
        {
            health = Mathf.Clamp(health + healingAmount, 0, startingHealth);
            UpdateHealthLevel(health);
            print(health);
        }
        public void UpdateHealthLevel(float newHealthLevel)
        {
            health = newHealthLevel;
            health = Mathf.Clamp(health, 0, startingHealth);
            healthBar.value = health;
        }
    }
}
