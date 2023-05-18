using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Youssef
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Youssef/Weapons/Create a New Weapon", order =0)]
    public class Y_Weapon : ScriptableObject
    {
        [SerializeField] GameObject weaponPrefab = null;
        [SerializeField] AnimatorOverrideController weaponAnimatorOverride = null;
        [SerializeField] float weaponDamage = 10f;
        [SerializeField] float weaponDurability = 10f;
        
       public void SpawnWeapon(Transform weaponInHandTransform, Animator animator)
       {
           if (weaponPrefab != null)
           {
               Instantiate(weaponPrefab, weaponInHandTransform);
           }
           if(weaponAnimatorOverride != null) 
           { 
               animator.runtimeAnimatorController = weaponAnimatorOverride;
           }
       }

        public float GetDamage() 
        { 
            return weaponDamage; 
        }
        public float GetDurability() 
        { 
            return weaponDurability; 
        }


    }
}
