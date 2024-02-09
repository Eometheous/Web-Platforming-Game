using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float verticalForceMultiplier;
    public float horizontalForceMultiplier;
    public float maxVerticalVelocity;
    public float maxHorizontalVelocity;

    public float verticalOffset;
    public bool touchingGround;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    private Rigidbody2D rb;

    void Start()
    {
        verticalForceMultiplier = 10f;
        horizontalForceMultiplier = 5f;
        maxVerticalVelocity = 10f;
        maxHorizontalVelocity = 5f;

        verticalOffset = 5f;
        touchingGround = false;

        upKey = KeyCode.W;
        downKey = KeyCode.S;
        leftKey = KeyCode.A;
        rightKey = KeyCode.D;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0f;
        if (Input.GetKey(leftKey))
        {
            horizontalInput = -1f;
        } else if (Input.GetKey(rightKey))
        {
            horizontalInput = 1f;
        }
        float verticalInput = 0f;
        if (Input.GetKey(upKey) && touchingGround)
        {
            verticalInput = 1f;
        }

        Vector2 horizontalMovement = new Vector2(horizontalInput, 0f).normalized;
        rb.AddForce(horizontalMovement * horizontalForceMultiplier);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxHorizontalVelocity, maxHorizontalVelocity), rb.velocity.y);

        Vector2 verticalMovement = new Vector2(0f, verticalInput * verticalOffset).normalized;
        rb.AddForce(verticalMovement * verticalForceMultiplier);
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -maxVerticalVelocity, maxVerticalVelocity));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with object of tag: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Platform")
        {
            touchingGround = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingGround = false;
        }
    }
}
