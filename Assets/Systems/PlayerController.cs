using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveInput;

    private Rigidbody2D playerRb;

    private Animator playerAnimController;

    // Store Animator references using a hash for better performance
    private int MoveInputXHash = Animator.StringToHash("MoveInputX");
    private int MoveInputYHash = Animator.StringToHash("MoveInputY");
    private int IsMovingHash = Animator.StringToHash("IsMoving");


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        if (playerRb == null) Debug.LogError("Rigidbody2D component not found on the player object.");

        playerAnimController = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        HandlePlayerAnimations();
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    private void LateUpdate()
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void HandlePlayerMovement()
    {
        playerRb.MovePosition(playerRb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    private void HandlePlayerAnimations()
    {
        // When the player is moving we want to pass through the inputs
        if(moveInput != Vector2.zero)
        {
            playerAnimController.SetFloat(MoveInputXHash, moveInput.x);
            playerAnimController.SetFloat(MoveInputYHash, moveInput.y);

            playerAnimController.SetBool(IsMovingHash, true);
        }
        else
        {
            playerAnimController.SetBool(IsMovingHash, false);
        }

    }



}
















