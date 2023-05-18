using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class SpitterMummy :MonoBehaviour,IAttackable
    {

        [SerializeField] private Spit spitPrefab;
        
        
        private float spitVelocity = 10f;

        private Animator animator;
        private Transform spitPosition;
       
        private void Awake()
        {
            //base.RegisterSingleton();
            animator = GetComponent<Animator>();
            spitPosition = gameObject.transform.GetChild(0).gameObject.transform;
        }
        public void Attack()
        {
            animator.SetBool("isAttacking", true);
            Spit spit = Instantiate(spitPrefab, spitPosition.position, spitPosition.rotation);
            spit.GetComponent<Rigidbody>().velocity = spitPosition.forward * spitVelocity;
            
            //StartCoroutine(AttackAnimation());

        }
        IEnumerator AttackAnimation()
        {
            yield return new WaitForSeconds(1f);
            animator.SetBool("isAttacking", true);
        } 
       
    }

}
