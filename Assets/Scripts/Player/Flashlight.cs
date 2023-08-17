using UnityEngine;

[RequireComponent(typeof(Light))]
public class Flashlight : MonoBehaviour
{
    private bool isActive = true;
    private Light light;

    private void Start()
    {
        light = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isActive = !isActive;
            light.enabled = isActive;
        }
    }
}
