using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed = 8;
    [SerializeField] private float jumpSpeed = 20;
    [SerializeField] private float gravity = 2;

    private CharacterController controller;

    private InputAction moveAction;
    private InputAction jumpAction;
    private Vector2 movementInput = new(0, 0);
    private Vector3 movement = new(0, 0, 0);

    void Start() {
        controller = GetComponent<CharacterController>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        jumpAction.started += Jump;
    }

    void Update() {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate() {
        movement.x = movementInput.x * speed * Time.fixedDeltaTime;
        movement.z = movementInput.y * speed * Time.fixedDeltaTime;
        if (controller.isGrounded && movement.y < 0) movement.y = 0;
        movement.y -= gravity * Time.fixedDeltaTime;
        controller.Move(movement);
    }

    void Jump(InputAction.CallbackContext context)
    {
        if (controller.isGrounded)
        {
            movement.y = jumpSpeed;
        }
    }
}
