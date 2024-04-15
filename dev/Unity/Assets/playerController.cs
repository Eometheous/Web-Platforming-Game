using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool touchingGround = false;
    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode actionKey;

    [Header("Must Init")]
    [SerializeField] private data data;
    public data.playerNum player;
    [Space(15)]

    [Header("Movement")]
    public bool freeMovement = false;
    public float forceMultiplier;
    public float verticalForceMultiplier;
    public float maxVerticalVelocity;
    public float maxHorizontalVelocity;
    public float slowFactor;
    public float verticalRatio;
    public float horizontalRatio;
    public bool reverseJump = false;
    public bool reverseKeys = false;
    [Space(10)]

    [Header("Active PowerUp")]
    public data.curActivePowerUp activePowerUp;
    public float activeCoolDown;
    public float nextActive;
    public float dashMult;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        activePowerUp = data.curActivePowerUp.none;
        activeCoolDown = data.activeCoolDown;
        if (!freeMovement)
        {
            forceMultiplier = data.forceMultiplier;
            verticalForceMultiplier = data.verticalForceMultiplier;
            maxVerticalVelocity = data.maxVerticalVelocity;
            maxHorizontalVelocity = data.maxHorizontalVelocity;
            slowFactor = data.slowFactor;
            verticalRatio = data.verticalRatio;
            horizontalRatio = data.horizontalRatio;
        }
        dashMult = data.dashMult;
        updateKeys();
    }

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
            verticalInput = 1.0f * data.verticalForceMultiplier;
            if (reverseJump)
                verticalInput *= -1f;
            if (reverseKeys) 
                verticalInput *= -1f;
        } else if (Input.GetKey(downKey))
        {
            verticalInput = -1.0f * data.verticalForceMultiplier;
            if (reverseJump)
                verticalInput *= -1f;
            if (reverseKeys)
                verticalInput *= -1f;
        }

        if (touchingGround || freeMovement)
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
        //Debug.Log(rb.velocity);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxHorizontalVelocity, maxHorizontalVelocity), Mathf.Clamp(rb.velocity.y, -maxVerticalVelocity, maxVerticalVelocity));
        //Debug.Log("clamped: " + rb.velocity);

        if (activePowerUp == data.curActivePowerUp.none && Input.GetKey(actionKey) && Time.time > nextActive)
        {
            nextActive = Time.time + activeCoolDown;

            float originalG = rb.gravityScale;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x + horizontalInput * transform.localScale.x * forceMultiplier * horizontalRatio * dashMult * Time.deltaTime, rb.velocity.y);
            rb.gravityScale = originalG;
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

    public void updateKeys() {
        switch (player)
        {
            case data.playerNum.player1:
                upKey = data.p1UpKey;
                downKey = data.p1DownKey;
                leftKey = data.p1LeftKey;
                rightKey = data.p1RightKey;
                actionKey = data.p1ActionKey;
                break;
            case data.playerNum.player2:
                upKey = data.p2UpKey;
                downKey = data.p2DownKey;
                leftKey = data.p2LeftKey;
                rightKey = data.p2RightKey;
                actionKey = data.p2ActionKey;
                break;
        }
    }
}
