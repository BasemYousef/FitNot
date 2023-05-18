using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class PlayerCombat : MonoBehaviour
    {

        [SerializeField] Transform weaponInHandPosition = null;
        [SerializeField] Y_Weapon defaultWeapon = null;


        Y_Weapon currentWeapon = null;
        void Start()
        {
            EquipWeapon(defaultWeapon);
        }

        public void EquipWeapon(Y_Weapon weapon)
        {
            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.SpawnWeapon(weaponInHandPosition, animator);
        }

       
    }
}
