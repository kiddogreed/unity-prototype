using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public Transform target;      // The object to follow
    public Vector3 offset = new(0, 5, -10); // Camera offset

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position based on the target's rotation
            Vector3 desiredPosition = target.position + target.rotation * offset;
            transform.position = desiredPosition;

            // Optionally, make the camera look at the target
            transform.LookAt(target);
        }
    }
}
