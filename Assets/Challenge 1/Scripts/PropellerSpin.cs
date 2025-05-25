using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
   public float spinSpeed = 100f; // Speed of the propeller spin in degrees per second

    public void Update()
    {
        // Rotate the propeller around its local Z axis
        transform.Rotate(0f,0f , spinSpeed * Time.deltaTime);

    }
}
