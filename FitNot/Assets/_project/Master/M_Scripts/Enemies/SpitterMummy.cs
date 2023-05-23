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

        public ObjectPool objectPool;
        Spit spit;
        private void Awake()
        {
            //base.RegisterSingleton();
            animator = GetComponent<Animator>();
            spitPosition = gameObject.transform.GetChild(0).gameObject.transform;
        }
        public void Attack()
        {
            animator.SetBool("isAttacking", true);
            //Spit spit = Instantiate(spitPrefab, spitPosition.position, spitPosition.rotation);
            //spit.GetComponent<Rigidbody>().velocity = spitPosition.forward * spitVelocity;


            spit = objectPool.GetObjectFromPool();
            spit.transform.position = spitPosition.transform.position;
            spit.GetComponent<Rigidbody>().velocity = spitPosition.forward * spitVelocity;
            StartCoroutine(SetPoolObject());

        }
        IEnumerator SetPoolObject()
        {
            yield return new WaitForSeconds(5f);
            spit.transform.position = spitPosition.transform.position;
            objectPool.ReturnObjectToPool(spit);
        } 
       
    }

}
