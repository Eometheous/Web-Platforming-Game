using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject target;
    [SerializeField] private Camera mainCamera2;
    [SerializeField] private GameObject target2;
    public float smoothSpeed = 10.0f;
    float minYPosition = -25.0f;
    float maxYPosition = 0.0f;
    float minXPosition = -8.9f;
    float maxXPosition = 8.9f;

    private void Update()
    {
        Vector3 desiredPosition = new Vector3(Mathf.Clamp(target.transform.position.x, minXPosition, maxXPosition), Mathf.Clamp(target.transform.position.y, minYPosition, maxYPosition), mainCamera.transform.position.z);
        mainCamera.transform.position = desiredPosition;

        Vector3 desiredPosition2 = new Vector3(Mathf.Clamp(target2.transform.position.x, minXPosition, maxXPosition), Mathf.Clamp(target2.transform.position.y, minYPosition, maxYPosition), mainCamera2.transform.position.z);
        mainCamera2.transform.position = desiredPosition2;
    }
}
