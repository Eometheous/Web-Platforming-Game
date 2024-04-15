using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Levatate : MonoBehaviour
{
    public GameObject levatatedObject;
    public bool levatating;
    public bool upDown;

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = levatatedObject.GetComponent<Rigidbody2D>();
        if (levatating) {
            if (upDown) rb.AddForce(-2 * rb.gravityScale * Vector2.down);
            else rb.AddForce(2 * rb.gravityScale * Vector2.right);
        }
        else if (!upDown) rb.AddForce(rb.gravityScale * Vector2.left);
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        levatating = true;
    }

    public void OnTriggerExit2D(Collider2D collider) {
        levatating = false;
    }
}
