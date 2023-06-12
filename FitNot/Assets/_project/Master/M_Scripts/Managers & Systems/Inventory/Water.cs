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
        private int slotIndex;

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
        public void FindItem(Item item)
        {

            for (int i = 0; i < inventory.itemType.Length; i++)
            {
                slotIndex = i;
                if (inventory.isFull[i] == true && inventory.itemType[i] == item.itemName)
                {
                    if (gameObject != null)
                    {
                        this.Use();
                    }
                    slotIndex = i;
                    break;
                }
            }
        }
        private void SpawnItemUseEffect()
        {
            GameManager.Instance.GetHungerSlider().value += waterItem.healingAmount;
            ShowMinusTxt("drink");
            Transform childTransform = inventory.slots[slotIndex].transform.GetChild(0);
            GameObject childObject = childTransform.gameObject;
            Destroy(childObject);
        }
        public override void Use()
        {
            SpawnItemUseEffect();
        }
        public void UseFromInventory()
        {
            GameManager.Instance.GetHungerSlider().value += waterItem.healingAmount;
            ShowMinusTxt("drink");

            if (gameObject != null)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
