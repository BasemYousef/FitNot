using AyaOmar;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Youssef
{
    public class Dash : MonoBehaviour
    {
        [SerializeField] private float dashDistance = 5f;
        [SerializeField] private float dashDuration = 0.2f;
        [SerializeField] private float dashCooldownDuration = 2f;
        [SerializeField] private ParticleSystem dashVFX;
        [SerializeField] private InputAction dash = new InputAction();
        [SerializeField] private Transform dashForward;


        private Animator anim;
        private bool isDodging = false;
        private float lastDashTime = -999f;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }
        private void Update()
        {
            if (!isDodging)
                    HandleInput();
        }
        private void OnEnable()
        {
            dash.Enable();
        }

        private void OnDisable()
        {
            dash.Disable();
        }

        public void HandleInput()
        {
            float dashValue = dash.ReadValue<float>();
            if (anim.GetBool("Move"))
            {
                HandleDash(dashValue);
            }
        }
        private void HandleDash(float dashValue)
        {
            if (dashValue == 1f && !isDodging && Time.time - lastDashTime >= dashCooldownDuration)
            {
                StartCoroutine(DashCo());
                lastDashTime = Time.time;
            }
        }
        private IEnumerator DashCo()
        {
            isDodging = true;
            dashVFX.Play();
            anim.SetTrigger("Dash");
            Vector3 startPosition = transform.position;
            startPosition.y = 0f;
            Vector3 dashDirection =  new Vector3(dashForward.position.x, 0f, dashForward.position.z) - startPosition;
            dashDirection.y = 0f;
            Vector3 targetPosition = startPosition + dashDirection * dashDistance;
            targetPosition.y = 0f;

            float timer = 0f;
            while (timer < dashDuration)
            {
                float elapsedTime = timer / dashDuration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
                timer += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;

            isDodging = false;
        }
    }
}
