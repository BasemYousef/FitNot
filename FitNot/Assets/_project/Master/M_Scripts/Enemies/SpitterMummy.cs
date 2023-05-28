using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class SpitterMummy :MonoBehaviour,IAttackable
    {

        [SerializeField] private Spit spitPrefab;
        [SerializeField] private float spitVelocity = 8f;

        private Animator animator;
        private Transform spitPosition;

        public ObjectPool objectPool;
        Spit spit;
        private void Awake()
        {
            //base.RegisterSingleton();
            animator = GetComponent<Animator>();
            //spitPosition = gameObject.transform.GetChild(0).gameObject.transform;
            spitPosition = GameObject.FindWithTag("SpitPos").transform;
        }
        public void Attack()
        {
            animator.SetBool("isAttacking", true);
            AudioManager.Instance.PlaySpatialSfx("spit ramp up", transform.position);
           
        }
        public void SpawnSpitprojectile()
        {
            AudioManager.Instance.PlaySpatialSfx("spit", transform.position);
            Spit spit = Instantiate(spitPrefab, spitPosition.position, spitPosition.rotation);
            Vector3 direction = GameManager.Instance.GetPlayerRef().transform.position - transform.position;
            
            //spit.GetComponent<Rigidbody>().velocity = spitPosition.forward * spitVelocity;
            spit.GetComponent<Rigidbody>().velocity = direction * spitVelocity;


            //spit = objectPool.GetObjectFromPool();
            //spit.transform.position = spitPosition.transform.position;
            //spit.GetComponent<Rigidbody>().velocity = spitPosition.forward * spitVelocity;
            //StartCoroutine(SetPoolObject());
        }
        IEnumerator SetPoolObject()
        {
            yield return new WaitForSeconds(5f);
            //spit.transform.position = spitPosition.transform.position;
            //objectPool.ReturnObjectToPool(spit);
        } 
       
    }

}
