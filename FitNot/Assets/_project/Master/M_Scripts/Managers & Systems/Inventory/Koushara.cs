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
        private int slotIndex;
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
            GameManager.Instance.GetHungerSlider().value += koushariItem.healingAmount;
            ShowMinusTxt("eat");
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
            GameManager.Instance.GetHungerSlider().value += koushariItem.healingAmount;
            ShowMinusTxt("eat");
            if (gameObject != null)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
