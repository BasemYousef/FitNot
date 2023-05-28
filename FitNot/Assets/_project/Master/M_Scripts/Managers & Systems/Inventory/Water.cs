using System.Collections;
using System.Collections.Generic;
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
                for (int i = 0; i < inventory.itemType.Length; i++)
                {
                    if (inventory.itemType[i] == waterItem.itemName)
                    {
                        if (gameObject != null)
                        {
                            this.Use();
                        }
                    }
                }
            }
        }
        
        public override void Use()
        {
            base.Use();
           // GameObject gameEffect = Instantiate(waterItem.itemUseEffect, player.position, Quaternion.identity);
            player.GetComponent<HealthManager>().Heal(waterItem.healingAmount);
            Destroy(this.gameObject);
           // Destroy(gameEffect, waterItem.timeToDestroy);
        }
    }
}
