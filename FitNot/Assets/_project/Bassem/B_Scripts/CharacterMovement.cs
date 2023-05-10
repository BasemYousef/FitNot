using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour, ICharacterMovement
{
    

    #region Serialized Private Variables
    [SerializeField] private LayerMask walkingLayer = new LayerMask();
    [SerializeField] private InputAction movement = new InputAction();
    [SerializeField] private InputAction roll = new InputAction();
    [SerializeField] private AnimationCurve dodgeCurve;
    [SerializeField] private float dodgeForce;
   
    #endregion

    #region Private Variables
    private Camera cam = null;
    private CharacterController characterController;
    private NavMeshAgent agent = null;
    private Animator anim;
    private bool isDodging = false;
    private float dodgeTimer;
    private float velocityY;
    #endregion

    void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        characterController = GetComponent<CharacterController>();
        Keyframe lastFrameDodge = dodgeCurve[dodgeCurve.length - 1];
        dodgeTimer = lastFrameDodge.time;
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

    private void FixedUpdate()
    {
        if (!isDodging)
            HandleInput();

        UpdateAnimation();
            OnDodgeRoll();
    
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

    public void MoveTo(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public void HandleInput()
    {
        if (movement.ReadValue<float>() == 1 )
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
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
    }

    private void OnDodgeRoll()
    {
        if (roll.ReadValue<float>() == 1 && !isDodging && anim.GetCurrentAnimatorStateInfo(0).IsName("Run_N") )
        {
            StartCoroutine(Dodge());
        }
    }
    IEnumerator Dodge()
    {
        anim.SetTrigger("Roll");
        isDodging = true;
        float timer = 0;
        characterController.center = new Vector3(0, 0.3f, 0);
        characterController.height = 0.3f;

        while (timer < dodgeTimer)
        {
            float speed = dodgeCurve.Evaluate(timer);
            Vector3 dir = (transform.forward * speed) + (Vector3.up * velocityY);
            characterController.Move(dir* dodgeForce * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        isDodging = false;
        characterController.center = new Vector3(0, 0.9f, 0);
        characterController.height = 1.8f;
        
    }

}
