using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField] private data data;
    [SerializeField] private Camera cam1;
    [SerializeField] private GameObject player1;
    [SerializeField] private Camera cam2;
    [SerializeField] private GameObject player2;

    private void Update()
    {
        Vector3 desiredPosition = new Vector3(Mathf.Clamp(player1.transform.position.x, data.camMinXPosition, data.camMaxXPosition), Mathf.Clamp(player1.transform.position.y, data.camMinYPosition, data.camMaxYPosition), cam1.transform.position.z);
        cam1.transform.position = desiredPosition;

        Vector3 desiredPosition2 = new Vector3(Mathf.Clamp(player2.transform.position.x, data.camMinXPosition, data.camMaxXPosition), Mathf.Clamp(player2.transform.position.y, data.camMinYPosition, data.camMaxYPosition), cam2.transform.position.z);
        cam2.transform.position = desiredPosition2;
    }
}
