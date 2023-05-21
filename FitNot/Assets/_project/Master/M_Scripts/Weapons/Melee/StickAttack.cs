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
        [SerializeField] private GameObject hitEffect;

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
                if (canAttack)
                {
                        
                    player.SetBool("Melee", true);
                    canAttack = false;
                    StartCoroutine(ResetAttackCoolDown());
                }
            }
            else
            {
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
                if (currentDurAbility > 0)
                {
                    currentDurAbility--;

                }

                animator = other.gameObject.GetComponent<Animator>();
                animator.SetTrigger("Hit");
                other.gameObject.GetComponent<HealthManager>().TakeDamage(meleeStats.damage);
                Mathf.Clamp(currentDurAbility, 0, meleeStats.durability);
                Debug.Log("doability/      " + currentDurAbility);
                player.transform.LookAt(other.gameObject.transform);
            }

        }
    }
}
