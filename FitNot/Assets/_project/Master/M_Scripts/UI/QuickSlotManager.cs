using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Youssef;
namespace AyaOmar
{
    public class QuickSlotManager : FoodItem
    {
        [SerializeField] private Item koushari;
        [SerializeField] private Item beans;
        [SerializeField] private Item water;
        [SerializeField] private Item bomb;

        void Update()
        {
            QuickSwitch();

        }

        //function to check player inputs to use quick switch where player can use items from inventory
        private void QuickSwitch()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                FindItem(koushari, 1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                FindItem(beans, 2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                FindItem(water, 3);
            }
        }

        //switch ................
        public void Use(int index)
        {
            switch (index)
            {
                case 1:
                    SpawnItemUseEffect(koushari);
                    AudioManager.Instance.Play2DSfx("eat");
                    break;
                case 2:
                    SpawnItemUseEffect(beans);
                    AudioManager.Instance.Play2DSfx("eat");
                    break;
                case 3:
                    SpawnItemUseEffect(water);
                    AudioManager.Instance.Play2DSfx("drink");
                    break;
                case 4:
                    //SpawnItemUseEffect(ItemData);
                    //AudioManager.Instance.Play2DSfx("drink");
                    break;
                default:
                    break;
            }

        }
        // function spawn effect when player use item
        private void SpawnItemUseEffect(Item item)
        {
            // GameObject gameEffect = Instantiate(item.itemUseEffect, player.position, Quaternion.identity);
            //player.GetComponent<HungerSystem>().Eat(item.healingAmount);
            GameManager.Instance.GetHungerSlider().value += item.healingAmount;
            Destroy(item.itemPrefab);
            // Destroy(gameEffect, item.timeToDestroy);
        }

        public void FindItem(Item item, int index)
        {
            for (int i = 0; i < inventory.itemType.Length; i++)
            {
                if (inventory.itemType[i] == item.itemName)
                {
                    if (inventory.slots[i].transform.GetChild(0) != null)
                    {
                        this.Use(index);
                    }
                }

            }
        }
    }
}
