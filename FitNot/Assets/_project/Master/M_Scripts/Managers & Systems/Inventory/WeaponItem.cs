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
        private TMP_Text minus_Text;

        private void Start()
        {
            minus_Text = GameManager.Instance.GetMinusTxt();
        }
        public void Use(int index)
        {
            SwitchWeapon.Instance.SetUsedWeapon(index);
            playerAnimator = GameManager.Instance.GetPlayerRef().GetComponent<Animator>();
            ShowMinusTxt();
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

        private IEnumerator WaitForTime()
        {
            yield return new WaitForSeconds(1f);
            minus_Text.gameObject.SetActive(false);
        }
        public void ShowMinusTxt()
        {
            minus_Text.gameObject.SetActive(true);
            StartCoroutine(WaitForTime());
        }
    }
}
