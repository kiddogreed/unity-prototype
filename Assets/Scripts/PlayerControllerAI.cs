using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float minSpeed = 5f;
    public float maxSpeed = 60f;
    public float turnSpeed = 100f;
    private bool isMoving = true;

    public GameObject projectilePrefab;
    public float shootForce = 30f;
    public float projectileLifetime = 3f;
    public Vector3 projectileOffset = new Vector3(0, 3, 5);
    public float recoilForce = 10f;
    private Rigidbody rb;

    private float horizontal = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
        }
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

            if (keyboard.downArrowKey.wasPressedThisFrame)
                isMoving = false;

            if (keyboard.upArrowKey.wasPressedThisFrame)
                isMoving = true;

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
                // Use AddForce for forward movement so recoil is not overridden
                rb.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
            }

            // Clamp the velocity to maxSpeed
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }
}