using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class FoodItem : MonoBehaviour
    {
        public float hungerRefillAmount = 20f;

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<HungerSystem>().Eat(hungerRefillAmount);

            Destroy(gameObject);
        }
    }
}
