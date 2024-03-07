using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform mainCamera;
    public Transform target;
    public float smoothSpeed = 10.0f;
    public float yOffset = 0.0f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(0f, target.position.y + yOffset, mainCamera.transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(mainCamera.transform.position, desiredPosition, smoothSpeed);
            //mainCamera.transform.position = smoothedPosition;
        }
    }
}
