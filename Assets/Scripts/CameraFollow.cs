using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 0.125f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Calculate the desired position based on the target's position and the offset
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smoothly interpolate between the current position and the desired position
        transform.position = smoothedPosition;

        transform.LookAt(target.position); // Make the camera look at the target
    }
}