using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gameManage : MonoBehaviour
{
    public playerController player1;
    public playerController player2;
    public float verticalForceMultiplier;
    public float horizontalForceMultiplier;
    public float maxVerticalVelocity;
    public float maxHorizontalVelocity;
    public float slowFactor;

    public data data;
    public GameObject p1Icon;
    public GameObject p1Heart1;
    public GameObject p1Heart2;
    public GameObject p1Heart3;
    public GameObject p2Icon;
    public GameObject p2Heart1;
    public GameObject p2Heart2;
    public GameObject p2Heart3;

    void Start()
    {
        resetPlayersKeys();
        verticalForceMultiplier = 10f;
        horizontalForceMultiplier = 5f;
        maxVerticalVelocity = 10f;
        maxHorizontalVelocity = 10f;
        slowFactor = 0.5f;

        data.initList();

        int player1FaceNum = PlayerPrefs.GetInt("Player1FaceNum", 0);
        player1.GetComponent<SpriteRenderer>().sprite = data.faceList[player1FaceNum].GetComponent<SpriteRenderer>().sprite;
        int player1ColorNum = PlayerPrefs.GetInt("Player1ColorNum", 0);
        player1.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;
        p1Icon.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;
        p1Heart1.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;
        p1Heart2.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;
        p1Heart3.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;

        int player2FaceNum = PlayerPrefs.GetInt("Player2FaceNum", 0);
        player2.GetComponent<SpriteRenderer>().sprite = data.faceList[player2FaceNum].GetComponent<SpriteRenderer>().sprite;
        int player2ColorNum = PlayerPrefs.GetInt("Player2ColorNum", 0);
        player2.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
        p2Icon.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
        p2Heart1.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
        p2Heart2.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
        p2Heart3.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        resetDefault();
    }

    public void resetDefault()
    {
        player1.verticalForceMultiplier = verticalForceMultiplier;
        player1.forceMultiplier = horizontalForceMultiplier;
        player1.maxVerticalVelocity = maxVerticalVelocity;
        player1.maxHorizontalVelocity = maxHorizontalVelocity;
        player1.slowFactor = slowFactor;
        player2.verticalForceMultiplier = verticalForceMultiplier;
        player2.forceMultiplier = horizontalForceMultiplier;
        player2.maxVerticalVelocity = maxVerticalVelocity;
        player2.maxHorizontalVelocity = maxHorizontalVelocity;
        player2.slowFactor = slowFactor;
    }

    public void resetPlayersKeys()
    {
        player1.changeKeys(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.Space);
        player2.changeKeys(KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Return);
    }
}
