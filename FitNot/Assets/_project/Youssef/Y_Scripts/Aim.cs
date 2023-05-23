using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Youssef
{
    public class Aim : MonoBehaviour
    {
        //[SerializeField] float rotationSpeed = 360f;
        //private void Update()
        //{
        //    //Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        //    //float t = Camera.main.transform.position.y / (Camera.main.transform.position.y - point.y);
        //    //Vector3 finalPoint = new Vector3(t * (point.x - Camera.main.transform.position.x) + Camera.main.transform.position.x, 1,
        //    //    t * (Camera.main.transform.position.z) + Camera.main.transform.position.z);
        //    //transform.LookAt(finalPoint);

        //    //// Get the mouse position in screen space
        //    //Vector3 mousePosition = Input.mousePosition;

        //    //// Convert the mouse position from screen space to world space
        //    //mousePosition.z = transform.position.z - Camera.main.transform.position.z;
        //    //Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);


        //    //// Rotate the player to face the target position
        //    ////transform.rotation = Quaternion.Euler(0,targetPosition.z * rotationSpeed, 0);
        //    //transform.rotation = Quaternion.RotateTowards(Quaternion.identity, Quaternion.Euler(0,targetPosition.z,0), rotationSpeed);

        //}
        //void Update()
        //{
        //    //Mouse Position in the world. It's important to give it some distance from the camera. 
        //    //If the screen point is calculated right from the exact position of the camera, then it will
        //    //just return the exact same position as the camera, which is no good.
        //    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        //    //Angle between mouse and this object
        //    float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

        //    //Ta daa
        //    transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
        //}

        //float AngleBetweenPoints(Vector3 a, Vector3 b) 
        //{ return Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg; }


        // Angular speed in radians per sec.
        public float speed = 10.0f;
        void Update()
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 0.1f);
            // Determine which direction to rotate towards
            Vector3 targetDirection = new Vector3(mouseWorldPosition.x - transform.position.x, 0f, mouseWorldPosition.z - transform.position.z);

            // The step size is equal to speed times frame time.
            float singleStep = speed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Draw a ray pointing at our target in
            Debug.DrawRay(transform.position, newDirection, Color.red);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            // multiplying by 0 in the x and z axis because i don't want the character to rotate in those axis
            transform.rotation = Quaternion.LookRotation(newDirection) * Quaternion.Euler(0f, 1.6f, 0f); 
        }

    }
}
