using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 40f;
    private float maxSpeed = 60f;
    private float turnSpeed = 100f;
    private bool isMoving = true;
    private int moveDirection = 1; // 1 for forward, -1 for backward

    public GameObject projectilePrefab;
    public float shootForce = 30f;
    public float projectileLifetime = 3f;
    public Vector3 projectileOffset = new Vector3(0, 3, 5);
    public float recoilForce = 10f;
    public Rigidbody rb;

    public float horizontal = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
        }
        // Prevent tilting by freezing rotation on X and Z axes
        rb.freezeRotation = false;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        horizontal = 0f;

        if (keyboard != null)
        {
            if (keyboard.leftArrowKey.isPressed)
                horizontal = -1f;
            if (keyboard.rightArrowKey.isPressed)
                horizontal = 1f;

            // Move backward while holding down arrow, forward with up arrow
            if (keyboard.downArrowKey.isPressed)
            {
                isMoving = true;
                moveDirection = -1;
            }
            else if (keyboard.upArrowKey.isPressed)
            {
                isMoving = true;
                moveDirection = 1;
            }
            else if (!keyboard.upArrowKey.isPressed && !keyboard.downArrowKey.isPressed)
            {
                isMoving = false;
            }

            if (keyboard.spaceKey.wasPressedThisFrame && projectilePrefab != null)
            {
                Vector3 spawnPos = transform.position + transform.forward * projectileOffset.z + transform.up * projectileOffset.y + transform.right * projectileOffset.x;
                GameObject projectile = Instantiate(projectilePrefab, spawnPos, transform.rotation);
                Debug.Log("Projectile spawned at: " + spawnPos);

                Rigidbody projRb = projectile.GetComponent<Rigidbody>();
                if (projRb != null)
                {
                    projRb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
                }

                // Apply recoil to the player in the opposite direction
                if (rb != null)
                {
                    rb.AddForce(-transform.forward * recoilForce, ForceMode.Impulse);
                }

                Destroy(projectile, projectileLifetime);
            }
        }

        // Rotate for steering (keep in Update for responsiveness)
        if (rb != null)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, horizontal * turnSpeed * Time.deltaTime, 0));
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            if (isMoving)
            {
                // Move forward or backward based on moveDirection
                rb.AddForce(transform.forward * moveSpeed * moveDirection, ForceMode.Acceleration);
            }

            // Clamp the velocity to maxSpeed
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }
}