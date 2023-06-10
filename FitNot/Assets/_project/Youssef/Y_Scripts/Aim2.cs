using AyaOmar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class Aim2 : MonoBehaviour
    {
        private GameObject aimPosition;
        private void Start()
        {
            aimPosition = GameManager.Instance.GetAimObjectRef();
        }
        // Update is called once per frame
        void Update()
        {
            //transform.LookAt(aimPosition);
            Vector3 direction = new Vector3(aimPosition.transform.position.x - transform.position.x, 0f, aimPosition.transform.position.z - transform.position.z);
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, 360f, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up); //* Quaternion.Euler(0f, 1f, 0f);  commented because vector3.up does the same thing
        }
    }
}
