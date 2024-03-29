using UnityEngine;

public class powerUpScript : MonoBehaviour
{
    private float lastActiveTime;
    private bool startTimer;
    private bool initEffect;
    private playerController playerAffected;

    [Header("Must Init")]
    [SerializeField] private data data;
    [SerializeField] private playerController player1;
    [SerializeField] private playerController player2;
    [Space(15)]

    [Header("Power Up")]
    public data.powerUpType Type;
    public float activeCoolDown;
    public float effectTime;
    public float rangeRadius;
    public float forceMultiplier;

    void Start()
    {
        activeCoolDown = data.activeCoolDown;
        effectTime = data.puEffectTime;
        rangeRadius = data.puRangeRadius;
        forceMultiplier = data.puForceMultiplier;

        initEffect = false;
        startTimer = false;
        lastActiveTime = -activeCoolDown;
    }

    void Update()
    {
        if (initEffect)
        {
            switch (Type)
            {
                case data.powerUpType.reverseGravity:
                    reverseGravity();
                    break;
                case data.powerUpType.reverseKeys:
                    reverseKeys();
                    break;
            }
            initEffect = false;
        }
        if (startTimer)
        {
            effectTime -= Time.deltaTime;
            if (effectTime <= 0)
            {
                switch (Type)
                {
                    case data.powerUpType.reverseGravity:
                        reverseGravity();
                        break;
                    case data.powerUpType.reverseKeys:
                        reverseKeys();
                        break;
                }
                Destroy(gameObject);
            }
            if (!isPassive())
            {
                KeyCode actionKey = data.p1ActionKey;
                if (playerAffected.player == data.playerNum.player2)
                    actionKey = data.p2ActionKey;
                if (Input.GetKey(actionKey))
                {
                    TryActivate();
                }
            }
        }
    }

    private void TryActivate()
    {
        if (Time.time - lastActiveTime >= activeCoolDown)
        {
            switch (Type)
            {
                case data.powerUpType.push:
                    push();
                    break;
            }
            lastActiveTime = Time.time;
        }
    }

    private void reverseGravity()
    {

        playerAffected.GetComponent<Rigidbody2D>().gravityScale *= -1;
        playerAffected.reverseJump = !playerAffected.reverseJump;
    }

    private void reverseKeys()
    {
        playerAffected.reverseKeys = !playerAffected.reverseKeys;
    }

    private void push()
    {
        playerController playerPushed = player1;
        if (playerAffected == player1)
            playerPushed = player2;

        float distance = Vector3.Distance(playerAffected.transform.position, playerPushed.transform.position);
        if (distance <= rangeRadius)        // In range
        {
            float distanceFactor = 1f - Mathf.Clamp01(distance / rangeRadius);
            float xVec = playerPushed.transform.position.x - playerAffected.transform.position.x;
            float yVec = playerPushed.transform.position.y - playerAffected.transform.position.y;
            Vector2 movement = new Vector2(xVec, yVec);
            movement.Normalize();
            playerPushed.GetComponent<Rigidbody2D>().AddForce(movement * forceMultiplier * distanceFactor * Time.deltaTime);
        }
    }

    private bool isCurrentPlayerAffected()
    {
        bool isCurPlayerAffected= false;
        switch (Type)
        {
            case data.powerUpType.reverseGravity:
            case data.powerUpType.reverseKeys:
                isCurPlayerAffected = true;
                break;
        }
        return isCurPlayerAffected;
    }

    private bool isPassive()
    {
        bool passive = false;
        switch (Type)
        {
            case data.powerUpType.reverseGravity:
            case data.powerUpType.reverseKeys:
                passive = true;
                break;
        }
        return passive;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerAffected == null)
            {
                //Debug.Log(collision.GetComponent<playerController>() == player1.GetComponent<playerController>());
                bool play1Affected = (collision.GetComponent<playerController>() == player1.GetComponent<playerController>() && !isCurrentPlayerAffected()) ||
                                     (collision.GetComponent<playerController>() == player2.GetComponent<playerController>() && isCurrentPlayerAffected());
                if (play1Affected)
                    playerAffected = player1.GetComponent<playerController>();
                else
                    playerAffected = player2.GetComponent<playerController>();

                GetComponent<Renderer>().enabled = false;
                initEffect = true;
                startTimer = true;
            }
        }
    }
}
