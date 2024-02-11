using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float verticalForceMultiplier = 10f;
    public float horizontalForceMultiplier = 5f;
    public float maxVerticalVelocity = 10f;
    public float maxHorizontalVelocity = 5f;

    //public float horizontalInertia = 0.9f;
    //private bool jumpLeft = false;

    private bool touchingGround = false;
    private KeyCode upKey = KeyCode.W;
    private KeyCode downKey = KeyCode.S;
    private KeyCode leftKey = KeyCode.A;
    private KeyCode rightKey = KeyCode.D;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float horizontalInput = 0f;
        if (Input.GetKey(leftKey)) {
            horizontalInput = -1f;
        } else if (Input.GetKey(rightKey)) {
            horizontalInput = 1f;
        }

        float verticalInput = 0f;
        if (Input.GetKey(upKey) && touchingGround) {
            verticalInput = 1f;
        }

        Vector2 horizontalMovement = new Vector2(horizontalInput, 0f).normalized;

        // Commented out to enable side movements in air
        //if (touchingGround)
            //rb.AddForce(horizontalMovement * horizontalForceMultiplier);
        rb.AddForce(horizontalMovement * horizontalForceMultiplier);

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxHorizontalVelocity, maxHorizontalVelocity), rb.velocity.y);

        Vector2 verticalMovement = new Vector2(0f, verticalInput).normalized;
        rb.AddForce(verticalMovement * verticalForceMultiplier);
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -maxVerticalVelocity, maxVerticalVelocity));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collided with object of tag: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Player")
            touchingGround = true;
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Player")
            touchingGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Player")
            touchingGround = false;
    }

    public void changeKeys(KeyCode up, KeyCode down, KeyCode left, KeyCode right) {
        upKey = up;
        downKey = down;
        leftKey = left;
        rightKey = right;
    }
}
