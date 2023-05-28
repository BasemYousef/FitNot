using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour, ICharacterMovement
{
    #region Serialized Private Variables
    [SerializeField] private LayerMask walkingLayer = new LayerMask();
    [SerializeField] private InputAction movement = new InputAction();
    [SerializeField] private InputAction dash = new InputAction();
    [SerializeField] private GameObject clickIndicatorPrefab;
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldownDuration = 2f;
    [SerializeField] private ParticleSystem dashVFX;
    [SerializeField] private Camera cam;
    #endregion

    #region Private Variables
    private List<GameObject> clickIndicators = new List<GameObject>();
    private Rigidbody rb;
    private NavMeshAgent agent = null;
    private Animator anim;
    private bool isDodging = false;
    RaycastHit hit;
    private bool isButtonPressed = false;
    private float holdStartTime;
    private float lastDashTime = -999f;
    
    #endregion

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (cam == null)
            cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        movement.Enable();
        dash.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        dash.Disable();
    }

    private void Update()
    {
        if (!isDodging)
            HandleInput();

        if (!anim.GetBool("Move"))
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, walkingLayer) && !EventSystem.current.IsPointerOverGameObject())
            {
                agent.velocity = Vector3.zero;
                agent.SetDestination(hit.point);
            }
        }
    }

    public void MoveTo(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public void HandleInput()
    {
        float movementValue = movement.ReadValue<float>();
        float dashValue = dash.ReadValue<float>();

        if (movementValue == 1)
        {
            anim.SetBool("Move", true);
            HandleClickIndicator();
            HandleDash(dashValue);
        }
        else
        {
            anim.SetBool("Move", false);
            if (isButtonPressed)
            {
                StartCoroutine(DestroyClickIndicators(2f));
                isButtonPressed = false;
            }
        }
    }

    private void HandleClickIndicator()
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (!isButtonPressed)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, walkingLayer) && !EventSystem.current.IsPointerOverGameObject())
            {
                GameObject newIndicator = Instantiate(clickIndicatorPrefab, hit.point + Vector3.up * 0.1f, Quaternion.identity);
                clickIndicators.Add(newIndicator);
                isButtonPressed = true;
                holdStartTime = Time.time;

                MoveTo(hit.point);
            }
        }

        if (isButtonPressed)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, walkingLayer) && !EventSystem.current.IsPointerOverGameObject())
            {
                MoveTo(hit.point);
            }
        }

        if (isButtonPressed && Time.time - holdStartTime >= 5f)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, walkingLayer) && !EventSystem.current.IsPointerOverGameObject())
            {
                Destroy(clickIndicators[clickIndicators.Count - 1]);
                clickIndicators.RemoveAt(clickIndicators.Count - 1);
                GameObject newIndicator = Instantiate(clickIndicatorPrefab, hit.point + Vector3.up * 0.1f, Quaternion.identity);
                clickIndicators.Add(newIndicator);
                holdStartTime = Time.time;
                MoveTo(hit.point);
            }
        }
    }

    private void HandleDash(float dashValue)
    {
        if (dashValue == 1 && !isDodging && Time.time - lastDashTime >= dashCooldownDuration)
        {
            StartCoroutine(Dash());
            lastDashTime = Time.time;
        }
    }

    private IEnumerator DestroyClickIndicators(float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach (GameObject indicator in clickIndicators)
        {
            Destroy(indicator);
        }
        clickIndicators.Clear();
    }

    private IEnumerator Dash()
    {
        isDodging = true;
        dashVFX.Play();
        anim.SetTrigger("Dash");
        Vector3 startPosition = transform.position;
        Vector3 dashDirection = agent.velocity.normalized;
        Vector3 targetPosition = startPosition + dashDirection * dashDistance;

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
