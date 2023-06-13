using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;
using TMPro;
namespace AyaOmar
{
    public class FoodItem : MonoBehaviour
    {
        
        protected Transform player;
        protected Inventory inventory;
        private TMP_Text minusTxt;

        private void Awake()
        {
            player = GameManager.Instance.GetPlayerRef().transform;
            inventory = player.GetComponent<Inventory>();
            minusTxt = GameManager.Instance.GetMinusTxt();

        }

        public virtual void Use() { }
        protected IEnumerator WaitForTime(TMP_Text minus_Text)
        {
            yield return new WaitForSeconds(1f);
            minus_Text.gameObject.SetActive(false);
        }
        public void ShowMinusTxt(string soundName)
        {
            minusTxt.gameObject.SetActive(true);
            AudioManager.Instance.Play2DSfx(soundName);
            StartCoroutine(WaitForTime(minusTxt));
        }
    }
}
