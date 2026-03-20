using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;

    private InputAction moveAction;
    
    [SerializeField] private float speed = 8;
    [SerializeField] private float acceleration = 8;
    private Vector3 movementInput = new Vector3(0, 0, 0);

    void Start() {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update() {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate() {
        Vector3 targetVelocity = new Vector3(movementInput.x * speed, 0, movementInput.y * speed);
        rb.linearVelocity = Vector3.MoveTowards(rb.linearVelocity, targetVelocity, Time.fixedDeltaTime * acceleration);
    }
}
