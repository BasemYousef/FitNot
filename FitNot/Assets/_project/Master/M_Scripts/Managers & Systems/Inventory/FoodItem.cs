using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Youssef;
namespace AyaOmar
{
    public class FoodItem : MonoBehaviour
    {
        
        protected Transform player;
        protected Inventory inventory;
        void Start()
        {
            player = GameManager.Instance.GetPlayerRef().transform;
            inventory = player.GetComponent<Inventory>();
        }
        public virtual void Use() { }
        
    }
}
