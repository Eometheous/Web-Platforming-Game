using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class platformLiner : MonoBehaviour
{
    public GameObject endcap1;
    public GameObject endcap2;
    private EdgeCollider2D edgeCollider;

    // Start is called before the first frame update
    void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        Vector2[] worldEndPoints = GetWorldEndPoints(edgeCollider);
        endcap1.transform.position = worldEndPoints[0];
        endcap2.transform.position = worldEndPoints[1];
    }

    Vector2[] GetWorldEndPoints(EdgeCollider2D collider)
    {
        // Get the points of the Edge Collider in local space
        Vector2[] localPoints = collider.points;

        // Get the Transform component of the GameObject
        Transform transform = collider.transform;

        // Convert local space points to world space
        Vector2[] worldEndPoints = new Vector2[2];
        worldEndPoints[0] = transform.TransformPoint(localPoints[0]); // First point in world space
        worldEndPoints[1] = transform.TransformPoint(localPoints[localPoints.Length - 1]); // Last point in world space

        return worldEndPoints;
    }
}
