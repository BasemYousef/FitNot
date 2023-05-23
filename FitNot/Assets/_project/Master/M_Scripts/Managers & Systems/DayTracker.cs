using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AyaOmar;
namespace Youssef
{
    public class DayTracker : Singleton<DayTracker>
    {
        public float incrementInterval = 20f;
        public TextMeshProUGUI daysCounterUI;

        private float timer = 0f;
        private int day = 0;

        public int Day { get => day; set => day = value; }
        private void Awake()
        {
            base.RegisterSingleton();
        }

        void Update()
        {
            timer += Time.deltaTime;

            if (timer >= incrementInterval)
            {
                Day++;
                timer = 0f;
            }
            if (daysCounterUI != null)
            {
                daysCounterUI.text = "Days: " + Day.ToString("F0");
            }
        }
    }
}
