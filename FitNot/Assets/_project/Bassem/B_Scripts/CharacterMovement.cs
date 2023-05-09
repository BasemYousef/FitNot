using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour,ICharacterMovement
{
    #region Serialized Private Variables
    [SerializeField] private LayerMask walkingLayer = new LayerMask();
    [SerializeField] private InputAction movement = new InputAction();
    [SerializeField] private InputAction roll = new InputAction();
    [SerializeField] private float rollSpeed =10f;
    [SerializeField] private float rollDuration = 0.5f;
    #endregion
    #region Private Variables
    private Camera cam = null;
    private NavMeshAgent agent = null;
    private Animator anim;
    private bool isRolling = false;

    #endregion
    void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnEnable()
    {
        movement.Enable();
        roll.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
        roll.Disable();
    }

    private void Update()
    {
        HandleInput();
        UpdateAnimation();
    }
   
    
    private void UpdateAnimation()
    {
        
        if (agent.velocity.magnitude > 0.1f)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }
   public IEnumerator Roll()
   {

        Vector3 rollDirection = transform.forward;

        isRolling = true;
       
        anim.SetTrigger("Roll");
        float startTime = Time.time;
        while (Time.time < startTime + rollDuration)
        {
            transform.position += rollDirection * rollSpeed * Time.deltaTime;
            yield return null;
        }

        agent.enabled = true;
        isRolling = false;
   }

    public void MoveTo(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public void HandleInput()
    {
        if (movement.ReadValue<float>() == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            anim.SetBool("Move", true);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500, walkingLayer))
            {
                MoveTo(hit.point);
            }
        }
        else
        {
            anim.SetBool("Move", false);
        }
        if (roll.triggered && !isRolling)
        {
            StartCoroutine(Roll());
        }
    }
}

