using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pongManager : MonoBehaviour
{
    public playerControllerFree p1;
    public playerControllerFree p2;
    public GameObject p1Goal;
    public GameObject p2Goal;
    public ball ball;

    public float p1Score;
    public float p2Score;

    // Start is called before the first frame update
    void Start()
    {
        p1Score = 0;
        p2Score = 0;
        ball.startMoving();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
