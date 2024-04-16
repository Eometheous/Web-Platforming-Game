using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class finishLineScript : MonoBehaviour
{

    [SerializeField] TMP_Text _text;
    float _currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        if (time.Seconds < 10) _text.text = time.Minutes.ToString() + ":0" + time.Seconds.ToString();
        else _text.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Debug.Log("Test");
    }
}
