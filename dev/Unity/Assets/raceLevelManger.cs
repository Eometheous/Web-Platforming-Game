using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public data data;
    public timer timer;

    [Header("Finish Line Effects")]
    public float spinSpeed = 50f; // Speed of rotation
    public float scaleSpeed = 0.05f; // Speed of scaling
    public float maxScale = 1.5f; // Maximum scale
    public float flashSpeed = 1.0f; // Speed of flashing
    private float flashTime = 0f; // Timer for flashing effect


    // Start is called before the first frame update
    void Start()
    {
        timer.startTimer();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);

        // Scaling
        float scaleFactor = Mathf.PingPong(Time.time * scaleSpeed, maxScale) + 0.5f; // Ping pong between 0.5 and maxScale
        transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);

        // Flashing RGB
        flashTime += Time.deltaTime * flashSpeed;
        float r = Mathf.PingPong(flashTime, 1.0f);
        float g = Mathf.PingPong(flashTime + 0.33f, 1.0f);
        float b = Mathf.PingPong(flashTime + 0.67f, 1.0f);
        GetComponent<SpriteRenderer>().color = new Color(r, g, b);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timer.stopTimer();
            data.navGameEnd();
        }
    }
}
