using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Youssef
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private float _speed = 7;
        [SerializeField] private float _turnSpeed = 360;

        private Vector3 _movementInput; // Changed to Vector3
        private Animator anim;
        private HealthManager health;
        private InputAction _moveAction;

        private void Start()
        {
            anim = GetComponent<Animator>();
            health = GetComponent<HealthManager>();
            _rb = GetComponent<Rigidbody>();

            // Get the input action from the PlayerInput component
            var playerInput = GetComponent<PlayerInput>();
            _moveAction = playerInput.actions["Move"];
            _moveAction.Enable();
        }

        private void Update()
        {
            if (health.isDead) return;
            GatherInput();
            Look();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void GatherInput()
        {
            // Read the movement input value
            _movementInput = new Vector3(_moveAction.ReadValue<Vector2>().x, 0f, _moveAction.ReadValue<Vector2>().y);
        }

        private void Look()
        {
            if (_movementInput == Vector3.zero) return;

            // Calculate the rotation towards the movement input
            var relative = transform.position + _movementInput.ToIso() - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }

        private void Move()
        {
            _rb.MovePosition(transform.position + transform.forward * _movementInput.normalized.magnitude * _speed * Time.deltaTime);
            if (_movementInput != Vector3.zero)
            {
                anim.SetBool("Move", true);
            }
            else
            {
                anim.SetBool("Move", false);
            }
        }
    }

    public static class Helpers
    {
        private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, -45, 0));
        public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
    }
}