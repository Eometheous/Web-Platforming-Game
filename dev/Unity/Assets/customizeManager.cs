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
