using UnityEngine;

public class MouseLook : MonoBehaviour
{

    private Camera camera;

    [SerializeField] private float _mouseSensitivity = 100f;
    const float MAX_VERTICAL_ANGLE = 90f;

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -MAX_VERTICAL_ANGLE, MAX_VERTICAL_ANGLE);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}