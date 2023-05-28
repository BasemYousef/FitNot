using AyaOmar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Youssef
{
    public class NailGun : MonoBehaviour
    {
        [SerializeField] WeaponStats weaponStats;
        [SerializeField] private InputAction shoot = new InputAction();
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] Transform projectileSpawnPoint;
        [SerializeField] float projectileSpeed = 10f;
        [SerializeField] float fireRate = 0.1f;

        private int currentDurAbility;
        private Animator animator;
        private bool isOutOfAmmo = false;
        private float fireTimer;

        private void Start()
        {
           // player = GetComponentInParent<Animator>();  
            animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            currentDurAbility = weaponStats.projectileCount;
            animator.runtimeAnimatorController = GameManager.Instance.GetRangedPlayerAnimator();
        }
        private void OnEnable()
        {
            shoot.Enable();
        }

        private void OnDisable()
        {
            shoot.Disable();
        }
        private void Update()
        {
            fireTimer += Time.deltaTime;
            InventoryUIManager.Instance.txt_Durability.text = currentDurAbility.ToString();
            if (shoot.triggered && fireTimer >= fireRate && currentDurAbility > 0)
            {

                fireTimer = 0f;
                currentDurAbility--;
                animator.SetBool("Ranged", true);
                GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                AudioManager.Instance.PlaySpatialSfx("nail gun shot", transform.position);
                Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
                projectileRigidbody.velocity = projectileSpawnPoint.up * projectileSpeed;
               

            }
            else
            {
                animator.SetBool("Ranged", false);
            }
            if(currentDurAbility == 0)
            {
                animator.SetBool("Ranged", false);
                isOutOfAmmo = true;
                gameObject.SetActive(false);
                animator.runtimeAnimatorController = GameManager.Instance.GetMeleePlayerAnimator();
                currentDurAbility = weaponStats.durability;
            }
            InventoryUIManager.Instance.txt_Durability.text = currentDurAbility.ToString();
        }
        
    }
}
