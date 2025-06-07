using UnityEngine;

public class P3RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }
    // Update is called once per frame
    void Update()
    {
        // Fixing the CS0131 error by replacing the assignment operator '=' with the comparison operator '=='
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
