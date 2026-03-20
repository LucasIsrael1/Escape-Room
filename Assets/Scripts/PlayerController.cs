using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private InputActionReference move;
    private Vector3 movementInput = new Vector3(0, 0, 0);
    [SerializeField] private float speed = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 inputVector = move.action.ReadValue<Vector2>();
        movementInput.x = inputVector.x * speed;
        movementInput.y = rb.linearVelocity.y;
        movementInput.z = inputVector.y * speed;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movementInput;
    }
}
