using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Youssef
{
    public class HealthManager : MonoBehaviour
    {
        public float startingHealth = 0f;
        public float health;
        public Slider healthBar = null;
        public EnemyData characterData;
        public bool isDead = false;

        public bool isPlayer;
        [SerializeField] private GameObject deathEffect;
        private void Start()
        {
            if (isPlayer)
            {
                health = characterData.maxHealth;
                startingHealth = health;
                if (healthBar != null)
                {
                    healthBar.maxValue = startingHealth;
                    healthBar.value = health;
                }

            }
            Debug.Log("health manager start");
        }
        public bool IsDead()
        {
            return isDead;
        }
        public void TakeDamage(float damage)
        {
            health -= damage;
            health = Mathf.Max(health, 0);
            if (healthBar != null) { UpdateHealthLevel(health); }
            print("Health :" + health);
            if (health == 0)
            {
                Die();
            }

        }

        private void Die()
        {
            if (isDead) return;

            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("die"); // using trigger for the death animation
            isDead = true;
            GameObject deathVFX = Instantiate(deathEffect,transform.position + Vector3.up *0.45f,deathEffect.transform.rotation);
            Destroy(animator.gameObject, 2.37f);
            Destroy(deathVFX, 2.5f);
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

        public void SetMaxHealth(float maxHealth)
        {
            startingHealth = maxHealth;
            health = maxHealth;
            Debug.Log(maxHealth);
            if (healthBar != null)
            {
                healthBar.maxValue = maxHealth;
                healthBar.value = health;
            }
        }
    }
}
