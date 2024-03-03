using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Build.Player;
using UnityEngine;

public class pointerController : MonoBehaviour
{
    public enum playerNum
    {
        player1,
        player2
    }
    public playerNum player;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode actionKey;

    public float moveSpeed = 5.0f;
    public Collider2D hoverOn;

    public GameObject readyBar;
    public GameObject readyCap;
    private bool canChangeColor = true;

    public customizeManager customizeManager;

    private void Start()
    {
        switch (player)
        {
            case playerNum.player1:
                upKey = KeyCode.W;
                downKey = KeyCode.S;
                leftKey = KeyCode.A;
                rightKey = KeyCode.D;
                actionKey = KeyCode.Space;
                break;
            case playerNum.player2:
                upKey = KeyCode.UpArrow;
                downKey = KeyCode.DownArrow;
                leftKey = KeyCode.LeftArrow;
                rightKey = KeyCode.RightArrow;
                actionKey = KeyCode.Return;
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
        GetComponent<Rigidbody2D>().AddForce(movement);
    }

    private void customize()
    {
        int playerInt = 0;
        switch (player)
        {
            case playerNum.player1:
                playerInt = 1;
                break;
            case playerNum.player2:
                playerInt = 2;
                break;
        }
        if (hoverOn.gameObject.name == "f1")
        {
            //UnityEngine.Debug.Log("pressed on f1");
            customizeManager.changeFace(playerInt, 0);
        } 
        else if (hoverOn.gameObject.name == "f2")
        {
            customizeManager.changeFace(playerInt, 1);
        }
        else if (hoverOn.gameObject.name == "f3")
        {
            customizeManager.changeFace(playerInt, 2);
        }
        else if (hoverOn.gameObject.name == "cw")
        {
            customizeManager.changeColor(playerInt, 0);
        }
        else if (hoverOn.gameObject.name == "cr")
        {
            customizeManager.changeColor(playerInt, 1);
        }
        else if (hoverOn.gameObject.name == "co")
        {
            customizeManager.changeColor(playerInt, 2);
        }
        else if (hoverOn.gameObject.name == "cy")
        {
            customizeManager.changeColor(playerInt, 3);
        }
        else if (hoverOn.gameObject.name == "cg")
        {
            customizeManager.changeColor(playerInt, 4);
        }
        else if (hoverOn.gameObject.name == "cb")
        {
            customizeManager.changeColor(playerInt, 5);
        }
        else if (hoverOn.gameObject.name == "cp")
        {
            customizeManager.changeColor(playerInt, 6);
        }

        if (canChangeColor)
        {
            StartCoroutine(ChangeColorWithDelay());
        }
    }

    IEnumerator ChangeColorWithDelay()
    {
        canChangeColor = false;
        //UnityEngine.Debug.Log(hoverOn + " : " + readyBar.GetComponent<Collider2D>());
        if (hoverOn == readyBar.GetComponent<Collider2D>())
        {
            UnityEngine.Debug.Log("Click ready");
            if (readyBar.GetComponent<SpriteRenderer>().color != Color.green)
            {
                readyBar.GetComponent<SpriteRenderer>().color = Color.green;
                readyCap.GetComponent<SpriteRenderer>().color = Color.green;
                UnityEngine.Debug.Log("Change color to green");
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
