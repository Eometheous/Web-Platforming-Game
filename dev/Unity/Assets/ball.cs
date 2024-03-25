using UnityEngine;

public class ball : MonoBehaviour
{
    public pongManager manager;

    public float speed = 10f; // Speed of the ball
    public float minVelocityMagnitude = 1f;
    public float maxVelocityMagnitude = 25f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Function to launch the ball initially
    public void startMoving()
    {
        rb = GetComponent<Rigidbody2D>();
        float randomDirectionX = Random.Range(0, 2) * 2 - 1;
        float randomDirectionY = Random.Range(0, 2) * 2 - 1;
        Vector2 initialForce = new Vector2(randomDirectionX, randomDirectionY).normalized * speed;

        float clampedMagnitude = Mathf.Clamp(initialForce.magnitude, minVelocityMagnitude, maxVelocityMagnitude);
        rb.velocity = initialForce.normalized * clampedMagnitude;
    }

    // Function to reset the ball position and direction
    public void ResetBall()
    {
        transform.position = Vector2.zero;
    }

    // Function to handle collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 hitPoint = collision.GetContact(0).point;
            Vector2 paddleCenter = collision.gameObject.transform.position;

            // Calculate the direction of the ball depending on where it hit the paddle
            Vector2 direction = (hitPoint - paddleCenter).normalized;

            rb.velocity = direction * speed;
        } 
        else if (collision.gameObject == manager.p1Goal)
        {
            manager.p1Score = manager.p1Score + 1;
            Debug.Log("score on p1");
        }
        else if (collision.gameObject == manager.p2Goal)
        {
            manager.p2Score = manager.p2Score + 1;
            Debug.Log("score on p2");
        }
    }
}
