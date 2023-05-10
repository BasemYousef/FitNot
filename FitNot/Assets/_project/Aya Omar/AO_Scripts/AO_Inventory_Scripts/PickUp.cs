using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AyaOmar
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;

        private void Start()
        {
            Debug.Log("Pick Up script");
            //inventory = GetComponent<Inventory>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("player............");
                for(int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].isFull == false)
                    {
                        Image itemImg = inventory.slots[i].gameObject.transform.GetChild(0).GetComponentInChildren<Image>();
                        TMP_Text itemType = inventory.slots[i].gameObject.GetComponentInChildren<TMP_Text>();
                        TMP_Text itemCounter = inventory.slots[i].gameObject.GetComponentInChildren<TMP_Text>();
                        
                        inventory.slots[i].counter++;
                        itemImg.sprite = inventory.slots[i].itemImg;
                        itemType.text = inventory.slots[i].type;
                        itemCounter.text = inventory.slots[i].counter.ToString();
                        Destroy(gameObject);

                        if (inventory.slots[i].counter >= inventory.slots[i].maxNumOfStorage)
                        {
                            inventory.slots[i].isFull = true;
                        }

                    }
                }
            }
        }
    }
}
