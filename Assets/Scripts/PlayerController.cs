using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float pushForce;
    [SerializeField] private float cameraAxisSpeedBoost;
    [SerializeField] private GameObject model;
    [SerializeField] private Animator animator;
 
    private CharacterController controller;

    private InputAction moveAction;
    private InputAction jumpAction;
    private Vector2 movementInput = Vector2.zero;
    private Vector3 movement = Vector3.zero;

    private bool isWalking;
    private bool isJumping;

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
            if (isJumping) isJumping = false;
            if (movement.y < 0) movement.y = 0;
            if (jumpAction.IsPressed())
            {
                SoundManager.PlaySound("jump");
                movement.y = jumpSpeed;
                isJumping = true;
            }
        }
        movement.y -= gravity * Time.fixedDeltaTime;
        controller.Move(movement);

        isWalking = movementInput.sqrMagnitude != 0;

        if (movementInput.sqrMagnitude != 0) rotateModel(movement);

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isJumping", isJumping);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb == null) return;

        Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
        if (Math.Abs(forceDirection.y) > 0.5f) return;
        
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

    private void rotateModel(Vector3 direction)
    {
        direction.y = 0;
        direction *= -1;
        model.transform.rotation = Quaternion.Slerp(
            model.transform.rotation, Quaternion.LookRotation(direction),
            Time.fixedDeltaTime * 30f
        );
    }
}
