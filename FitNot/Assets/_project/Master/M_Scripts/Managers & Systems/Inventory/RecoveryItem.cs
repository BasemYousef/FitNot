using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class RecoveryItem : MonoBehaviour
    {
        public Item recoveryItem;
        private Transform player;
        private TMP_Text minus_Text;
        void Start()
        {
            player = GameManager.Instance.GetPlayerRef().transform;
            minus_Text = GameManager.Instance.GetMinusTxt();

        }
        public void Use()
        {
            player.GetComponent<HealthManager>().Heal(recoveryItem.healingAmount);
            ShowMinusTxt();
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
            AudioManager.Instance.Play2DSfx("rivo");
            StartCoroutine(WaitForTime());
        }
    }
}
