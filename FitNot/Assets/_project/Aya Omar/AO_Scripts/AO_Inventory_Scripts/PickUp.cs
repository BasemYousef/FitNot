using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class PickUp : MonoBehaviour
    {
        private Inventory inventory;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {

            }
        }
    }
}
