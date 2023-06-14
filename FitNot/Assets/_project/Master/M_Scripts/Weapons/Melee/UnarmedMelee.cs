using AyaOmar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Youssef
{
    public class UnarmedMelee : MonoBehaviour, IAttackable
    {
        [SerializeField] private WeaponStats meleeStats;
        [SerializeField] private InputAction meleeAttack = new InputAction();
        [SerializeField] private GameObject hitEffectVFX;
        [SerializeField] private Transform hitTarget;

        private GameObject aimPosition;
        private GameObject playerRef;
        private float rotationAngle;
        private bool canAttack = true;
        private float attackCoolDown = 1.3f;
        private bool isAttacking = true;
        private float attackAnimationTime = 0.24f;
        public LayerMask targetLayer;
        private Animator player;
        private Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            player = GameManager.Instance.GetPlayerRef().GetComponent<Animator>();
            aimPosition = GameManager.Instance.GetAimObjectRef();
            playerRef = GameManager.Instance.GetPlayerRef();
        }

        // Update is called once per frame
        void Update()
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
                //StartAttack();
                if (canAttack)
                {
                    player.SetBool("unarmed", true);
                    SnapToAim();
                    canAttack = false;
                    StartCoroutine(ResetAttackCoolDown());
                }
            }
            else
            {
                //StopAttack();
                player.SetBool("unarmed", false);

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

                animator = other.gameObject.GetComponent<Animator>();
                animator.SetTrigger("Hit");
                other.gameObject.GetComponent<HealthManager>().TakeDamage(meleeStats.damage);
                GameObject clonehitVFX = Instantiate(hitEffectVFX, hitTarget.position, Quaternion.identity);
                AudioManager.Instance.Play2DPingPongSfx("melee hit");
                Destroy(clonehitVFX, 1.5F);
                
                player.transform.LookAt(other.gameObject.transform);
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
