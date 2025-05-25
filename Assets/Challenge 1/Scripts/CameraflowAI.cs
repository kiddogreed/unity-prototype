using UnityEngine;

public class CameraflowAI : MonoBehaviour
{
    public Transform target; // Assign your player object in the Inspector

    // Default camera position
    private Vector3 defaultPosition = new Vector3(13.96f, 2.1f, 0.77f);
    private float zOffset;
    private float yOffset;

    void Start()
    {
        if (target != null)
        {
            zOffset = defaultPosition.z - target.position.z;
            yOffset = defaultPosition.y - target.position.y;
            transform.position = defaultPosition;
            transform.LookAt(target);
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Follow the target's z and y movement, keep x fixed
            Vector3 camPos = transform.position;
            camPos.z = target.position.z + zOffset;
            camPos.y = target.position.y + yOffset;
            transform.position = camPos;
            transform.LookAt(target);
        }
    }
}