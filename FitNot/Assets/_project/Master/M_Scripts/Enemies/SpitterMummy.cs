using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class SpitterMummy :MonoBehaviour,IAttackable
    {

        [SerializeField] private Spit spitPrefab;
        [SerializeField] private GameObject _spitEffect;
        [SerializeField] private float spitVelocity = 8f;
        [SerializeField] private GameObject itemDrop;
        
        private Animator animator;
        [SerializeField] private Transform spitPosition;
        private bool isDie;
        private bool stopInstantiate;

        private void Awake()
        {
            stopInstantiate = true;
            animator = GetComponent<Animator>();
            //spitPosition = GameObject.FindWithTag("SpitPos").transform;
            
        }
        public void Attack()
        {
            animator.SetBool("isAttacking", true);
            AudioManager.Instance.PlaySpatialSfx("spit ramp up", transform.position);
        }
        public void SpawnSpitprojectile()
        {
            AudioManager.Instance.PlaySpatialSfx("spit", transform.position);
            GameObject spitEffect = Instantiate(_spitEffect, spitPosition.position, spitPosition.rotation);
            Spit spit = Instantiate(spitPrefab, spitPosition.position, spitPosition.rotation);
            Vector3 direction = GameManager.Instance.GetPlayerRef().transform.position - transform.position;
            spit.GetComponent<Rigidbody>().velocity = direction * spitVelocity;
            Destroy(spitEffect, 1.5f);
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
        public void DestroyMummy()
        {
            Destroy(gameObject);
        }
        
    }

}
