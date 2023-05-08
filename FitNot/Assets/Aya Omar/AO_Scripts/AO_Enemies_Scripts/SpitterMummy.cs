using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class SpitterMummy : Singleton<SpitterMummy>,IAttackable
    {

        [SerializeField] private Spit spitPrefab;
        [SerializeField] private Transform spitPosition;
        
        private float spitVelocity = 10f;

        private Animator animator;
       
        private void Awake()
        {
            base.RegisterSingleton();
            animator = GetComponent<Animator>();
        }
        public void Attack()
        {

            animator.SetBool("isAttacking", true);
            Spit spit = Instantiate(spitPrefab, spitPosition.position, spitPosition.rotation);
            spit.GetComponent<Rigidbody>().velocity = spitPosition.forward * spitVelocity;

        }
        void Update()
        {
            
        }
       
    }

}
