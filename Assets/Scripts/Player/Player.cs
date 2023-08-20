using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private GroundCheck _groundCheck;
    [SerializeField] private bool _isGrounded;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        _isGrounded = _groundCheck.IsGrounded();

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;

        movement = Vector3.ClampMagnitude(movement, 1f);
        movement *= _moveSpeed;

        if (_isGrounded)
        {
            _rigidbody.velocity = new Vector3(movement.x, _rigidbody.velocity.y, movement.z);
        }

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
