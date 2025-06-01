using UnityEngine;
using UnityEngine.InputSystem;

public class HumanController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float minX = -24f;
    public float maxX = 24f;
    public float minZ = -2f;
    public float maxZ = 15f;

    public GameObject projectilePrefab;   // Assign your projectile prefab in the Inspector
    public float shootForce = 20f;        // Force applied to the projectile
    public float projectileLifetime = 3f; // Time before the projectile is destroyed
    public Vector3 projectileOffset = new Vector3(0, 1, 1); // Offset in front of the player

    void Update()
    {
        var keyboard = Keyboard.current;
        float moveX = 0f;
        float moveZ = 0f;

        if (keyboard != null)
        {
            if (keyboard.leftArrowKey.isPressed)
                moveX = -1f;
            if (keyboard.rightArrowKey.isPressed)
                moveX = 1f;
            if (keyboard.upArrowKey.isPressed)
                moveZ = 1f;
            else if (keyboard.downArrowKey.isPressed)
                moveZ = -1f;

            // Shoot projectile with Spacebar
            if (keyboard.spaceKey.wasPressedThisFrame && projectilePrefab != null)
            {
                // Always shoot along world Z+
                Vector3 spawnPos = transform.position + new Vector3(0, projectileOffset.y, projectileOffset.z);
                GameObject projectile = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);

                Rigidbody projRb = projectile.GetComponent<Rigidbody>();
                if (projRb != null)
                {
                    projRb.AddForce(Vector3.forward * shootForce, ForceMode.Impulse);
                }

                Destroy(projectile, projectileLifetime);
            }
        }

        Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;

        if (moveDir.magnitude > 0f)
        {
            Vector3 newPosition = transform.position + moveDir * moveSpeed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);
            transform.position = newPosition;
        }
    }
}