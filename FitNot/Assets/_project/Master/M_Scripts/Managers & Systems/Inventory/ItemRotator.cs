using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class ItemRotator : MonoBehaviour
    {
        public Vector3 rotationSpeed; // Speed of rotation in degrees per second

        void Update()
        {
            // Rotate the game object around the y-axis
            transform.Rotate(rotationSpeed.x * Time.deltaTime, 
                            rotationSpeed.y * Time.deltaTime, 
                            rotationSpeed.z * Time.deltaTime);
        }
    }
}
