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
        [SerializeField] private GameObject weapon;
        [SerializeField] private GameObject mummyHealthBar;
        
        private bool isDie;
        private bool stopInstantiate;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            stopInstantiate = true;
        }
        public void Attack()
        {
            animator.SetBool(ATTACK_PARAM, true);
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
                GameObject cloneItem = Instantiate(itemDrop, itemPos, transform.rotation);
                stopInstantiate = false;
                Destroy(cloneItem, 6f);
            }
            
        }
        public void DestroyWeapon()
        {
            Destroy(weapon);
        }
        public void HideMummyColider()
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;

        }
        public void HideMummyHealthBar()
        {
            mummyHealthBar.SetActive(false);
        }
    }
}
