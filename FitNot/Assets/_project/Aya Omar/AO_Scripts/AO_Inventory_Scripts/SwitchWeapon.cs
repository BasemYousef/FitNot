using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AyaOmar
{
    public class SwitchWeapon : Singleton<SwitchWeapon>
    {
        [SerializeField]private Image weaponImgUi;

        
        private void Awake()
        {
            base.RegisterSingleton();
        }
        public List<GameObject> weapons = new List<GameObject>();
        public List<Sprite> weaponSprites = new List<Sprite>();

        public void SetUsedWeapon(int index)
        {
            foreach (GameObject weapon in weapons)
            {
                weapon.SetActive(false);
            }
            weapons[index].SetActive(true);
            weaponImgUi.sprite = weaponSprites[index];
        }
    }
}
