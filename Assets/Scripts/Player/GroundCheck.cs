using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGrounded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }    
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
