using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class HealthItem : MonoBehaviour
    {
        public float healingamount = 20f;

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<HealthManager>().Heal(healingamount);

            Destroy(gameObject);
        }
    }
}
