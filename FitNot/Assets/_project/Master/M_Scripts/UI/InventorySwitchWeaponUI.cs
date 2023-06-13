using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class InventorySwitchWeaponUI : MonoBehaviour
    {

        [SerializeField] private GameObject[] weaponsInfo;
        private int index;
        void Start()
        {
            index = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (index >= weaponsInfo.Length) { index = weaponsInfo.Length - 1; }
            if (index < 0) { index = 0; }
            if (index == 0) { weaponsInfo[0].SetActive(true); }
        }
        public void NextBtn()
        {
            index++;
            for(int i = 0; i < weaponsInfo.Length; i++)
            {
                weaponsInfo[i].SetActive(false);
                weaponsInfo[index].SetActive(true);
            }
        }
        public void PreBtn()
        {
            index--;
            for (int i = 0; i < weaponsInfo.Length; i++)
            {
                weaponsInfo[i].SetActive(false);
                weaponsInfo[index].SetActive(true);
            }
        }
    }
}
