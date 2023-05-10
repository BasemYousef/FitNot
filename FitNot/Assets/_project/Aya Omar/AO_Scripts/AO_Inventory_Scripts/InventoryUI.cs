using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace AyaOmar
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GameObject inventory;
        [SerializeField] private InputActionReference openInventory;

        private bool isOpen = true;

        private void Start()
        {
            //inventory.SetActive(false);
        }
        private void OnEnable()
        {
            openInventory.action.Enable();
            openInventory.action.performed += OnOpenInventory;
        }
        private void OnDisable()
        {
            openInventory.action.Disable();
            openInventory.action.performed -= OnOpenInventory;
        }
        private void OnOpenInventory(InputAction.CallbackContext context)
        {
            ShowInventory();
        }
        private void ShowInventory()
        {
            if (isOpen)
            {
                inventory.SetActive(true);
                isOpen = false;
            }
            else
            {
                HideInventory();
            }
            //Debug.Log("Inventory shown");
        }
        private void HideInventory()
        {
            inventory.SetActive(false);
            isOpen = true;
            //Debug.Log("Inventory hiden");
        }
    }
}
