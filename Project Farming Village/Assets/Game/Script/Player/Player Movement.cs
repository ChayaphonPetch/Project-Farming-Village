using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputs playerinputs;
    [SerializeField] private int speed = 5;
    [SerializeField] private GameObject MainUI;
    private Animator animator;


    private Vector2 movement;
    private Rigidbody2D rb;

    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerinputs = new PlayerInputs();

    }
    private void OnEnable()
    {
        playerinputs.InGame.Enable();
    }

    private void OnDisable()
    {
        playerinputs.InGame.Disable();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        if (dialogueUI.IsOpen) return;

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

        //rb.AddForce(movement*speed);
    }

    private void Update()
    {
        if (playerinputs.InGame.Interact.triggered)
        {
            if (!dialogueUI.IsOpen)
            {
                Interactable?.Interact(player: this);
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", movement.x);
            animator.SetFloat("LastInputY", movement.y);
        }
        movement = context.ReadValue<Vector2>();
        if (movement != null)
        {
            
        }
        animator.SetFloat("InputX", movement.x);
        animator.SetFloat("InputY", movement.y);
    }
}
