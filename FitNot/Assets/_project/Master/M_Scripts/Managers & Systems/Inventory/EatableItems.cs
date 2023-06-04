using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Youssef;

namespace AyaOmar
{
    public class EatableItems : FoodItem
    {
        //item scriptable object hold item data
        public Item ItemData;

        private int slotIndex;
        
        void Update()
        {
            QuickSwitch();

        }

        //function to check player inputs to use quick switch where player can use items from inventory
        private void QuickSwitch()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                FindItem(ItemData, 1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                FindItem(ItemData, 2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                FindItem(ItemData, 3);
            }
            
        }

        //switch ................
        public void Use(int index)
        {
            switch (index)
            {
                case 1:
                    SpawnItemUseEffect(ItemData);
                    AudioManager.Instance.Play2DSfx("eat");
                    break;
                case 2:
                    SpawnItemUseEffect(ItemData);
                    AudioManager.Instance.Play2DSfx("eat");
                    break;
                case 3:
                    SpawnItemUseEffect(ItemData);
                    AudioManager.Instance.Play2DSfx("drink");
                    break;
               
                default:
                    break;
            }
            
        }
        public void UseFromInventory()
        {
            GameManager.Instance.GetHungerSlider().value += ItemData.healingAmount;
            if (gameObject != null)
            {
                Destroy(this.gameObject);
            }

        }
        // function spawn effect when player use item
        private void SpawnItemUseEffect(Item item)
        {
            GameManager.Instance.GetHungerSlider().value += item.healingAmount;
            Transform childTransform = inventory.slots[slotIndex].transform.GetChild(0);
            GameObject childObject = childTransform.gameObject;
            Destroy(childObject);
           // Destroy(gameEffect, item.timeToDestroy);
        }

        public void FindItem(Item item,int index)
        {

            for (int i = 0; i < inventory.itemType.Length; i++)
            {
                slotIndex = i;
                if (inventory.isFull[i]==true && item.itemName == inventory.itemType[i])
                {
                    if (gameObject != null)
                    {
                        this.Use(index);
                    }
                    slotIndex = i;
                    break;
                }
                
            }
            Debug.Log(slotIndex + " sloooooooooooooooooooooot index");
        }
    }
}
