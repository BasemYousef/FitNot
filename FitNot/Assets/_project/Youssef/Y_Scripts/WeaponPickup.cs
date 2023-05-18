using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] Y_Weapon weapon = null;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.GetComponent<PlayerCombat>().EquipWeapon(weapon);
                Destroy(gameObject);
            }
        }
    }
}
