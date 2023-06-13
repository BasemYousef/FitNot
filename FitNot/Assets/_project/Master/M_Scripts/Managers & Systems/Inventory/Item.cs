using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public float healingAmount;
        public GameObject itemPrefab;
        public string description;
        public float timeToDestroy;
        public int dropChance;

        public Item(string itemName, int dropChance)
        {
            this.itemName = itemName;
            this.dropChance = dropChance;
        }
    }
}

