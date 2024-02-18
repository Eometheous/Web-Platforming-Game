using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class powerUpScript : MonoBehaviour
{
    public float effectTime = 60.0f;
    public float rangeRadius = 10.0f;
    public float forceMultiplier = 2500.0f;
    private float ActiveCooldown = 2.5f;
    private float lastActiveTime;
    private bool startTimer;
    private bool initEffect;

    public enum powerUpType
    {
        reverseGravity,
        reverseKeys,
        push
    }
    public powerUpType Type;

    private playerController playerAffected;
    public playerController player1;
    public playerController player2;

    void Start()
    {
        initEffect = false;
        startTimer = false;
        lastActiveTime = -ActiveCooldown;
    }

    void Update()
    {
        if (initEffect)
        {
            switch (Type)
            {
                case powerUpType.reverseGravity:
                    reverseGravity();
                    break;
                case powerUpType.reverseKeys:
                    reverseKeys();
                    break;
            }
            initEffect = false;
        }
        if (startTimer)
        {
            effectTime -= Time.deltaTime;
            if (effectTime <= 0)
            {
                switch (Type)
                {
                    case powerUpType.reverseGravity:
                        reverseGravity();
                        break;
                    case powerUpType.reverseKeys:
                        reverseKeys();
                        break;
                }
                Destroy(gameObject);
            }
            if (!isPassive())
            {
                if (Input.GetKey(playerAffected.downKey))
                {
                    TryActivate();
                }
            }
        }
    }

    private void TryActivate()
    {
        if (Time.time - lastActiveTime >= ActiveCooldown)
        {
            switch (Type)
            {
                case powerUpType.push:
                    push();
                    break;
            }
            lastActiveTime = Time.time;
        }
    }

    private void reverseGravity()
    {

        playerAffected.GetComponent<Rigidbody2D>().gravityScale *= -1;
        playerAffected.reverseJump = !playerAffected.reverseJump;
    }

    private void reverseKeys()
    {
        playerAffected.reverseKeys = !playerAffected.reverseKeys;
    }

    private void push()
    {
        playerController playerPushed = player1;
        if (playerAffected == player1)
            playerPushed = player2;

        float distance = Vector3.Distance(playerAffected.transform.position, playerPushed.transform.position);
        if (distance <= rangeRadius)        // In range
        {
            float distanceFactor = 1f - Mathf.Clamp01(distance / rangeRadius);
            float xVec = playerPushed.transform.position.x - playerAffected.transform.position.x;
            float yVec = playerPushed.transform.position.y - playerAffected.transform.position.y;
            Vector2 movement = new Vector2(xVec, yVec);
            movement.Normalize();
            playerPushed.GetComponent<Rigidbody2D>().AddForce(movement * forceMultiplier * distanceFactor);
        }
    }

    private bool isCurrentPlayerAffected()
    {
        bool isCurPlayerAffected= false;
        switch (Type)
        {
            case powerUpType.reverseGravity:
            case powerUpType.reverseKeys:
                isCurPlayerAffected = true;
                break;
        }
        return isCurPlayerAffected;
    }

    private bool isPassive()
    {
        bool passive = false;
        switch (Type)
        {
            case powerUpType.reverseGravity:
            case powerUpType.reverseKeys:
                passive = true;
                break;
        }
        return passive;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerAffected == null)
            {
                //Debug.Log(collision.GetComponent<playerController>() == player1.GetComponent<playerController>());
                bool play1Affected = (collision.GetComponent<playerController>() == player1.GetComponent<playerController>() && !isCurrentPlayerAffected()) ||
                                     (collision.GetComponent<playerController>() == player2.GetComponent<playerController>() && isCurrentPlayerAffected());
                if (play1Affected)
                    playerAffected = player1.GetComponent<playerController>();
                else
                    playerAffected = player2.GetComponent<playerController>();

                GetComponent<Renderer>().enabled = false;
                initEffect = true;
                startTimer = true;
            }
        }
    }
}
