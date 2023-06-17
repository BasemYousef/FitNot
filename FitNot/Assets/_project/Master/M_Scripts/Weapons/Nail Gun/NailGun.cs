using AyaOmar;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        [SerializeField] float projectileSpeed = .1f;
        [SerializeField] float fireRate = 0.1f;
        [SerializeField] GameObject muzzleFlashVFX;

        
        private GameObject aimPosition;
        private GameObject playerRef;
        private int currentDurAbility;
        private Animator animator;
        private bool isOutOfAmmo = false;
        private float fireTimer;
        private float rotationAngle;
        private float fillAmount;
        private void Start()
        {
           
            animator = GameManager.Instance.GetPlayerRef().GetComponent<Animator>();
            currentDurAbility = weaponStats.projectileCount;
            animator.runtimeAnimatorController = GameManager.Instance.GetRangedPlayerAnimator();
            aimPosition = GameManager.Instance.GetAimObjectRef();
            playerRef = GameManager.Instance.GetPlayerRef();
            
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
            
            fillAmount = currentDurAbility / 10f;
            InventoryUIManager.Instance.img_Durability.fillAmount = fillAmount;
            if (shoot.triggered && fireTimer >= fireRate && currentDurAbility > 0)
            {
                SnapToAim();
               
                fireTimer = 0f;
                currentDurAbility--;
                animator.SetBool("Ranged", true);
                GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                GameObject newmuzzleFlashVFX = Instantiate(muzzleFlashVFX, projectileSpawnPoint);
                AudioManager.Instance.Play2DSfx("nail gun shot", 0.1f);
                Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();


                Vector3 direction = aimPosition.transform.position - transform.position;
                //projectileRigidbody.velocity = projectileSpawnPoint.up * projectileSpeed;
                projectileRigidbody.velocity = direction.normalized * projectileSpeed;
                BulletImpact.Instance.ShakeCamera(3f, 0.15f);

            }
            else
            {
                animator.SetBool("Ranged", false);
            }
            StartCoroutine(disableStick());
            
        }
        IEnumerator disableStick()
        {
            yield return new WaitForSeconds(1);
            if (currentDurAbility == 0)
            {
                animator.SetBool("Ranged", false);
                isOutOfAmmo = true;
                gameObject.SetActive(false);
                animator.runtimeAnimatorController = GameManager.Instance.GetMeleePlayerAnimator();
                currentDurAbility = weaponStats.durability;
            }
        }
      
        private void SnapToAim()
        {
            Vector3 newdirection = new Vector3(aimPosition.transform.position.x - transform.position.x, 0f, aimPosition.transform.position.z - transform.position.z);
            rotationAngle = Mathf.Atan2(newdirection.x, newdirection.z) * Mathf.Rad2Deg + 40f;
            playerRef.transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }

    }
}
