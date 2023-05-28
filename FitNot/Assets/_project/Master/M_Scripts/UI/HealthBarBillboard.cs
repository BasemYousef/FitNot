using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class HealthBarBillboard : MonoBehaviour
    {
        [SerializeField]
        private Transform mainCamera;

        private void Update()
        {
            transform.LookAt(mainCamera);
        }
    }
}
