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
    private Vector2 movementInput = Vector2.zero;
    private Vector3 movement = Vector3.zero;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        moveAction.Enable();
        jumpAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }

    void Update() {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate() {
        movement.x = movementInput.x * speed * Time.fixedDeltaTime;
        movement.z = movementInput.y * speed * Time.fixedDeltaTime * cameraAxisSpeedBoost;
        if (controller.isGrounded)
        {
            if (movement.y < 0) movement.y = 0;
            if (jumpAction.IsPressed()) movement.y = jumpSpeed;
        }
        movement.y -= gravity * Time.fixedDeltaTime;
        controller.Move(movement);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb == null) return;

        Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
        if (forceDirection.y > 0.5f) return;
        
        forceDirection.x = GetPushingForce(forceDirection.x);
        forceDirection.z = GetPushingForce(forceDirection.z);
        forceDirection.y = 0;
        rb.AddForceAtPosition(forceDirection.normalized * pushForce, transform.position, ForceMode.Impulse);
    }

    private float GetPushingForce(float force)
    {
        if (Math.Abs(force) < 0.5) return 0;
        return (float)Math.Floor(force * 3) / 3f;
    }
}
