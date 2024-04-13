using System.Collections;
using TMPro;
using UnityEngine;

public class pongManager : MonoBehaviour
{
    public data data;

    public playerControllerFree p1;
    public playerControllerFree p2;
    public GameObject p1Goal;
    public GameObject p2Goal;
    public TextMeshProUGUI p1ScoreDisplay;
    public TextMeshProUGUI p2ScoreDisplay;

    public int winBy = 5;


    public ball ball;
    public TrailRenderer ballTrail;

    public float p1Score;
    public float p2Score;

    public bool scored = false;

    void Start()
    {
        p1Score = 0;
        p2Score = 0;
        ball.StartMoving();
        ball.initPos = ball.transform.position;

        int player1FaceNum = PlayerPrefs.GetInt(data.p1FaceNum, 0);
        p1.GetComponent<SpriteRenderer>().sprite = data.faceList[player1FaceNum].GetComponent<SpriteRenderer>().sprite;
        int player1ColorNum = PlayerPrefs.GetInt(data.p1ColorNum, 0);
        p1.GetComponent<SpriteRenderer>().color = data.colorList[player1ColorNum].GetComponent<SpriteRenderer>().color;

        int player2FaceNum = PlayerPrefs.GetInt(data.p2FaceNum, 0);
        p2.GetComponent<SpriteRenderer>().sprite = data.faceList[player2FaceNum].GetComponent<SpriteRenderer>().sprite;
        int player2ColorNum = PlayerPrefs.GetInt(data.p2ColorNum, 0);
        p2.GetComponent<SpriteRenderer>().color = data.colorList[player2ColorNum].GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {   
        p1ScoreDisplay.text = p1Score.ToString();
        p2ScoreDisplay.text = p2Score.ToString();

        if (scored)
        {
            ballTrail.emitting = false;
            ball.ResetBall();
            StartCoroutine(Pauser());
        }

        if (p1Score == winBy || p2Score == winBy)
        {
            data.navLvlPicker();
        }
    }

    IEnumerator Pauser()
    {
        yield return new WaitForSeconds(1);
        ball.StartMoving();
        ballTrail.emitting = true;
        scored = false;
    }
}
