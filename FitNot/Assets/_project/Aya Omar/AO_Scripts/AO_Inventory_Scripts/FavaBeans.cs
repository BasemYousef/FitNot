using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AyaOmar
{
    public class FavaBeans : FoodItem
    {
        public GameObject effect;

        
        
        void Update()
        {
            QuickSwitch();
            
        }
        private void QuickSwitch()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                for (int i = 0; i < inventory.itemType.Length; i++)
                {
                    if (inventory.itemType[i] == "FavaBeans")
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
            GameObject gameEffect = Instantiate(effect, player.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(gameEffect, 5);
        }
    }
}
