using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        public string description;
        public int index;
        // Add any other relevant properties or methods for the item.
    }
}
