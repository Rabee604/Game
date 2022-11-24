using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private Vector3 positionToLookAt;
    private CharacterController characterController;
    private PlayerControls playerControls;
    private Vector2 currentMove;
    private Vector2 currentLook;
    private Vector3 lookPosition;
    private Vector3 currentMovement;
    private bool IsMoveIsPressed;
    private bool IsRunIsPressed;
    private bool IsAttack;
    private Animator animator;
    private bool IsWalking;
    private bool IsRunnig;
    private Vector3 VectorRunSpeed;
    private float runSpeed = 12;
    private float rotationFactorPerFrame=1;
    private PlayerHealth playerHealth;
    
    private void Awake()
    {
        playerHealth = new PlayerHealth();
        playerControls = new PlayerControls();
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        // her we call OnMove funktion
        playerControls.Land.Move.started += OnMove; 
        playerControls.Land.Move.canceled += OnMove;
        playerControls.Land.Run.started += OnRun;
        playerControls.Land.Run.canceled += OnRun;
        playerControls.Land.Attack.started += OnAttack;
        playerControls.Land.Attack.canceled += OnAttack;
        
        
    }

    void rotation()
    {
        
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;
        Quaternion currentRotation = transform.rotation;
        if (IsMoveIsPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame);
        }

    }
    void OnAttack(InputAction.CallbackContext context)
    {
        IsAttack = context.ReadValueAsButton();
    }

    void OnRun(InputAction.CallbackContext context)
    {
        IsRunIsPressed = context.ReadValueAsButton();
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        currentMove = context.ReadValue<Vector2>();
        currentMovement.x = currentMove.x;
        currentMovement.z = currentMove.y;
        VectorRunSpeed.x = currentMove.x * runSpeed;
        VectorRunSpeed.z = currentMove.y * runSpeed;
        IsMoveIsPressed = currentMove.x !=0 || currentMove.y != 0;
    }
    // to use the Action map we have to enable it in script
    private void OnEnable()
    {
        playerControls.Land.Enable();
    }
    
    private void OnDisable()
    
    {
        playerControls.Land.Disable();
    }

    
    //Update call every frame 60 fram pr. second. Player move fast. 
    // That why we use time.deltaTime to make slow. 
    
    private void Update()
    {
       
            rotation();
            updateAnimation();
            if (IsRunIsPressed && currentMovement != Vector3.zero)
            {
                characterController.Move(VectorRunSpeed * Time.deltaTime);
                animator.SetFloat("PlayerSpeed", 1, 0.1f, Time.deltaTime);
            }

            else if (currentMovement != Vector3.zero)
            {
                characterController.Move(currentMovement * Time.deltaTime);
                animator.SetFloat("PlayerSpeed", 0.5f, 0.1f, Time.deltaTime);
            }
            else
            {
                animator.SetFloat("PlayerSpeed", 0, 0.1f, Time.deltaTime);
            }

            if (IsAttack)
            {
                animator.SetTrigger("Attack");
            }
    }



    

    public bool isMove()
    {
        if (currentMovement== Vector3.zero)
        {
            return true;
        }

        return false;
    }
    /*private void OnCollisionEnter(Collision other)
       {
         Debug.Log(other.gameObject.tag=="enemy");
         Debug.Log("Jeg er i player");
           
               //animator.SetTrigger("hit");
           
           


       }*/

   

    private void updateAnimation()
    
    {
        
       //get parameter values fra animator
        /*IsRunnig = animator.GetBool("ISRunning");
        IsWalking = animator.GetBool("IsWalking");

        if (IsMoveIsPressed && !IsWalking)
        {
            animator.SetBool("IsWalking", true);

        }
        else if (!IsMoveIsPressed && IsWalking)
        {
            animator.SetBool("IsWalking", false);
            
            
        }*/
        
    }
}

