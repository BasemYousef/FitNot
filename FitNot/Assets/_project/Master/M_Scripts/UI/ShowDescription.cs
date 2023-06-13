using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class ShowDescription : MonoBehaviour
    {
        [SerializeField]private GameObject weaponsDescription;
        [SerializeField]private GameObject playerDescription;
        public void OnMouseDown()
        {
            weaponsDescription.SetActive(true);
        }
        private void OnMouseUp()
        {
            weaponsDescription.SetActive(false);

        }
        public void showInventory()
        {
            weaponsDescription.SetActive(false);
            playerDescription.SetActive(false);
        }
        public void ShowWeaponInfo()
        {
            weaponsDescription.SetActive(true);
            playerDescription.SetActive(false);
        }
        public void ShowPlayerInfo()
        {
            weaponsDescription.SetActive(false);
            playerDescription.SetActive(true);
        }
    }
}
