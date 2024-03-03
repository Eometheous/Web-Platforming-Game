using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static pointerController;

public class customizeManager : MonoBehaviour
{
    public string targetSceneName;
    public pointerController pointer1;
    public pointerController pointer2;
    public GameObject readyBar1;
    public GameObject readyBar2;

    public GameObject player1Preview;
    public GameObject player2Preview;

    public List<GameObject> faceList;
    public List<GameObject> colorList;
    public data data;

    void Start()
    {
        targetSceneName = "Basic Level";

        data.initList();
        faceList = data.faceList;
        colorList = data.colorList;

        PlayerPrefs.SetInt("Player1FaceNum", 0);
        PlayerPrefs.SetInt("Player1ColorNum", 0);
        PlayerPrefs.SetInt("Player2FaceNum", 0);
        PlayerPrefs.SetInt("Player2ColorNum", 0);
        PlayerPrefs.Save();
    }

    public void changeFace(int playerNum, int faceNum)
    {
        GameObject previewChanged = player1Preview;
        if (playerNum == 2)
            previewChanged = player2Preview;
        string faceString = "Player" + playerNum + "FaceNum";

        for (int i = 0; i < faceList.Count; i++)
        {
            if (faceNum == i)
            {
                previewChanged.GetComponent<SpriteRenderer>().sprite = faceList[i].GetComponent<SpriteRenderer>().sprite;
                PlayerPrefs.SetInt(faceString, i);
                Debug.Log(faceString + ": " + i);
                PlayerPrefs.Save();
            }
        }
    }

    public void changeColor(int playerNum, int colorNum)
    {
        GameObject previewChanged = player1Preview;
        if (playerNum == 2)
            previewChanged = player2Preview;
        string colorString = "Player" + playerNum + "ColorNum";

        for (int i = 0; i < colorList.Count; i++)
        {
            if (colorNum == i)
            {
                previewChanged.GetComponent<SpriteRenderer>().color = colorList[i].GetComponent<SpriteRenderer>().color;
                PlayerPrefs.SetInt(colorString, i);
                Debug.Log(colorString + ": " + i);
                PlayerPrefs.Save();
            }
        }
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
