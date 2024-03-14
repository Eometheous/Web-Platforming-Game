using System.Collections;
using UnityEngine;

public class pointerController : MonoBehaviour
{
    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode actionKey;
    private Collider2D hoverOn;
    private bool canChangeColor = true;

    [Header("Scripts")]
    public data.playerNum player;
    [SerializeField] private data data;
    [SerializeField] private customizeManager customizeManager;
    [Space(15)]

    [Header("Ready Bar")]
    [SerializeField] private GameObject readyBar;
    [SerializeField] private GameObject readyCap;

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
        if (Input.GetKey(actionKey))
        {
            customize();
        }

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        GetComponent<Rigidbody2D>().AddForce(movement * Time.deltaTime * data.mouseMoveSpeed);
    }

    private void customize()
    {
        if (canChangeColor)
        {
            StartCoroutine(ChangeColorWithDelay());
        }

        for (int i = 0; i < data.faceList.Count; i ++)
        {
            if (hoverOn.gameObject.name == data.faceList[i].gameObject.name)
            {
                customizeManager.changeFace(player, i);
            }
        }

        for (int i = 0; i < data.colorList.Count; i++)
        {
            if (hoverOn.gameObject.name == data.colorList[i].gameObject.name)
            {
                customizeManager.changeColor(player, i);
            }
        }
    }

    IEnumerator ChangeColorWithDelay()
    {
        canChangeColor = false;
        if (hoverOn == readyBar.GetComponent<Collider2D>())
        {
            if (readyBar.GetComponent<SpriteRenderer>().color != Color.green)
            {
                readyBar.GetComponent<SpriteRenderer>().color = Color.green;
                readyCap.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                readyBar.GetComponent<SpriteRenderer>().color = Color.white;
                readyCap.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        yield return new WaitForSeconds(0.5f);
        canChangeColor = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger)
        {
            hoverOn = other;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            hoverOn = collision;
        }
    }
}
