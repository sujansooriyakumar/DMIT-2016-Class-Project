using System.Collections;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public float maxDistance;
    private Vector3 startPosition;
    private int direction = -1;
    public float moveSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        BeginPatrol();
    }
    
    public void BeginPatrol()
    {
        StartCoroutine(PatrolCoroutine());
    }

    private IEnumerator PatrolCoroutine()
    {
        Vector3 origin = startPosition;
        float maxDist = maxDistance;

        while (true)
        {
            rb.linearVelocityX = direction * moveSpeed;

            float offset = transform.position.x - origin.x;

            // moving right and beyond limit
            if (direction > 0 && offset >= maxDist)
            {
                direction = -1;
            }
            // moving left and beyond limit
            else if (direction < 0 && offset <= -maxDist)
            {
                direction = 1;
            }

            yield return new WaitForFixedUpdate();
        }
    }


}
