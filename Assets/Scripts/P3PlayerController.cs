using UnityEngine;
using UnityEngine.InputSystem;

public class P3PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    public float jumpForce = 8f; // Adjust the jump force as needed
    public float gravityModifier = 1f; // Adjust the gravity modifier as needed
    public bool isOnGround = true; // Track if the player is on the ground
    public bool gameOver = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; // Modify the global gravity if needed
        animator = GetComponent<Animator>();

    }   

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard != null && keyboard.spaceKey.wasPressedThisFrame && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false; // Set to false when jumping
            animator.SetTrigger("Jump_trig"); // Trigger jump animation

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // Set to true when colliding with the ground
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true; // Set game over state when colliding with an obstacle
            Debug.Log("Game Over!");
        }

    }

}