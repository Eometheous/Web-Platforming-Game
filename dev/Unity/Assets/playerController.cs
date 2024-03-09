using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static pointerController;

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
    public KeyCode actionKey = KeyCode.Space;
    private Rigidbody2D rb;

    public bool reverseJump = false;
    public bool reverseKeys = false;

    public float verticalRatio = 750.0f;
    public float horizontalRatio = 500.0f;

    public enum curActivePowerUp
    {
        none,
        push
    }
    public curActivePowerUp activePowerUp;
    public float nextActive;
    public float activeCoolDown;
    public float dashMult;
    public float timeMinusTillNext;
    //public bool isActiveCoolDown = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        verticalRatio = 75.0f;
        horizontalRatio = 50.0f;
        activeCoolDown = 2.0f;
        dashMult = 25.0f;
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

        if (touchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x + horizontalInput * forceMultiplier * horizontalRatio * Time.deltaTime,
                                        rb.velocity.y + verticalInput * forceMultiplier * verticalRatio * Time.deltaTime);
        }
        else
        {
            if ((rb.velocity.x < 2f && horizontalInput < 0)|| (rb.velocity.x > -2f && horizontalInput > 0))
            {
                rb.velocity = new Vector2(rb.velocity.x + horizontalInput * forceMultiplier * horizontalRatio * slowFactor * slowFactor * Time.deltaTime,
                                          rb.velocity.y + verticalInput * forceMultiplier * verticalRatio * slowFactor * slowFactor * Time.deltaTime);
            }
            else if ((rb.velocity.x < 2f && horizontalInput > 0) || (rb.velocity.x > -2f && horizontalInput < 0))
            {
                rb.velocity = new Vector2(rb.velocity.x + horizontalInput * forceMultiplier * horizontalRatio * slowFactor * slowFactor * slowFactor * Time.deltaTime,
                                          rb.velocity.y + verticalInput * forceMultiplier * verticalRatio * slowFactor * slowFactor * slowFactor * Time.deltaTime);
            }
                
        }

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxHorizontalVelocity, maxHorizontalVelocity), Mathf.Clamp(rb.velocity.y, -maxVerticalVelocity, maxVerticalVelocity));

        timeMinusTillNext = Time.time - nextActive;
        if (activePowerUp == curActivePowerUp.none && Input.GetKey(actionKey) && Time.time > nextActive)
        {
            nextActive = Time.time + activeCoolDown;

            float originalG = rb.gravityScale;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x + horizontalInput * transform.localScale.x * forceMultiplier * horizontalRatio * dashMult * Time.deltaTime, rb.velocity.y);
            rb.gravityScale = originalG;

            Debug.Log("Active Used");
        }
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

    public void changeKeys(KeyCode up, KeyCode down, KeyCode left, KeyCode right, KeyCode action) {
        upKey = up;
        downKey = down;
        leftKey = left;
        rightKey = right;
        actionKey = action;
    }
}
