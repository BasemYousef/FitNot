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
       
        void Update()
        {
            QuickSwitch();
            
        }
        
        private void QuickSwitch()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("FavaBeans used");
                for (int i = 0; i < inventory.itemType.Length; i++)
                {
                    if (inventory.itemType[i] == beansItem.itemName)
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
           // GameObject gameEffect = Instantiate(beansItem.itemUseEffect, player.position, Quaternion.identity);
            player.GetComponent<HungerSystem>().Eat(beansItem.healingAmount);
            AudioManager.Instance.Play2DSfx("eat");
            Destroy(this.gameObject);
          //  Destroy(gameEffect, beansItem.timeToDestroy);
        }
    }
}
