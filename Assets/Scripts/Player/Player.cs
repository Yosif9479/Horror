using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 8f;

    private Rigidbody rigidbody;
    private GroundCheck groundCheck;
    private bool isGrounded;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        isGrounded = groundCheck.IsGrounded();

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;
        rigidbody.velocity = new Vector3(movement.x * _moveSpeed, rigidbody.velocity.y, movement.z * _moveSpeed);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
