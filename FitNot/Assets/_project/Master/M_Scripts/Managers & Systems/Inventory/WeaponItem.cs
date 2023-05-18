using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AyaOmar
{
    public class WeaponItem : MonoBehaviour
    {
        public void Use(int index)
        {
            SwitchWeapon.Instance.SetUsedWeapon(index);
            //Image weaponImg = gameObject.GetComponentInChildren<Image>();
            //weaponImg.sprite = SwitchWeapon.Instance.weaponSprites[index];
            Destroy(gameObject);
        }
    }
}