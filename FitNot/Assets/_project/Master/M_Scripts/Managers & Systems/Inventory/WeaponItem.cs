using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AyaOmar
{
    public class WeaponItem : MonoBehaviour
    {
        private Animator playerAnimator;
        public void Use(int index)
        {
            SwitchWeapon.Instance.SetUsedWeapon(index);
            playerAnimator = GameManager.Instance.GetPlayerRef().GetComponent<Animator>();
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
