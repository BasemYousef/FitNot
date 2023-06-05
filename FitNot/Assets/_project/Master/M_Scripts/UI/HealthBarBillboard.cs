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
            Vector3 cameraDirection = mainCamera.transform.forward;

            // Calculate the rotation required to face the camera
            Quaternion rotation = Quaternion.LookRotation(cameraDirection, Vector3.up);

            // Set the rotation of the health bar to face the camera
            transform.rotation = rotation;
            Quaternion.LookRotation(mainCamera.position,Vector3.up);
            //transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }
    }
}
