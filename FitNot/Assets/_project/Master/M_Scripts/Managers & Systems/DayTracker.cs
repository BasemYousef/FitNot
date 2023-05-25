using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Youssef
{
    public class DayTracker : MonoBehaviour
    {
        public float incrementInterval = 20f;
        public TextMeshProUGUI daysCounterUI;

        private float timer = 0f;
        private int day = 0;

        public int Day { get => day; set => day = value; }

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
                daysCounterUI.text = Day.ToString("F0");
            }
        }
    }
}
