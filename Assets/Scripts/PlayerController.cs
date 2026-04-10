using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float pushForce;
    [SerializeField] private float cameraAxisSpeedBoost;

    private CharacterController controller;

    private InputAction moveAction;
    private InputAction jumpAction;
    private Vector2 movementInput = new(0, 0);
    private Vector3 movement = new(0, 0, 0);

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction.Enable();
        jumpAction.Enable();
        jumpAction.started += Jump;
    }

    void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        jumpAction.started -= Jump;
    }

    void Update() {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate() {
        movement.x = movementInput.x * speed * Time.fixedDeltaTime;
        movement.z = movementInput.y * speed * Time.fixedDeltaTime * cameraAxisSpeedBoost;
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

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb == null) return;
        Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
        if (forceDirection.y > 0.5f) return; 
        if (Math.Abs(forceDirection.x) < 0.5) forceDirection.x = 0;
        else forceDirection.x = (float)Math.Floor(forceDirection.x * 3) / 3f;
        forceDirection.y = 0;
        if (Math.Abs(forceDirection.z) < 0.5) forceDirection.z = 0;
        else forceDirection.z = (float)Math.Floor(forceDirection.z * 3) / 3f;
        forceDirection.Normalize();
        rb.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Impulse);
    }
}
