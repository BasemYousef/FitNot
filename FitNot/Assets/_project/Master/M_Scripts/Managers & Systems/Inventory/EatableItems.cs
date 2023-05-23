using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Youssef;

namespace AyaOmar
{
    public class EatableItems : FoodItem
    {
        //item scriptable object hold item data
        public Item ItemData;
        
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

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                FindItem(ItemData, 2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
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
                    break;
                case 2:
                    SpawnItemUseEffect(ItemData);
                    break;
                case 3:
                    SpawnItemUseEffect(ItemData);
                    break;
                default:
                    break;
            }
            
        }
        // function spawn effect when player use item
        private void SpawnItemUseEffect(Item item)
        {
            GameObject gameEffect = Instantiate(item.itemUseEffect, player.position, Quaternion.identity);
            player.GetComponent<HealthManager>().Heal(item.healingAmount);
            Destroy(this.gameObject);
            Destroy(gameEffect, item.timeToDestroy);
        }

        private void FindItem(Item item,int index)
        {
            for (int i = 0; i < inventory.itemType.Length; i++)
            {
                if (inventory.itemType[i] == item.itemName)
                {
                    if (gameObject != null)
                    {
                        this.Use(index);
                    }
                }

            }
        }
    }
}
