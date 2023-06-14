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
       
        void Start()
        {
            player = GameManager.Instance.GetPlayerRef().transform;
           
        }
        public void Use()
        {
            player.GetComponent<HealthManager>().Heal(recoveryItem.healingAmount);
            InventoryUIManager.Instance.ShowMinusTxt("rivo");
            Destroy(gameObject);
        }
        
    }
}
