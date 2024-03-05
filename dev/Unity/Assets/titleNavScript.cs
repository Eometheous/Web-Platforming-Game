using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleNavScript : MonoBehaviour
{
    private string startGame;
    private string tutorial;
    private string settings;

    void Start()
    {
        startGame = "Customize Players";
        tutorial = "Tutorial";
        settings = "Settings";
    }

    public void navStartGame()
    {
        SceneManager.LoadScene(startGame);
    }

    public void navTutorial()
    {
        SceneManager.LoadScene(tutorial);
    }

    public void navSettings()
    {
        SceneManager.LoadScene(settings);
    }
}
