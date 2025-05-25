using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerAI : MonoBehaviour
{
    public float pitchSpeed = 50f; // Speed of pitch rotation (degrees per second)
    public float rollSpeed = 50f;  // Speed of roll rotation (degrees per second)
    public float moveSpeed = 10f;  // Forward movement speed (units per second)

    void Update()
    {
        float pitch = 0f;
        float roll = 0f;

        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            // Left arrow: pitch up (decrease X rotation), Right arrow: pitch down (increase X rotation)
            if (keyboard.leftArrowKey.isPressed)
                pitch = -1f;
            if (keyboard.rightArrowKey.isPressed)
                pitch = 1f;

            // Up arrow: roll right (increase Z rotation), Down arrow: roll left (decrease Z rotation)
            if (keyboard.upArrowKey.isPressed)
                roll = 1f;
            if (keyboard.downArrowKey.isPressed)
                roll = -1f;
        }

        // Apply pitch rotation (X axis)
        if (pitch != 0f)
        {
            transform.Rotate(pitch * pitchSpeed * Time.deltaTime, 0f, 0f);
        }

        // Apply roll rotation (Z axis)
        if (roll != 0f)
        {
            transform.Rotate(0f, 0f, roll * rollSpeed * Time.deltaTime);
        }

        // Move forward constantly at moveSpeed
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}