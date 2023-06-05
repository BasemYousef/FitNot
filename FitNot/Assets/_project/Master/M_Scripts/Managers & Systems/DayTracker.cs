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
        public float incrementInterval = 60f;
        public TextMeshProUGUI daysCounterUI;
        public TextMeshProUGUI daysTrackerUI;
        public Slider dayTrackerSlider;

        private float timer = 0f;
        private int day = 1;

        public int Day { get => day; set => day = value; }
        private void Awake()
        {
            base.RegisterSingleton();
        }

        void Update()
        {
            timer += Time.deltaTime;

            dayTrackerSlider.value = timer;
            if (timer >= incrementInterval)
            {
                Day++;
                timer = 0f;
                UpdateDayTrackerText();
                Invoke("HideDayTrackerTxt", 5);
            }
            if (daysCounterUI != null)
            {
                daysCounterUI.text = Day.ToString("F0");
            }
        }

        private void UpdateDayTrackerText()
        {
            daysTrackerUI.gameObject.SetActive(true);
            daysTrackerUI.text = "DAY " + Day.ToString();
        }
        private void HideDayTrackerTxt()
        {
            daysTrackerUI.gameObject.SetActive(false);
        }
    }
}