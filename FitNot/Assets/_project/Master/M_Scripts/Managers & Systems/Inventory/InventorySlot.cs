using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AyaOmar
{
    public class InventorySlot : MonoBehaviour
    {
        private Inventory inventory;
        public int index;
        private void Start()
        {
            //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            inventory = GameManager.Instance.GetPlayerRef().GetComponent<Inventory>();
        }
        private void Update()
        {
            CheckSlot();
        }
        void CheckSlot()
        {
            if (transform.childCount <= 0)
            {
                inventory.isFull[index] = false;
            }
        }
        public void DropItem()
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<SpawnPickUpItem>().SpawnDropedItem();
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
