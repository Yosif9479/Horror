using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGrounded;

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
