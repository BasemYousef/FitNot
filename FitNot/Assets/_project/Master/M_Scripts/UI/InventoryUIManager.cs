using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AyaOmar
{
    public class InventoryUIManager : Singleton<InventoryUIManager>
    {

        public List<Image> QuickSwitchIcons = new List<Image>();

        private void Awake()
        {
            base.RegisterSingleton();
           
        }
       
        
    }
}
