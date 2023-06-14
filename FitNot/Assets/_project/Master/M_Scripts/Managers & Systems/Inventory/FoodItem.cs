using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;
using TMPro;
namespace AyaOmar
{
    public class FoodItem : MonoBehaviour
    {
        
        protected Transform player;
        protected Inventory inventory;
        
        private int slotIndex;

        private void Awake()
        {
            player = GameManager.Instance.GetPlayerRef().transform;
            inventory = player.GetComponent<Inventory>();
        }

        public virtual void Use() { }

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
        public void SpawnItemUseEffect(Item item, string soundName)
        {
            GameManager.Instance.GetHungerSlider().value += item.healingAmount;
            InventoryUIManager.Instance.ShowMinusTxt(soundName);
            Transform childTransform = inventory.slots[slotIndex].transform.GetChild(0);
            GameObject childObject = childTransform.gameObject;
            Destroy(childObject);
        }
    }
}
