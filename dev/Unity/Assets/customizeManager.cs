using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class customizeManager : MonoBehaviour
{
    public string targetSceneName;
    public pointerController pointer1;
    public pointerController pointer2;
    public GameObject readyBar1;
    public GameObject readyBar2;

    public GameObject player1Preview;
    public GameObject player2Preview;

    public GameObject face1;
    public GameObject face2;
    public GameObject face3;

    public GameObject color1;
    public GameObject color2;
    public GameObject color3;
    public GameObject color4;
    public GameObject color5;
    public GameObject color6;
    public GameObject color7;

    public void changeFace(int playerNum, int faceNum)
    {
        GameObject previewChanged = player1Preview;
        if (playerNum == 2)
            previewChanged = player2Preview;
        
        if (faceNum == 0)
            previewChanged.GetComponent<SpriteRenderer>().sprite = face1.GetComponent<SpriteRenderer>().sprite;
        else if (faceNum == 1)
            previewChanged.GetComponent<SpriteRenderer>().sprite = face2.GetComponent<SpriteRenderer>().sprite;
        else if (faceNum == 2)
            previewChanged.GetComponent<SpriteRenderer>().sprite = face3.GetComponent<SpriteRenderer>().sprite;
    }

    public void changeColor(int playerNum, int colorNum)
    {
        GameObject previewChanged = player1Preview;
        if (playerNum == 2)
            previewChanged = player2Preview;
        
        if (colorNum == 0)
            previewChanged.GetComponent<SpriteRenderer>().color = color1.GetComponent<SpriteRenderer>().color;
        else if (colorNum == 1)
            previewChanged.GetComponent<SpriteRenderer>().color = color2.GetComponent<SpriteRenderer>().color;
        else if (colorNum == 2)
            previewChanged.GetComponent<SpriteRenderer>().color = color3.GetComponent<SpriteRenderer>().color;
        else if (colorNum == 3)
            previewChanged.GetComponent<SpriteRenderer>().color = color4.GetComponent<SpriteRenderer>().color;
        else if (colorNum == 4)
            previewChanged.GetComponent<SpriteRenderer>().color = color5.GetComponent<SpriteRenderer>().color;
        else if (colorNum == 5)
            previewChanged.GetComponent<SpriteRenderer>().color = color6.GetComponent<SpriteRenderer>().color;
        else if (colorNum == 6)
            previewChanged.GetComponent<SpriteRenderer>().color = color7.GetComponent<SpriteRenderer>().color;
    }

    void Start()
    {
        targetSceneName = "Basic Level";
    }

    public void startGame()
    {
        SceneManager.LoadScene(targetSceneName);
    }
    private void Update()
    {
        if (readyBar1.GetComponent<SpriteRenderer>().color == Color.green && readyBar2.GetComponent<SpriteRenderer>().color == Color.green)
        {
            startGame();
        }
    }
}
