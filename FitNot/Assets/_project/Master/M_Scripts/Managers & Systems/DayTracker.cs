using UnityEngine;
using TMPro;

namespace Youssef
{
    public class DayTracker : MonoBehaviour
    {
        public static DayTracker Instance { get; private set; }

        public float incrementInterval = 20f;
        public TextMeshProUGUI daysCounterUI;

        private float timer = 0f;
        private int day = 11;

        public int Day { get => day; set => day = value; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
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
