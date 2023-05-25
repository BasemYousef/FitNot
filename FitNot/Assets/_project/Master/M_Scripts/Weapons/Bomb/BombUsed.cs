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
                if (inventory.itemType[i] == item.itemName)
                {
                    if (gameObject != null)
                    {
                        this.Use();
                    }
                }

            }
        }
        public void Use()
        {
            player.SetTrigger("Bomb");
            Destroy(gameObject);
        }
    }
}
