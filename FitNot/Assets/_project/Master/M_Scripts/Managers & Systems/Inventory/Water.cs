using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Youssef;

namespace AyaOmar
{
    public class Water : FoodItem
    {
        public Item waterItem;
        void Update()
        {
            QuickSwitch();
        }
        private void QuickSwitch()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                FindItem(waterItem);
            }
        }
        
        public override void Use()
        {
            SpawnItemUseEffect(waterItem,"drink");
        }
        public void UseFromInventory()
        {
            //GameManager.Instance.GetHungerSlider().value += waterItem.healingAmount;
            HungerSystem.Instance.Eat(waterItem.healingAmount);
            InventoryUIManager.Instance.ShowMinusTxt("drink");

            if (gameObject != null)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
