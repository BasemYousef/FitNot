using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AyaOmar
{
    public class WeaponItem : MonoBehaviour
    {
        private Animator playerAnimator;
        
        private void Start()
        {
            playerAnimator = GameManager.Instance.GetPlayerRef().GetComponent<Animator>();
        }
        public void Use(int index)
        {
            SwitchWeapon.Instance.SetUsedWeapon(index);
            
            InventoryUIManager.Instance.ShowMinusTxt(null);
            if (index == 0)
            {
                playerAnimator.runtimeAnimatorController = GameManager.Instance.GetMeleePlayerAnimator();
            }
            else if (index == 1)
            {
                playerAnimator.runtimeAnimatorController = GameManager.Instance.GetRangedPlayerAnimator();
            }
            
            Destroy(gameObject);
        }
    }
}
