using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class MeleeMummy : MonoBehaviour, IAttackable
    {
        private Animator animator;
        private string ATTACK_PARAM = "isAttacking";
        [SerializeField] private GameObject itemDrop;
        [SerializeField] private GameObject spawnEffect;
        private bool isDie;
        private bool stopInstantiate;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            stopInstantiate = true;

            StartCoroutine(SpawnEffect());
        }
        public void Attack()
        {
            animator.SetBool(ATTACK_PARAM, true);
            AudioManager.Instance.Play2DPingPongSfx("whoosh");
        }
        private void Update()
        {
            DropItem();
        }
        private void DropItem()
        {
            isDie = gameObject.GetComponent<HealthManager>().isDead;
            Vector3 itemPos = transform.position;
            itemPos.y = transform.position.y + 1;
            if (isDie && stopInstantiate)
            {
                Instantiate(itemDrop, itemPos, transform.rotation);
                stopInstantiate = false;
            }
        }
        IEnumerator SpawnEffect()
        {
            yield return new WaitForSeconds(2f);
            spawnEffect.SetActive(false);
        }
    }
}
