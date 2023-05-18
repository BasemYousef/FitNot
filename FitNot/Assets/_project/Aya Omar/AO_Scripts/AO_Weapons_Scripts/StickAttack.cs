using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Youssef;

namespace AyaOmar
{
    public class StickAttack : MonoBehaviour,IAttackable
    {
        [SerializeField] private WeaponStats meleeStats;
        [SerializeField] private InputAction meleeAttack = new InputAction();
        [SerializeField] private GameObject hitEffect;

        //private parameters
        private Animator player;
        private int index;
        private int currentDoAbility;

        private Animator animator;

        private bool canAttack = true;
        private float attackCoolDown = 1.0f;
        private bool isAttacking = true;
        private float attackAnimationTime = 0.29f;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            currentDoAbility = meleeStats.doability;
        }
        private void Update()
        {
            Attack();
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
                    foreach (var weapon in SwitchWeapon.Instance.weapons)
                    {
                        if (weapon.activeInHierarchy)
                        {
                            index = SwitchWeapon.Instance.weapons.IndexOf(weapon);
                        }
                    }
                    if (index == 0)
                    {
                        player.SetBool("Melee", true);
                    }
                    if (index == 1)
                    {
                        player.SetBool("Boome", true);
                    }
                    if (index == 2)
                    {
                        player.SetBool("Ranged", true);
                    }
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
                if (currentDoAbility > 0)
                {
                    currentDoAbility--;

                }
                
                animator = other.gameObject.GetComponent<Animator>();
                animator.SetTrigger("Hit");
                other.gameObject.GetComponent<HealthManager>().TakeDamage(meleeStats.damage);
                Mathf.Clamp(currentDoAbility, 0, meleeStats.doability);
                Debug.Log("doability/      " + currentDoAbility);
                player.transform.LookAt(other.gameObject.transform);
            }
 
        }
        

       
    }
}
