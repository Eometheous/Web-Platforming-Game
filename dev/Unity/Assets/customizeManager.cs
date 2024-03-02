using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class customizeManager : MonoBehaviour
{
    public string targetSceneName;

    void Start()
    {
        targetSceneName = "Basic Level";
    }

    public void startGame()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
