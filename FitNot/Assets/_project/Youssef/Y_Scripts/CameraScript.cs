using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class CameraScript : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float alphaValue = 0.5f;

        private RaycastHit hit;
        private float distanceFromCameraToPlayer;
        private void Start()
        {
            distanceFromCameraToPlayer = Vector3.Distance(transform.position, target.position);
        }
        private void LateUpdate()
        {
            transform.position = target.position;
            RayCastCheckLayer();
        }
        void RayCastCheckLayer()
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, distanceFromCameraToPlayer))
            {
                // check if the object hit by the raycast has a renderer
                Renderer renderer = hit.transform.GetComponent<Renderer>();
                if (renderer != null)
                {
                    // change the material's alpha value
                    Color color = renderer.material.color;
                    color.a = alphaValue;
                    renderer.material.color = color;
                }
            }
        }
    }
}
