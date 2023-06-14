using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Youssef
{
    public class FollowMousePosition : MonoBehaviour
    {
        [SerializeField] private LayerMask walkingLayer = new LayerMask();
        RaycastHit hit;
        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, walkingLayer))
            {
                transform.position = new Vector3(hit.point.x, 0.9f, hit.point.z);
            }
            //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //mousePosition.y = 1f;
            //Vector3 direction = mousePosition;
            //transform.position = direction;
        }
    }
}
