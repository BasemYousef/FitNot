using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Youssef;
using TMPro;
namespace AyaOmar
{
    public class InventoryUIManager : Singleton<InventoryUIManager>
    {

        public List<Image> QuickSwitchIcons = new List<Image>();
        public Image img_Durability;
        private TMP_Text minusTxt;
        private void Awake()
        {
            base.RegisterSingleton();
            minusTxt = GameManager.Instance.GetMinusTxt();
        }
        public void ShowMinusTxt(string soundName)
        {
            minusTxt.gameObject.SetActive(true);
            if (soundName != null)
            {
                AudioManager.Instance.Play2DSfx(soundName);
            }
            StartCoroutine(WaitForTime());
        }
        private IEnumerator WaitForTime()
        {
            yield return new WaitForSeconds(1f);
            minusTxt.gameObject.SetActive(false);
        }
    }
}
