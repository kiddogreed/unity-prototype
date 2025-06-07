using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private float leftBound = -5.75f;

    void Update()
    {
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}