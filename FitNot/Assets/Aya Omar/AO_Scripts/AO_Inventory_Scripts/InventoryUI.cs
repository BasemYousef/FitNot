using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace AyaOmar
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GameObject inventory;
        [SerializeField] private InputAction openInventory = new InputAction();
       
        void Update()
        {
            ShowInventory();
        }
        private void OnEnable()
        {
            openInventory.Enable();
        }
        private void OnDisable()
        {
            openInventory.Disable();
        }
        void ShowInventory()
        {
            
             inventory.gameObject.SetActive(true);
             Debug.Log("show");
            
        }
    }
}
