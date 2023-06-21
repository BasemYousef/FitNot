using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using Youssef;

namespace AyaOmar
{
    public class FavaBeans : FoodItem
    {
        public Item beansItem;
        
        void Update()
        {
            QuickSwitch();

        }
        private void QuickSwitch()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                FindItem(beansItem);
            }
        }
        public override void Use()
        {
            SpawnItemUseEffect(beansItem,"eat");
            
        }
        public void UseFromInventory()
        {
            //GameManager.Instance.GetHungerSlider().value += beansItem.healingAmount;
            HungerSystem.Instance.Eat(beansItem.healingAmount);
            InventoryUIManager.Instance.ShowMinusTxt("eat");

            if (gameObject != null)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
