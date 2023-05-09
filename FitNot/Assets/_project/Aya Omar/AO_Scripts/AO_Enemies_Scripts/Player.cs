using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private Collider planeCollider;
        RaycastHit hit;
        Ray ray;

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            //transform.position = cam.WorldToScreenPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
            if (Input.GetMouseButton(0))
            {
                ray = cam.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray,out hit))
                {
                    if (hit.collider == planeCollider)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * 5);
                        transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                    }
                }

            }


        }
    }

}
