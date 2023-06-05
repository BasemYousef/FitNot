using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace AyaOmar
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private InputAction openPauseMenu = new InputAction();

        private bool isOpen = false;

        void Start()
        {
            pauseMenu.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            OPenPauseMenu();
        }
        private void OnEnable()
        {
            openPauseMenu.Enable();
            
        }
        private void OnDisable()
        {
            openPauseMenu.Disable();
        }
        private void OPenPauseMenu()
        {
            if (openPauseMenu.triggered)
            {
                ClosePauseMenu();
            }
            if (isOpen == false)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;

            }
        }

        private void ClosePauseMenu()
        {
            isOpen = !isOpen;
            pauseMenu.SetActive(isOpen);
        }
    }
}
