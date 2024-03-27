using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointerController2 : MonoBehaviour
{
    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode actionKey;
    public Collider2D hoverOn;

    [Header("Scripts")]
    public data.playerNum player;
    [SerializeField] private data data;

    private void Start()
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

    private void Update()
    {
        float horizontalInput = 0;
        float verticalInput = 0;
        if (Input.GetKey(upKey))
        {
            verticalInput = 1;
        }
        else if (Input.GetKey(downKey))
        {
            verticalInput = -1;
        }
        if (Input.GetKey(leftKey))
        {
            horizontalInput = -1;
        }
        else if (Input.GetKey(rightKey))
        {
            horizontalInput = 1;
        }

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        GetComponent<Rigidbody2D>().AddForce(movement * Time.deltaTime * data.mouseMoveSpeed * 2);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            hoverOn = collision;
        }
    }
}
