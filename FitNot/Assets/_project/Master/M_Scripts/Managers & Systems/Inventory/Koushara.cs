using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                for (int i = 0; i < inventory.itemType.Length; i++)
                {
                    if (inventory.itemType[i] == koushariItem.itemName)
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
         //   GameObject gameEffect = Instantiate(koushariItem.itemUseEffect, player.position, Quaternion.identity);
            player.GetComponent<HungerSystem>().Eat(koushariItem.healingAmount);
            AudioManager.Instance.Play2DSfx("eat");
            Destroy(this.gameObject);
          //  Destroy(gameEffect, koushariItem.timeToDestroy);
        }
    }
}
