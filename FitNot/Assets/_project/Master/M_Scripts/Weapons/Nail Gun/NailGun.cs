using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Youssef
{
    public class NailGun : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public Transform projectileSpawnPoint;
        public int projectileCount = 10;
        public float projectileSpeed = 10f;
        public float fireRate = 0.1f;
        public bool isOutOfAmmo = false;

        [SerializeField] private InputAction shoot = new InputAction();
        private float fireTimer;
        private void OnEnable()
        {
            shoot.Enable();
        }

        private void OnDisable()
        {
            shoot.Disable();
        }
        private void Update()
        {
            fireTimer += Time.deltaTime;
            //Mouse.current.rightButton.wasPressedThisFrame
            if (shoot.triggered && fireTimer >= fireRate && projectileCount > 0)
            {

                fireTimer = 0f;
                projectileCount--;

                GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
                projectileRigidbody.velocity = projectileSpawnPoint.up * projectileSpeed;
            }
            if(projectileCount <= 0)
            {
                isOutOfAmmo= true;
            }
        }
    }
}
