using UnityEngine;

public class ball : MonoBehaviour
{
    public pongManager manager;

    public float speed = 10f; // Speed of the ball
    public float minVelocityMagnitude = 1f;
    public float maxVelocityMagnitude = 25f;
    public Vector3 initPos;

    private Rigidbody2D rb;

    public void StartMoving()
    {
        rb = GetComponent<Rigidbody2D>();
        float randomDirectionX = Random.value < 0.5f ? -1.0f : 1.0f;
        float randomDirectionY = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector2 initialForce = new Vector2(randomDirectionX, randomDirectionY).normalized * speed;

        float clampedMagnitude = Mathf.Clamp(initialForce.magnitude, minVelocityMagnitude, maxVelocityMagnitude);
        rb.velocity = initialForce.normalized * clampedMagnitude;
    }

    public void ResetBall()
    {
        rb.velocity = Vector3.zero;
        transform.position = initPos;
    }

    public void StopBall()
    {
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 hitPoint = collision.GetContact(0).point;
            Vector2 paddleCenter = collision.gameObject.transform.position;
            Vector2 direction = (hitPoint - paddleCenter).normalized;

            rb.velocity = direction * speed;
        } 
        else if (collision.gameObject == manager.p1Goal)
        {
            manager.p1Score = manager.p1Score + 1;
            manager.scored = true;
        }
        else if (collision.gameObject == manager.p2Goal)
        {
            manager.p2Score = manager.p2Score + 1;
            manager.scored = true;
        }
    }
}
