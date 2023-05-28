using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;

namespace AyaOmar
{
    public class PickupItem : MonoBehaviour
    {
        //public Item item; // Reference to the item scriptable object to be added to the inventory
        public GameObject itemButton;

        private Inventory inventory;

        //private Inventory inventory;
        private void Start()
        {
            inventory = GameManager.Instance.GetPlayerRef().GetComponent<Inventory>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //Inventory inventory = other.GetComponent<Inventory>();
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        //item can be added to inventory
                        Instantiate(itemButton, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        inventory.isFull[i] = true;
                        inventory.itemType[i] = this.gameObject.tag;
                        
                        Debug.Log(inventory.itemType[i]);
                        break;
                    }
                    
                }
                AudioManager.Instance.Play2DSfx("item pick up");
            }
        }
    }
}
