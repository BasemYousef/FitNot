using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Youssef;

namespace AyaOmar
{
    public class StickAttack : MonoBehaviour, IAttackable
    {
        [SerializeField] private WeaponStats meleeStats;
        [SerializeField] private InputAction meleeAttack = new InputAction();
        [SerializeField] private GameObject hitEffectVFX;
        [SerializeField] private Transform hitTarget;
        //private parameters
        private GameObject aimPosition;
        private GameObject playerRef;
        private float rotationAngle;
        private Animator player;
        private int index;
        private int currentDurAbility;

        private Animator animator;

        private bool canAttack = true;
        private float attackCoolDown = 1.0f;
        private bool isAttacking = true;
        private float attackAnimationTime = 0.29f;
        public LayerMask targetLayer;

        [SerializeField] RuntimeAnimatorController meleeGunAnimatorState;

        public Collider attackCollider; // Reference to the attack collider

        private bool isCollide = false;

        private float fillAmount;
        private void Start()
        {
            player = GameManager.Instance.GetPlayerRef().GetComponent<Animator>();
            aimPosition = GameManager.Instance.GetAimObjectRef();
            playerRef = GameManager.Instance.GetPlayerRef();
            currentDurAbility = meleeStats.durability;
            
            player.runtimeAnimatorController = meleeGunAnimatorState;

        }
        private void Update()
        {
            Attack();
            
            fillAmount = currentDurAbility / 10f;
            InventoryUIManager.Instance.img_Durability.fillAmount = fillAmount;
        }

        private void OnEnable()
        {
            meleeAttack.Enable();

        }
        private void OnDisable()
        {
            meleeAttack.Disable();

        }
        public void Attack()
        {
            isAttacking = true;

            if (meleeAttack.triggered)
            {
                //StartAttack();
                if (canAttack)
                {
                    player.SetBool("Melee", true);
                    SnapToAim();
                    canAttack = false;
                    StartCoroutine(ResetAttackCoolDown());
                }
            }
            else
            {
                //StopAttack();
                player.SetBool("Melee", false);

            }
            StartCoroutine(ResetAttackCoolDown());

        }

        IEnumerator ResetAttackCoolDown()
        {
            StartCoroutine(ResetAttackBool());
            yield return new WaitForSeconds(attackCoolDown);
            canAttack = true;
        }
        IEnumerator ResetAttackBool()
        {
            yield return new WaitForSeconds(attackAnimationTime);
            isAttacking = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("MeleeMummy") || other.gameObject.CompareTag("SpitterMummy") && isAttacking)
            {
                if (currentDurAbility >= 0)
                {
                    currentDurAbility--;

                }

                animator = other.gameObject.GetComponent<Animator>();
                animator.SetTrigger("Hit");
                other.gameObject.GetComponent<HealthManager>().TakeDamage(meleeStats.damage);
                GameObject clonehitVFX = Instantiate(hitEffectVFX, hitTarget.position, Quaternion.identity);
                AudioManager.Instance.Play2DPingPongSfx("melee hit");
                Destroy(clonehitVFX, 1.5F);
                Mathf.Clamp(currentDurAbility, 0, meleeStats.durability);
                
                
                Debug.Log("doability/      " + currentDurAbility);
                player.transform.LookAt(other.gameObject.transform);
                StartCoroutine(disableStick());
            }
            if (other.gameObject.CompareTag("LootBox")) Destroy(other.gameObject);
        }
        IEnumerator disableStick()
        {
            yield return new WaitForSeconds(1);
            if (currentDurAbility == 0)
            {
                player.SetBool("Melee", false);
                gameObject.SetActive(false);
                animator.runtimeAnimatorController = GameManager.Instance.GetMeleePlayerAnimator();
                currentDurAbility = meleeStats.durability;
            }
        }
        private void SnapToAim()
        {
            Vector3 newdirection = new Vector3(aimPosition.transform.position.x - transform.position.x, 0f, aimPosition.transform.position.z - transform.position.z);
            rotationAngle = Mathf.Atan2(newdirection.x, newdirection.z) * Mathf.Rad2Deg + 10f;
            playerRef.transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
    }
}