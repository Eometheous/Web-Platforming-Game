using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class data : MonoBehaviour
{
    [Header("Customization")]
    public List<GameObject> faceList = new List<GameObject>();
    public List<GameObject> colorList = new List<GameObject>();
    [Space(15)]


    [Header("Name of Scenes")]
    public string startGame = "Customize Players";
    public string tutorial = "Tutorial";
    public string settings = "Settings";
    public string title = "Title";
    public string basicLevel = "Basic Level";
    [Space(15)]


    [Header("Saved Data Strings")]
    public string p1ColorNum = "p1ColorNum";
    public string p1FaceNum = "p1FaceNum";
    public string p2ColorNum = "p2ColorNum";
    public string p2FaceNum = "p2FaceNum";
    [Space(15)]


    [Header("Camera Speed & Position")]
    public float camSmoothSpeed = 10.0f;
    public float camMinYPosition = -25.0f;
    public float camMaxYPosition = 0.0f;
    public float camMinXPosition = -8.9f;
    public float camMaxXPosition = 8.9f;
    [Space(15)]


    [Header("Players Movement Speed")]
    public float forceMultiplier = 20f;
    public float verticalForceMultiplier = 6f;
    public float maxVerticalVelocity = 5f;
    public float maxHorizontalVelocity = 5f;
    public float slowFactor = 0.5f;
    public float verticalRatio = 75.0f;
    public float horizontalRatio = 50.0f;
    public float dashMult = 25.0f;
    public float activeCoolDown = 2.0f;
    [Space(15)]


    [Header("Players Movement Keys")]
    public KeyCode p1UpKey = KeyCode.W;
    public KeyCode p1DownKey = KeyCode.S;
    public KeyCode p1LeftKey = KeyCode.A;
    public KeyCode p1RightKey = KeyCode.D;
    public KeyCode p1ActionKey = KeyCode.Space;
    public KeyCode p2UpKey = KeyCode.UpArrow;
    public KeyCode p2DownKey = KeyCode.DownArrow;
    public KeyCode p2LeftKey = KeyCode.LeftArrow;
    public KeyCode p2RightKey = KeyCode.RightArrow;
    public KeyCode p2ActionKey = KeyCode.Return;
    [Space(15)]


    [Header("Mouse Pointers")]
    public float mouseMoveSpeed = 250.0f;
    [Space(15)]


    [Header("Power Ups")]
    public float puEffectTime = 60.0f;
    public float puRangeRadius = 10.0f;
    public float puForceMultiplier = 2500.0f;
    public enum powerUpType
    {
        reverseGravity,
        reverseKeys,
        push
    }
    public enum curActivePowerUp
    {
        none,
        push
    }


    // Player Type (1 or 2)
    public enum playerNum
    {
        player1,
        player2
    }


    // Navigating to other scenes
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
    public void navTitle()
    {
        SceneManager.LoadScene(title);
    }
    public void navBasicLevel()
    {
        SceneManager.LoadScene(basicLevel);
    }
}
