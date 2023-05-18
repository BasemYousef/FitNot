using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace Youssef
{
    public class HungerSystem : MonoBehaviour
    {
        public float startingHungerLevel = 100f;
        public float hungerDrainRate = 0.5f;
        public float hungerDamageRate = 5f;
        public float currentHungerLevel;
        public Slider hungerSlider;

        [SerializeField] private GameObject player;
        private bool isStarving = false;
        private float timeSinceLastDamage = 0f;
        void Start()
        {
            currentHungerLevel = startingHungerLevel;
            hungerSlider.maxValue = startingHungerLevel;
            hungerSlider.value = currentHungerLevel;
            hungerSlider.onValueChanged.AddListener(UpdateHungerLevel);
        }

        // Update is called once per frame
        void Update()
        {
            currentHungerLevel -= hungerDrainRate * Time.deltaTime;
            timeSinceLastDamage += Time.deltaTime;

            UpdateHungerLevel(currentHungerLevel);
            //Debug.Log(string.Format("Current Hunger Level: {0:F0}", currentHungerLevel));

            if (currentHungerLevel <= 0f)
            {
                isStarving = true;

                if (timeSinceLastDamage >= 2f)
                {
                    timeSinceLastDamage = 0f;

                    player.GetComponent<HealthManager>().TakeDamage(hungerDamageRate);
                }
                
            }
        }
        public void Eat(float amount)
        {
            currentHungerLevel += amount;
            currentHungerLevel = Mathf.Clamp(currentHungerLevel,0 , startingHungerLevel);
            isStarving= false;
        }
        public void UpdateHungerLevel(float newHungerLevel)
        {
            currentHungerLevel = newHungerLevel;
            currentHungerLevel = Mathf.Clamp(currentHungerLevel, 0, startingHungerLevel);
            hungerSlider.value = currentHungerLevel;
        }
    }
}
