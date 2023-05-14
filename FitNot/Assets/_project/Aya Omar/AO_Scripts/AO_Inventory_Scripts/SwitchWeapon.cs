using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class SwitchWeapon : Singleton<SwitchWeapon>
    {
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
        }
    }
}
