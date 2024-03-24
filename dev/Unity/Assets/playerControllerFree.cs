using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerFree : MonoBehaviour
{
    private Rigidbody2D rb;
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
    public float forceMultiplier = 1.0f;
    public float verticalForceMultiplier = 1.0f;
    public float maxVerticalVelocity = 10.0f;
    public float maxHorizontalVelocity = 10.0f;
    public float verticalRatio = 20.0f;
    public float horizontalRatio = 20.0f;
    public bool reverseKeys = false;
    [Space(10)]

    [Header("Active PowerUp")]
    public data.curActivePowerUp activePowerUp;
    public float activeCoolDown;
    public float nextActive;
    public float dashMult;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activePowerUp = data.curActivePowerUp.none;
        activeCoolDown = data.activeCoolDown;
        dashMult = data.dashMult;
        updateKeys();
    }

    void Update()
    {
        float horizontalInput = 0f;
        if (Input.GetKey(leftKey))
        {
            horizontalInput = -1f;
            if (reverseKeys)
                horizontalInput *= -1;
        }
        else if (Input.GetKey(rightKey))
        {
            horizontalInput = 1f;
            if (reverseKeys)
                horizontalInput *= -1;
        }

        float verticalInput = 0f;
        if (Input.GetKey(upKey))
        {
            verticalInput = 1.0f * data.verticalForceMultiplier;
            if (reverseKeys)
                verticalInput *= -1f;
        }
        else if (Input.GetKey(downKey))
        {
            verticalInput = -1.0f * data.verticalForceMultiplier;
            if (reverseKeys)
                verticalInput *= -1f;
        }

        rb.velocity = new Vector2(rb.velocity.x + horizontalInput * forceMultiplier * horizontalRatio * Time.deltaTime,
                                        rb.velocity.y + verticalInput * forceMultiplier * verticalRatio * Time.deltaTime);

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxHorizontalVelocity, maxHorizontalVelocity), Mathf.Clamp(rb.velocity.y, -maxVerticalVelocity, maxVerticalVelocity));

        if (activePowerUp == data.curActivePowerUp.none && Input.GetKey(actionKey) && Time.time > nextActive)
        {
            nextActive = Time.time + activeCoolDown;

            float originalG = rb.gravityScale;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x + horizontalInput * transform.localScale.x * forceMultiplier * horizontalRatio * dashMult * Time.deltaTime, rb.velocity.y);
            rb.gravityScale = originalG;
        }
    }

    public void updateKeys()
    {
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
