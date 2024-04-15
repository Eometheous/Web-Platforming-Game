using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoOpCameraController : MonoBehaviour
{ 
    public Camera cam;

    public GameObject player1, player2;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = GetMiddleOfPlayers();
        cam.orthographicSize = SetZoomLevel();
    }

    private Vector3 GetMiddleOfPlayers()
    {
        return new Vector3((player1.transform.position.x + player2.transform.position.x) / 2,
        (player1.transform.position.y + player2.transform.position.y) / 2, -10);
    }

    private float SetZoomLevel() {
        return Mathf.Clamp(((player1.transform.position - player2.transform.position)/2).magnitude, 7, 20);
    }
}
