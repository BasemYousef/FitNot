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
        public string description;
       
    }
}
