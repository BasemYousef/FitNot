using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Youssef;

namespace AyaOmar
{
    public class FavaBeans : FoodItem
    {
        public Item beansItem;

        private int slotIndex;

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
            GameManager.Instance.GetHungerSlider().value += beansItem.healingAmount;
            Transform childTransform = inventory.slots[slotIndex].transform.GetChild(0);
            GameObject childObject = childTransform.gameObject;
            Destroy(childObject);
            // Destroy(gameEffect, item.timeToDestroy);
        }
        public override void Use()
        {
            SpawnItemUseEffect();
            AudioManager.Instance.Play2DSfx("eat");
        }
        public void UseFromInventory()
        {
            GameManager.Instance.GetHungerSlider().value += beansItem.healingAmount;
            if (gameObject != null)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
