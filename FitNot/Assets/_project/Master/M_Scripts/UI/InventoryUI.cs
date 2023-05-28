using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Youssef;

namespace AyaOmar
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GameObject inventory;
        [SerializeField] private InputAction openInventory  = new InputAction();

        [SerializeField] bool Pressed;
        
        private bool isOpen = false;
        

        private void Start()
        {
            inventory.SetActive(false);
            
            
        }
        private void OnEnable()
        {
            openInventory.Enable();
           
        }
        private void OnDisable()
        {
            openInventory.Disable();
           
        }
        private void Update()
        {
            ShowInventory();
            Pressed = openInventory.triggered;
        }
        private void ShowInventory()
        {


            if (openInventory.triggered)
            {
                HideInventory();
                AudioManager.Instance.Play2DSfx("inventory");
            }
        }
        private void HideInventory()
        {
            
            isOpen = !isOpen;
            inventory.SetActive(isOpen);
            

        }
    }
}
