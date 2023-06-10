using System.Collections;
using System.Collections.Generic;
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

        private Vector3 _input;
        private Animator anim;
        private HealthManager health;
        private void Start()
        {
            anim = GetComponent<Animator>();
            health = GetComponent<HealthManager>();
        }
        private void Update()
        {
            if(health.isDead) return;
            GatherInput();
            Look();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void GatherInput()
        {
            _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }

        private void Look()
        {
            if (_input == Vector3.zero) return;
            var relative = (transform.position + _input.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }

        private void Move()
        {
            _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
            if(_input.x != 0f || _input.z != 0f)
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
