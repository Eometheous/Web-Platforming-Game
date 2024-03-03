using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float verticalForceMultiplier = 10f;
    public float forceMultiplier = 20f;
    public float maxVerticalVelocity = 20f;
    public float maxHorizontalVelocity = 5f;

    public float slowFactor = 0.00001f;

    private bool touchingGround = false;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    private Rigidbody2D rb;

    public bool reverseJump = false;
    public bool reverseKeys = false;

    public float verticalRatio = 750.0f;
    public float horizontalRatio = 500.0f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        verticalRatio = 750.0f;
        horizontalRatio = 500.0f;
    }

    // Update is called once per frame
    void Update() {
        float horizontalInput = 0f;
        if (Input.GetKey(leftKey)) {
            horizontalInput = -1f;
            if (reverseKeys)
                horizontalInput *= -1;
        } else if (Input.GetKey(rightKey)) {
            horizontalInput = 1f;
            if (reverseKeys)
                horizontalInput *= -1;
        }

        float verticalInput = 0f;
        if (Input.GetKey(upKey) && touchingGround) {
            verticalInput = 6f;
            if (reverseJump)
                verticalInput *= -1;
        }

        Vector2 movement = new Vector2(horizontalInput * forceMultiplier * horizontalRatio, verticalInput * forceMultiplier * verticalRatio);
        
        if (touchingGround)
        {
            rb.AddForce(movement * Time.deltaTime);
            //Debug.Log("touching ground 1: " +  movement);
            //Debug.Log("touching ground 2: " + movement * Time.deltaTime * ratio);
        }
        else
        {
            if ((rb.velocity.x < 2f && horizontalInput < 0)|| (rb.velocity.x > -2f && horizontalInput > 0))
                rb.AddForce(movement * slowFactor * slowFactor * Time.deltaTime);
            else if ((rb.velocity.x < 2f && horizontalInput > 0) || (rb.velocity.x > -2f && horizontalInput < 0)) 
                rb.AddForce(movement * slowFactor * slowFactor * slowFactor * Time.deltaTime);
        }

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxHorizontalVelocity, maxHorizontalVelocity), rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Wall")
            touchingGround = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            touchingGround = true;
        if (collision.gameObject.tag == "Wall")
            touchingGround = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Wall")
            touchingGround = false;
    }

    public void changeKeys(KeyCode up, KeyCode down, KeyCode left, KeyCode right) {
        upKey = up;
        downKey = down;
        leftKey = left;
        rightKey = right;
    }
}
