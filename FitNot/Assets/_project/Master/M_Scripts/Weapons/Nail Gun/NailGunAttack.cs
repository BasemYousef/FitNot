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
        
        private int currentDurAbility;
        private Animator player;
        
       
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            currentDurAbility = nailGunStats.projectileCount;
           

            player.runtimeAnimatorController = GameManager.Instance.GetRangedPlayerAnimator();
        }
        private void Update()
        {
            Attack();
           
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
