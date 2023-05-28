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
            transform.LookAt(mainCamera.position);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }
    }
}
