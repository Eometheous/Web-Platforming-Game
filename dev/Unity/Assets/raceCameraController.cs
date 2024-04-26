using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raceCameraManager : MonoBehaviour
{
    public float camSmoothSpeed = 10.0f;
    [Header("Camera 1 Variables")]
    public float cam1MinYPosition = 0.0f;
    public float cam1MaxYPosition = 90.0f;
    public float cam1MinXPosition = -8.9f;
    public float cam1MaxXPosition = 8.9f;
    [Space(15)]

    [Header("Camera 2 Variables")]
    public float cam2MinYPosition = 0.0f;
    public float cam2MaxYPosition = 90.0f;
    public float cam2MinXPosition = -8.9f;
    public float cam2MaxXPosition = 8.9f;
    [Space(15)]

    [SerializeField] private Camera cam1;
    [SerializeField] private GameObject player1;
    [SerializeField] private Camera cam2;
    [SerializeField] private GameObject player2;

    private void Update()
    {
        Vector3 desiredPosition = new Vector3(Mathf.Clamp(player1.transform.position.x, cam1MinXPosition, cam1MaxXPosition), Mathf.Clamp(player1.transform.position.y, cam1MinYPosition, cam1MaxYPosition), cam1.transform.position.z);
        cam1.transform.position = desiredPosition;

        Vector3 desiredPosition2 = new Vector3(Mathf.Clamp(player2.transform.position.x, cam2MinXPosition, cam2MaxXPosition), Mathf.Clamp(player2.transform.position.y, cam2MinYPosition, cam2MaxYPosition), cam2.transform.position.z);
        cam2.transform.position = desiredPosition2;
    }
}
