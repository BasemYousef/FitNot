using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AyaOmar
{
    public class NailGunAttack : MonoBehaviour
    {
        [SerializeField] private WeaponStats nailGunStats;
        [SerializeField] private InputAction nailGunAttack = new InputAction();
        [SerializeField] private GameObject hitEffect;

        //[SerializeField] AnimatorOverrideController weaponAnimatorOverride = null;

        private int currentDurAbility;
        
        private Animator player;
        
        //[SerializeField] RuntimeAnimatorController nailGunAnimatorState;
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            currentDurAbility = nailGunStats.projectileCount;
            //player.runtimeAnimatorController = nailGunAnimatorState;

            player.runtimeAnimatorController = GameManager.Instance.GetRangedPlayerAnimator();
        }
        private void Update()
        {
            Attack();
            InventoryUIManager.Instance.txt_Durability.text = currentDurAbility.ToString();

        }

        private void OnEnable()
        {
            nailGunAttack.Enable();

        }
        private void OnDisable()
        {
            nailGunAttack.Disable();
           

        }
        public void Attack()
        {
            
            if (nailGunAttack.triggered)
            {
                currentDurAbility--;
                 player.SetBool("Ranged", true);

            }
            else
            {
                player.SetBool("Ranged", false);
                
            }

        }
    }
}
