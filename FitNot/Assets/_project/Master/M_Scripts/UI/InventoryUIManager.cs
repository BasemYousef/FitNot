using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
namespace AyaOmar
{
    public class InventoryUIManager : Singleton<InventoryUIManager>
    {

        public List<Image> QuickSwitchIcons = new List<Image>();
        public TMP_Text txt_Durability;
        public Image img_Durability;
        private void Awake()
        {
            base.RegisterSingleton();
           
        }
    }
}
