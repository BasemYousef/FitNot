using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class BombUsed : MonoBehaviour
    {
        private Animator player;
        private Inventory inventory;
        public Item ItemData;

        private int slotIndex;

        private void Start()
        {
            player = GameManager.Instance.GetPlayerRef().GetComponent<Animator>();
            inventory = GameManager.Instance.GetPlayerRef().GetComponent<Inventory>();
        }

        void Update()
        {
            QuickSwitch();

        }
        private void QuickSwitch()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                FindItem(ItemData);
            }
        }

        private void FindItem(Item item)
        {
            for (int i = 0; i < inventory.itemType.Length; i++)
            {
                slotIndex = i;
                if (inventory.isFull[i] == true && inventory.itemType[i] == item.itemName)
                {
                    if (gameObject != null)
                    {
                        UseFromSlots();
                    }
                    slotIndex = i;
                    break;
                }
            }
        }
        private void UseFromSlots()
        {
            Transform childTransform = inventory.slots[slotIndex].transform.GetChild(0);
            GameObject childObject = childTransform.gameObject;
            player.SetTrigger("Bomb");
            Destroy(childObject);
        }
        public void Use()
        {
            player.SetTrigger("Bomb");
            Destroy(gameObject);
        }
        
    }
}
