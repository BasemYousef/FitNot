using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Youssef;

namespace AyaOmar
{
    public class Koushara : FoodItem
    {
        public Item koushariItem;
        
        void Update()
        {
            QuickSwitch();

        }
        private void QuickSwitch()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                FindItem(koushariItem);
            }
        }
       
        public override void Use()
        {
            SpawnItemUseEffect(koushariItem,"eat");
           
        }
        public void UseFromInventory()
        {
            //GameManager.Instance.GetHungerSlider().value += koushariItem.healingAmount;
            HungerSystem.Instance.Eat(koushariItem.healingAmount);
            InventoryUIManager.Instance.ShowMinusTxt("eat");
            if (gameObject != null)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
