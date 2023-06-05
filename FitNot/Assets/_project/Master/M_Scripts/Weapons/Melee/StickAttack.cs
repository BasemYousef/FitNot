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
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            currentDurAbility = meleeStats.durability;
            
            player.runtimeAnimatorController = meleeGunAnimatorState;

        }
        private void Update()
        {
            Attack();
            InventoryUIManager.Instance.txt_Durability.text = currentDurAbility.ToString();
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
                    AudioManager.Instance.Play2DPingPongSfx("whoosh");
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
            if (other.gameObject.CompareTag("MeleeMummy") || other.gameObject.CompareTag("SpitterMummy") || other.gameObject.CompareTag("LootBox") && isAttacking)
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
                if (currentDurAbility == 0)
                {
                    player.SetBool("Melee", false);
                    gameObject.SetActive(false);
                    animator.runtimeAnimatorController = GameManager.Instance.GetMeleePlayerAnimator();
                    currentDurAbility = meleeStats.durability;
                }
            }

        }

    }
}