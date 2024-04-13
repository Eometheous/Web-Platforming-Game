using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Levatate : MonoBehaviour
{
    public GameObject levatatedObject;
    public bool levatating;

    // Update is called once per frame
    void Update()
    {
        if (levatating) {
            Rigidbody2D rb = levatatedObject.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * 20);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        levatating = true;
    }

    public void OnTriggerExit2D(Collider2D collider) {
        levatating = false;
    }
}
